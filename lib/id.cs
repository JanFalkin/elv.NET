using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Base58Check;


namespace CommonGo
{
    public enum Code : byte
    {
        UNKNOWN = 0,
        Account,
        User,
        QLib,
        Q,
        QStateStore,
        QSpace,
        QFileUpload,
        QFilesJob,
        QNode,
        Network,
        KMS,
        CachedResultSet,
        Tenant,
        Group,
        Key,
        Ed25519
    }

    public static class CommonGo
    {
        private static readonly Dictionary<Code, string> codeToPrefix = new Dictionary<Code, string>()
        {
            { Code.UNKNOWN, "iukn" },
            { Code.Account, "iacc" },
            { Code.User, "iusr" },
            { Code.QLib, "ilib" },
            { Code.Q, "iq__" },
            { Code.QStateStore, "iqss" },
            { Code.QSpace, "ispc" },
            { Code.QFileUpload, "iqfu" },
            { Code.QFilesJob, "iqfj" },
            { Code.QNode, "inod" },
            { Code.Network, "inet" },
            { Code.KMS, "ikms" },
            { Code.CachedResultSet, "icrs" },
            { Code.Tenant, "iten" },
            { Code.Group, "igrp" },
            { Code.Key, "ikey" },
            { Code.Ed25519, "ied2" }
        };

        private static readonly Dictionary<string, Code> prefixToCode = codeToPrefix.ToDictionary(kv => kv.Value, kv => kv.Key);

        private static readonly Dictionary<Code, string> codeToName = new Dictionary<Code, string>()
        {
            { Code.UNKNOWN, "unknown" },
            { Code.Account, "account" },
            { Code.User, "user" },
            { Code.QLib, "content library" },
            { Code.Q, "content" },
            { Code.QStateStore, "content state store" },
            { Code.QSpace, "content space" },
            { Code.QFileUpload, "content file upload" },
            { Code.QFilesJob, "content files job" },
            { Code.QNode, "fabric node" },
            { Code.Network, "network" },
            { Code.KMS, "KMS" },
            { Code.CachedResultSet, "cached result set" },
            { Code.Tenant, "tenant" },
            { Code.Group, "group" },
            { Code.Key, "key" },
            { Code.Ed25519, "ed25519 public key" }
        };

        public class ID : List<byte>
        {
            public ID(byte[] bytes) : base(bytes.ToList()) { }
            public ID()
            {
            }
            public Code GetCode()
            {
                if (this.IsNil())
                {
                    return Code.UNKNOWN;
                }
                return (Code)this[0];
            }

            public bool IsNil()
            {
                return this.Count == 0;
            }

            public bool IsValid()
            {
                return this.Count > 1;
            }

            public bool Is(string s)
            {
                ID sID;
                try
                {
                    sID = FromString(s);
                }
                catch
                {
                    return false;
                }
                return this.SequenceEqual(sID);
            }

            public bool Equal(ID other)
            {
                return this.SequenceEqual(other);
            }

            public bool Equivalent(ID other)
            {
                return this.Bytes().SequenceEqual(other.Bytes());
            }

            public ID As(Code c)
            {
                var buf = new byte[this.Count];
                this.CopyTo(buf, 0);
                buf[0] = (byte)c;
                return new ID(buf);
            }

            public byte[] Bytes()
            {
                if (this.IsNil())
                {
                    return null;
                }
                return this.Skip(1).ToArray();
            }

            public override string ToString()
            {
                if (this.Count <= 1)
                {
                    return "";
                }
                return this.prefix() + Base58Check.Base58CheckEncoding.Encode(this.Bytes());
            }

            private string prefix()
            {
                string p;
                if (!codeToPrefix.TryGetValue(this.GetCode(), out p))
                {
                    codeToPrefix.TryGetValue(Code.UNKNOWN, out p);
                }
                return p;
            }

            public string MarshalText()
            {
                return this.ToString();
            }

            public static ID Generate(Code code)
            {
                var id = new ID();
                id.Add((byte)code);
                id.AddRange(Guid.NewGuid().ToByteArray());
                return id;
            }

            public static ID FromString(string s)
            {
                ID id;
                if (!Parse(s, out id))
                {
                    throw new Exception("Failed to parse ID");
                }
                return id;
            }

            public static bool Parse(string s, out ID id)
            {
                id = null;
                if (string.IsNullOrEmpty(s) || s.Length <= 4)
                {
                    return false;
                }
                string prefix = s.Substring(0, 4);
                Code code;
                if (!prefixToCode.TryGetValue(prefix, out code))
                {
                    return false;
                }
                string base58Data = s.Substring(4);
                byte[] data;
                try
                {
                    data = Base58Check.Base58CheckEncoding.Decode(base58Data);
                }
                catch
                {
                    return false;
                }
                id = new ID();
                id.Add((byte)code);
                id.AddRange(data);
                return true;
            }

            public static ID MustParse(string s)
            {
                ID id;
                if (!Parse(s, out id))
                {
                    throw new Exception("Failed to parse ID");
                }
                return id;
            }
        }

        public static string FormatId(string id, Code idType)
        {
            ID qid;
            try
            {
                qid = ID.FromString(id);
                return "0x" + BitConverter.ToString(qid.Bytes()).Replace("-", string.Empty);
            }
            catch
            {
                string hexPrefix = "0x";
                if (id.StartsWith(hexPrefix))
                {
                    id = id.Substring(hexPrefix.Length);
                }
                byte[] data;
                try
                {
                    data = Enumerable.Range(0, id.Length)
                                     .Where(x => x % 2 == 0)
                                     .Select(x => Convert.ToByte(id.Substring(x, 2), 16))
                                     .ToArray();
                }
                catch
                {
                    throw new Exception("Failed to parse ID");
                }
                qid = new ID();
                qid.Add(0);
                qid.AddRange(data);
                return qid.As(idType).ToString();
            }
        }

        public static ID FromStringValidate(string s, Code valCode)
        {
            ID id;
            try
            {
                id = ID.FromString(s);
            }
            catch
            {
                throw new Exception("Failed to parse ID");
            }
            if (id.GetCode() != valCode)
            {
                throw new Exception("Invalid code");
            }
            return id;
        }

        public static Code CodeFromPrefix(string maybePrefix)
        {
            Code maybeCode;
            if (!prefixToCode.TryGetValue(maybePrefix.ToLower(), out maybeCode))
            {
                maybeCode = Code.UNKNOWN;
            }
            return maybeCode;
        }
    }
}