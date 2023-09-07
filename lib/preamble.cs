using System;
using System.IO;
using System.Text;

namespace Preamble
{
    public class Sizer : Stream
    {
        private byte[] buf;

        public Sizer()
        {
            buf = new byte[0];
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            int n = buf.Length - buf.Length;
            if (n > 0)
            {
                if (count < n)
                {
                    n = count;
                }
                buf = buf.Concat(buffer.Skip(offset).Take(n)).ToArray();
            }
        }

        public override void Flush() { }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public long Size()
        {
            return BitConverter.ToInt64(buf, 0);
        }

        public override bool CanRead => false;
        public override bool CanSeek => false;
        public override bool CanWrite => true;
        public override long Length => throw new NotSupportedException();
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
    }

    public static class Multicodec
    {
        public static byte[] Header(byte[] data)
        {
            byte[] lenBytes = BitConverter.GetBytes((ulong)data.Length);
            byte[] header = new byte[lenBytes.Length + data.Length];
            Buffer.BlockCopy(lenBytes, 0, header, 0, lenBytes.Length);
            Buffer.BlockCopy(data, 0, header, lenBytes.Length, data.Length);
            return header;
        }

        public static byte[] ReadHeader(byte[] data, out int bytesRead)
        {
            ulong len = ReadUvarint(data, out bytesRead);
            byte[] header = new byte[bytesRead + (int)len];
            Buffer.BlockCopy(data, 0, header, 0, bytesRead + (int)len);
            return header;
        }

        public static byte[] HeaderPath(byte[] header)
        {
            byte[] lenBytes = new byte[10];
            int lenUL = 0;
            int bytesRead = (int)ReadUvarint(header, out lenUL);
            Buffer.BlockCopy(header, bytesRead, lenBytes, 0, lenUL);
            ulong len = ReadUvarint(lenBytes, out _);
            byte[] path = new byte[len];
            Buffer.BlockCopy(header, bytesRead + lenUL, path, 0, (int)len);
            return path;
        }

        private static ulong ReadUvarint(byte[] bytes, out int bytesRead)
        {
            ulong x = 0;
            int shift = 0;
            bytesRead = 0;
            foreach (byte b in bytes)
            {
                x |= (ulong)(b & 0x7F) << shift;
                shift += 7;
                bytesRead++;
                if ((b & 0x80) == 0)
                {
                    return x;
                }
            }
            throw new ArgumentException("Invalid uvarint");
        }
    }

    public static class PreambleUtils
    {
        public static long Write(Stream writer, byte[] preambleData, string[] preambleFormat = null)
        {
            string preambleFmt = "";
            if (preambleFormat != null && preambleFormat.Length > 0)
            {
                preambleFmt = preambleFormat[0].Trim();
            }
            if (string.IsNullOrEmpty(preambleFmt))
            {
                preambleFmt = "/raw";
            }
            else if (!preambleFmt.StartsWith("/"))
            {
                preambleFmt = "/" + preambleFmt;
            }
            if (!IsFormat(preambleFmt))
            {
                throw new ArgumentException("Invalid preamble format", nameof(preambleFormat));
            }
            byte[] header = Multicodec.Header(Encoding.ASCII.GetBytes(preambleFmt));
            byte[] sz = BitConverter.GetBytes((ulong)(header.Length + preambleData.Length));
            writer.Write(sz, 0, sz.Length);
            writer.Write(header, 0, header.Length);
            writer.Write(preambleData, 0, preambleData.Length);
            return sz.Length + header.Length + preambleData.Length;
        }

        public static (byte[], string, long) Read(Stream reader, bool noSeek, long? sizeLimit = null)
        {
            long origOff = reader.Position;
            if (!noSeek)
            {
                reader.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                if (origOff != 0)
                {
                    throw new ArgumentException("Read offset not zero", nameof(noSeek));
                }
            }
            long sl = sizeLimit ?? long.MaxValue;
            byte[] szBytes = new byte[10];
            int bytesRead = reader.Read(szBytes, 0, 10);
            if (bytesRead == 0)
            {
                throw new ArgumentException("Preamble size not found");
            }
            ulong sz = ReadUvarint(szBytes, out int szLen);
            if (sz == 0 || sz > (ulong)sl)
            {
                throw new ArgumentException("Invalid preamble size");
            }
            byte[] data = new byte[sz];
            bytesRead = reader.Read(data, 0, (int)sz);
            if (bytesRead == 0)
            {
                throw new ArgumentException("Preamble data not found");
            }
            byte[] header = Multicodec.ReadHeader(data, out int headerLen);
            if (header.Length == 0)
            {
                throw new ArgumentException("Preamble header not found");
            }
            string preambleFormat = Encoding.ASCII.GetString(Multicodec.HeaderPath(header));
            if (!IsFormat(preambleFormat))
            {
                throw new ArgumentException("Preamble header not found");
            }
            long preambleSize = reader.Position;
            if (!noSeek)
            {
                reader.Seek(origOff, SeekOrigin.Begin);
            }
            return (data, preambleFormat, preambleSize);
        }

        public static long Seek(Stream seeker, long preambleSize, long dataSize, long currOffset, long offset, SeekOrigin whence)
        {
            if (whence == SeekOrigin.Current)
            {
                offset += currOffset;
                whence = SeekOrigin.Begin;
            }
            else if (whence == SeekOrigin.End && dataSize >= 0)
            {
                offset += dataSize;
                whence = SeekOrigin.Begin;
            }
            if (whence == SeekOrigin.Begin)
            {
                if (offset == currOffset)
                {
                    return offset;
                }
                else if (offset < 0 || (dataSize >= 0 && offset > dataSize))
                {
                    throw new ArgumentException("Out of bounds");
                }
                offset += preambleSize;
            }
            long revertOff = seeker.Position;
            seeker.Seek(offset, whence);
            long off = seeker.Position;
            if (off < preambleSize)
            {
                seeker.Seek(revertOff, SeekOrigin.Begin);
                throw new ArgumentException("Out of bounds");
            }
            return off - preambleSize;
        }

        private static ulong ReadUvarint(byte[] bytes, out int bytesRead)
        {
            ulong x = 0;
            int shift = 0;
            bytesRead = 0;
            foreach (byte b in bytes)
            {
                x |= (ulong)(b & 0x7F) << shift;
                shift += 7;
                bytesRead++;
                if ((b & 0x80) == 0)
                {
                    return x;
                }
            }
            throw new ArgumentException("Invalid uvarint");
        }

        private static bool IsFormat(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length <= 1 || !s.StartsWith("/"))
            {
                return false;
            }
            foreach (char c in s.Substring(1))
            {
                if (!IsValidFormatSymbol(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsValidFormatSymbol(char c)
        {
            string formatSymbols = "abcdefghijklmnopqrstuvwxyz1234567890-_";
            return formatSymbols.Contains(c);
        }
    }

}