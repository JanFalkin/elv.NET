using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NethereumSample.BaseContent;
using Nethereum.KeyStore;
using Nethereum.KeyStore.Crypto;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Crypto.Prng;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
using Base58Check;
using Nethereum.Util;
using Nethereum.Signer;
using System.Reflection.Metadata.Ecma335;
using Nethereum.Model;
using Nethereum.ABI.Util;
using Nethereum.RLP;
using ADRaffy.ENSNormalize;
using Nethereum.Hex.HexTypes;

namespace Eluvio
{
    public class BlockchainPrimitives
    {


        private void commonConstruct(string url, string contractAddress)
        {
            account = new Nethereum.Web3.Accounts.Account(this.Key);
            web3 = new Web3(this.account, url);
            contractHandler = web3.Eth.GetContractHandler(contractAddress);
            contentService = new BaseContentService(web3, contractAddress);

        }
        public BlockchainPrimitives(string url, string contractAddress)
        {
            this.Key = EthECKey.GenerateKey().GetPrivateKeyAsBytes().ToHex();
            commonConstruct(url, contractAddress);
        }
        public BlockchainPrimitives(string key, string url, string contractAddress)
        {
            this.Key = key;
            commonConstruct(url, contractAddress);
        }
        public async Task<Nethereum.RPC.Eth.DTOs.TransactionReceipt> UpdateRequest()
        {
            var res = await this.contentService.UpdateRequestRequestAndWaitForReceiptAsync();
            return res;
        }

        private static byte[] Hexify(string val)
        {
            if (val[0] == '0' && val[1] == 'x')
            {
                val = val[2..];
            }
            return Enumerable.Range(0, val.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(val.Substring(x, 2), 16))
                     .ToArray();
        }
        public async Task<string> MakeToken(string prefix, Dictionary<string, object> jsonToken)
        {
            var tx = await UpdateRequest();
            var ethECKey = new EthECKey(Key);
            var adr = ethECKey.GetPublicAddressAsBytes();
            Console.WriteLine("Public Address: " + ethECKey.GetPublicAddress());
            var txh = tx.TransactionHash;
            byte[] txhBytes = Hexify(txh);

            if (prefix == "atxsj_")
            {
                jsonToken.Add("txh", Convert.ToBase64String(txhBytes));
            }
            jsonToken.Add("adr", Convert.ToBase64String(adr));
            var strToken = JsonSerializer.Serialize(jsonToken);
            Console.WriteLine("token= " + strToken);
            byte[] message = Encoding.UTF8.GetBytes(strToken);

            var signer = new EthereumMessageSigner();
            var hashedStr = HashString(strToken);
            var sigStr = signer.Sign(hashedStr, Key)[2..];
            Console.WriteLine("Signature: " + sigStr);
            byte[] signature = Hexify(sigStr);


            // // Signing
            byte[] concat = signature.Concat(message).ToArray();

            string signatureString = prefix + SimpleBase.Base58.Bitcoin.Encode(concat);
            Console.WriteLine("Signature: " + signatureString);

            return signatureString;

        }

        private static byte[] HashString(string input)
        {
            return Encoding.UTF8.GetBytes(Sha3Keccack.Current.CalculateHash(input));
        }


        public string Key { get; private set; }
        private Nethereum.Web3.Accounts.Account account;
        private Web3 web3;
        private Nethereum.Contracts.ContractHandlers.ContractHandler contractHandler;
        private BaseContentService contentService;

    }


    public class BlockchainOperations
    {
        void CreateContentObject()
        {

        }
        void DeleteContentObject()
        {

        }
        void AccessRequest(string library_id, string object_id, bool update = true)
        {

        }
        void CommitVersion(string library_id, string object_id, string version_hash)
        {

        }
    }

    public class Tokens
    {
        void CreateUpdateTxToken()
        {

        }
        void CreateAccessTxToken()
        {

        }
        void CreateCliengSignedAccessToken()
        {

        }
        void CreateEditorSignedAccessToken()
        {

        }
    }

}
