using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CommonGo;
using Base58Check;
using Preamble;
using NethereumSample.BaseContent.ContractDefinition;

namespace CommonGo.Format
{
    public enum Code : byte
    {
        UNKNOWN = 0,
        Q,
        QPart,
        QPartLive,
        QPartLiveTransient
    }

    public static class CodeExtensions
    {
        public static bool IsLive(this Code code)
        {
            return code == Code.QPartLive || code == Code.QPartLiveTransient;
        }
    }

    public enum Format : byte
    {
        Unencrypted = 0,
        AES128AFGH
    }

    public struct Type
    {
        public Code Code { get; set; }
        public Format Format { get; set; }

        public bool IsNil()
        {
            if (Code == Code.UNKNOWN)
            {
                return true;
            }
            return false;
        }
    }

    public static class TypeExtensions
    {
        private static readonly string[] codeDescriptions = { "unknown", "content", "content part", "live content part", "transient live content part" };
        private static readonly string[] formatDescriptions = { "unencrypted", "encrypted with AES-128, AFGHG BLS12-381, 1 MB block size" };

        public static string Describe(this Type type)
        {
            string codeDesc = codeDescriptions[(int)type.Code];
            string formatDesc = formatDescriptions[(int)type.Format];
            return $"{codeDesc}, {formatDesc}";
        }
    }

    public class Hash
    {
        public Type Type { get; set; }
        public byte[] Digest { get; set; }
        public long Size { get; set; }
        public long PreambleSize { get; set; }
        public CommonGo.ID ID { get; set; }
        public DateTime Expiration { get; set; }
        private string s;

        public Hash()
        {
            Type = new Type();
            Digest = new byte[0];
            Size = 0;
            PreambleSize = 0;
            ID = new CommonGo.ID();
            Expiration = DateTime.MinValue;
            s = string.Empty;
        }

        public Hash(Type htype, byte[] digest, Int64 sz, CommonGo.ID id)
        {
            Type = htype;
            Digest = digest;
            Size = sz;
            ID = id;
            Expiration = DateTime.MinValue;
            s = string.Empty;
        }

        public Hash(Type htype, byte[] digest, Int64 sz, Int64 preambleSize)
        {
            Type = htype;
            Digest = digest;
            Size = sz;
            PreambleSize = preambleSize;
            Expiration = DateTime.MinValue;
            s = string.Empty;
        }

        public bool IsNil()
        {
            return Type.Code == Code.UNKNOWN;
        }

        public bool IsLive()
        {
            return Type.Code.IsLive();
        }

        public void AssertType(Type t)
        {
            if (IsNil() || Type.Code != t.Code || Type.Format != t.Format)
            {
                throw new ArgumentException("Hash type doesn't match");
            }
        }

        public void AssertCode(Code c)
        {
            if (Type.Code != c)
            {
                throw new ArgumentException("Hash code doesn't match");
            }
        }

        public void AssertFormat(Format f)
        {
            if (Type.Format != f)
            {
                throw new ArgumentException("Hash format doesn't match");
            }
        }

        public override string ToString()
        {
            if (IsNil())
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(s) && Digest.Length > 0)
            {
                byte[] b;
                if (!IsLive())
                {
                    b = new byte[Digest.Length];
                    Array.Copy(Digest, b, Digest.Length);
                    byte[] sBytes = Encoding.ASCII.GetBytes(Size.ToString());
                    b = ConcatArrays(b, sBytes);
                    if (Type.Code == Code.QPart && PreambleSize > 0)
                    {
                        byte[] pBytes = Encoding.ASCII.GetBytes(PreambleSize.ToString());
                        b = ConcatArrays(b, pBytes);
                    }
                    else if (Type.Code == Code.Q && ID.IsValid())
                    {
                        b = ConcatArrays(b, ID.Bytes());
                    }
                }
                else
                {
                    b = new byte[0];
                    if (!Expiration.Equals(DateTime.MinValue))
                    {
                        long expirationUnixTime = (long)(Expiration - new DateTime(1970, 1, 1)).TotalSeconds;
                        byte[] eBytes = Encoding.ASCII.GetBytes(expirationUnixTime.ToString());
                        b = ConcatArrays(b, eBytes);
                    }
                    b = ConcatArrays(b, Digest);
                }

                s = $"{TypeToPrefix(Type)}{Base58Check.Base58CheckEncoding.Encode(b)}";
            }

            return s;
        }

        private static byte[] ConcatArrays(byte[] a, byte[] b)
        {
            byte[] result = new byte[a.Length + b.Length];
            Array.Copy(a, result, a.Length);
            Array.Copy(b, 0, result, a.Length, b.Length);
            return result;
        }

        private static string TypeToPrefix(Type type)
        {
            string prefix = string.Empty;
            bool found = false;
            if (!type.IsNil())
            {
                found = prefixToType.TryGetValue(type, out prefix);
            }

            if (!found)
            {
                prefixToType.TryGetValue(new Type { Code = Code.UNKNOWN, Format = Format.Unencrypted }, out prefix);
            }

            return prefix;
        }

