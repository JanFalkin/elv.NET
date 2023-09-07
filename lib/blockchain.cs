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


namespace Eluvio
{
    public class BlockchainPrimitives
    {


        private void commonConstruct(string url, string contractAddress)
        {
            account = new Account(this.Key);
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
        public async Task<string> MakeToken(string spaceID)
        {
            var tx = await UpdateRequest();
            // var adr = new EthECKey(Key).GetPubKey();
            var ethECKey = new EthECKey(new EthECKey(Key).GetPubKey(), true);
            var adr = ethECKey.GetPublicAddress();
            var txh = tx.TransactionHash.Substring(2);
            byte[] txhBytes = Enumerable.Range(0, txh.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(txh.Substring(x, 2), 16))
                     .ToArray();
            var jsonToken = new
            {
                txh = Convert.ToBase64String(txhBytes),
                adr = Convert.ToBase64String(Encoding.UTF8.GetBytes(adr.Substring(2))),
                spc = "ispc" + Base58Check.Base58CheckEncoding.Encode(Encoding.UTF8.GetBytes(spaceID)),
            };
            var strToken = JsonSerializer.Serialize(jsonToken);
            Console.WriteLine("token= " + strToken);

            byte[] hashedBytes = HashString(strToken);
            // Signing
            byte[] signature = SignString(hashedBytes);
            string signatureString = "ascpj" + Base58Check.Base58CheckEncoding.Encode(signature);
            Console.WriteLine("Signature: " + signatureString);

            // Verification
            bool isVerified = VerifySignature(hashedBytes, signature);
            Console.WriteLine("Signature Verification: " + isVerified);

            return signatureString;

        }

        private byte[] HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                return sha256.ComputeHash(inputBytes);
            }
        }

        private byte[] SignString(byte[] inputBytes)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                var ethECKey = new EthECKey(Key);
                // Get the necessary components from EthECKey
                var signature = ethECKey.Sign(inputBytes);
                // Convert the 64-byte signature to a 58-byte format
                return signature.ToDER();
                // return EthECDSASignatureFactory.ToEthECDSASignature(signature).ToDER();
            }
        }

        private bool VerifySignature(byte[] inputBytes, byte[] signature)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Replace with the corresponding public key
                var ethECKey = new EthECKey(Key);
                EthECDSASignature eds = EthECDSASignature.FromDER(signature);
                return ethECKey.Verify(inputBytes, eds);
            }
        }

        public string Key { get; private set; }
        private Account account;
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