        // private static string Base58Encode(byte[] bytes)
        // {
        //     const string alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        //     BigInteger value = new BigInteger(bytes.Reverse().ToArray());
        //     StringBuilder sb = new StringBuilder();
        //     while (value > 0)
        //     {
        //         value = BigInteger.DivRem(value, 58, out BigInteger remainder);
        //         sb.Insert(0, alphabet[(int)remainder]);
        //     }
        //     foreach (byte b in bytes)
        //     {
        //         if (b != 0)
        //         {
        //             break;
        //         }
        //         sb.Insert(0, '1');
        //     }
        //     return sb.ToString();
        // }

        private static readonly Dictionary<Type, string> prefixToType = new Dictionary<Type, string>
        {
            { new Type { Code = Code.UNKNOWN, Format = Format.Unencrypted }, "hunk" },
            { new Type { Code = Code.Q, Format = Format.Unencrypted }, "hq__" },
            { new Type { Code = Code.QPart, Format = Format.Unencrypted }, "hqp_" },
            { new Type { Code = Code.QPart, Format = Format.AES128AFGH }, "hqpe" },
            { new Type { Code = Code.QPartLive, Format = Format.Unencrypted }, "hql_" },
            { new Type { Code = Code.QPartLive, Format = Format.AES128AFGH }, "hqle" },
            { new Type { Code = Code.QPartLiveTransient, Format = Format.Unencrypted }, "hqt_" },
            { new Type { Code = Code.QPartLiveTransient, Format = Format.AES128AFGH }, "hqte" }
        };
    }

    public class Digest : HashAlgorithm
    {
        private HashAlgorithm hashAlgorithm;
        private Preamble.Sizer preamble;
        private Type htype;
        private CommonGo.ID id;
        private long size;
        private long preambleSize;

        public Digest(HashAlgorithm hashAlgorithm, Type t)
        {
            this.hashAlgorithm = hashAlgorithm;
            preamble = new Preamble.Sizer();
            htype = t;
        }

        public override void Initialize()
        {
            // Not sure what's needed but it was abstract
        }

        public long Size()
        {
            return size;
        }
        public long PreambleSize()
        {
            return preambleSize;
        }

        public Hash AsHash()
        {
            byte[] b = Hash;
            Hash h;
            if (htype.Code == Code.Q)
            {
                h = new Hash(htype, b, size, id);
            }
            else
            {
                h = new Hash(htype, b, size, 4); //REVIEW
            }
            if (h == null)
            {
                throw new ArgumentException("Invalid hash");
            }
            return h;
        }

        public Digest WithPreamble(long preambleSize)
        {
            if (htype.Code == Code.QPart)
            {
                if (preambleSize > 0)
                {
                    this.preambleSize = preambleSize;
                }
                else
                {
                    preambleSize = preamble.Size();
                }
            }
            else
            {
                throw new ArgumentException("Preamble not applicable", nameof(htype.Code));
            }

            return this;
        }

        public Digest WithID(CommonGo.ID i)
        {
            if (htype.Code == Code.Q)
            {
                id = i;
            }

            return this;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            hashAlgorithm.TransformBlock(array, ibStart, cbSize, null, 0);

            if (htype.Code == Code.QPart)
            {
                preamble.Write(array, ibStart, cbSize);
            }

            size += cbSize;
        }

        protected override byte[] HashFinal()
        {
            hashAlgorithm.TransformFinalBlock(new byte[0], 0, 0);
            byte[] hashBytes = hashAlgorithm.Hash;
            Hash hash;
            if (htype.Code == Code.Q)
            {
                hash = new Hash
                {
                    Type = htype,
                    Digest = hashBytes,
                    Size = size,
                    ID = id
                };
            }
            else
            {
                hash = new Hash
                {
                    Type = htype,
                    Digest = hashBytes,
                    Size = size,
                    PreambleSize = preambleSize
                };
            }

            return Encoding.ASCII.GetBytes(hash.ToString());
        }
    }

    public static class HashUtils
    {
        public static Hash CalcHash(Stream reader, long? size = null)
        {
            Digest digest = new Digest(SHA256.Create(), new Type { Code = Code.QPart, Format = Format.Unencrypted });

            long preambleSize = 0;
            if (size.HasValue)
            {
                (byte[] _, string _, long preambleSize2) = PreambleUtils.Read(reader, false, (int)size.Value);
                preambleSize = preambleSize2;
            }
            else
            {
                (byte[] _, string _, long preambleSize2) = PreambleUtils.Read(reader, false);
                preambleSize = preambleSize2;
            }

            byte[] buffer = new byte[128 * 1024];
            int bytesRead;
            while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                digest.TransformBlock(buffer, 0, bytesRead, null, 0);
            }

            if (preambleSize > 0)
            {
                digest.WithPreamble(preambleSize);
            }

            digest.TransformFinalBlock(new byte[0], 0, 0);
            byte[] hashBytes = digest.Hash;
            Hash hash = new Hash
            {
                Type = new Type { Code = Code.QPart, Format = Format.Unencrypted },
                Digest = hashBytes,
                Size = digest.Size(),
                PreambleSize = digest.PreambleSize()
            };

            return hash;
        }
    }
}