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
using System.Net.Http.Headers;
using System.Text;
using Base58Check;
using Nethereum.Util;
using System.Reflection.Metadata.Ecma335;
using Nethereum.Model;
using Nethereum.ABI.Util;
using Nethereum.RLP;
using Nethereum.Contracts.TransactionHandlers;
using ADRaffy.ENSNormalize;
using Nethereum.Hex.HexTypes;
using Elv.NET.Contracts.BaseLibrary;
using Elv.NET.Contracts.BaseContentSpace;
using Nethereum.RPC.Eth.DTOs;
using Elv.NET.Contracts.BaseContentSpace.ContractDefinition;
using Nethereum.Contracts;

namespace Eluvio
{
    public class BlockchainPrimitives
    {

        static async Task<string> CallRestApi(string url, string token)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // Process the response data as needed
                Console.WriteLine(responseBody);
                return responseBody;
            }
            else
            {
                Console.WriteLine("API request failed with status code: " + response.StatusCode);
            }
            return "";
        }

        static async Task<string> CallEditContent(string token)
        {
            return await CallRestApi("https://host-76-74-91-7.contentfabric.io/doc?redirected=true#create-draft-content-with-id".ToString(), token);
        }

        static async Task<string> CallGetMetadata(string token)
        {
            return await CallRestApi("https://host-76-74-91-7.contentfabric.io/doc?redirected=true#get-metadata-subtree".ToString(), token);
        }
        static async Task<string> UpdateMetadata(string token)
        {
            return await CallRestApi("https://host-76-74-91-7.contentfabric.io/doc?redirected=true#replace-metadata-subtree".ToString(), token);
        }
        static async Task<string> FinalizeContent(string token)
        {
            return await CallRestApi("https://host-76-74-91-7.contentfabric.io/doc?redirected=true#finalize-draft-content".ToString(), token);
        }


        private void CommonConstruct(string url, string contractAddress)
        {
            account = new Nethereum.Web3.Accounts.Account(this.Key);
            web3 = new Web3(this.account, url);
            contractHandler = web3.Eth.GetContractHandler(contractAddress);
            cldto = contractHandler.GetEvent<Elv.NET.Contracts.BaseContentSpace.ContractDefinition.CreateLibraryEventDTO>();
            contentService = new BaseContentService(web3, contractAddress);
            libService = new BaseLibraryService(web3, contractAddress);
            spaceService = new BaseContentSpaceService(web3, contractAddress);
            string abiFilePath = "/home/jan/ELV/elv.NET/lib/abi/BaseContentSpace.abi"; // Replace with the path to your ABI file
            string abiContent = File.ReadAllText(abiFilePath);
            contract = web3.Eth.GetContract(abiContent, contractAddress);

        }
        public BlockchainPrimitives(string url, string contractAddress)
        {
            Key = EthECKey.GenerateKey().GetPrivateKeyAsBytes().ToHex();
            CommonConstruct(url, contractAddress);
        }
        public BlockchainPrimitives(string key, string url, string contractAddress, TextWriter tw = null)
        {
            Key = key;
            CommonConstruct(url, contractAddress);
            this.tw = tw;
        }
        public async Task<Nethereum.RPC.Eth.DTOs.TransactionReceipt> UpdateRequest()
        {
            var res = await contentService.UpdateRequestRequestAndWaitForReceiptAsync();
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
            byte[] txhBytes = Encoding.UTF8.GetBytes(tx.BlockHash[2..]);

            if (prefix[..3] == "atx")
            {
                jsonToken.Add("txh", Convert.ToBase64String(txhBytes));
            }
            jsonToken.Add("adr", Convert.ToBase64String(adr));
            var strToken = JsonSerializer.Serialize(jsonToken);
            Console.WriteLine("token= " + strToken);
            byte[] message = Encoding.UTF8.GetBytes(strToken);

            byte[] signature = Array.Empty<byte>();
            if (prefix[3] == 's')
            {
                var signer = new EthereumMessageSigner();
                var hashedStr = HashString(strToken);
                var sigStr = signer.Sign(Encoding.UTF8.GetBytes(hashedStr), ethECKey)[2..];
                Console.WriteLine("Signature: " + sigStr);
                signature = Hexify(sigStr);
                var addressRec1 = signer.EncodeUTF8AndEcRecover(hashedStr, sigStr);
                Console.WriteLine("Address from Recover: " + addressRec1);
            }
            // // Signing
            byte[] concat = signature.Concat(message).ToArray();

            string signatureString = prefix + SimpleBase.Base58.Bitcoin.Encode(concat);
            Console.WriteLine("Signature: " + signatureString);

            return signatureString;

        }

        public async Task<string> CreateContent()
        {
            var ct = await spaceService.CreateContentTypeRequestAndWaitForReceiptAsync();
            var cctReceipt = ct.DecodeAllEvents<CreateContentTypeEventDTO>();

            var lib = await spaceService.CreateLibraryRequestAndWaitForReceiptAsync("0x501382E5f15501427D1Fc3d93e949C96b25A2224");
            var libReceipt = lib.DecodeAllEvents<CreateLibraryEventDTO>();

            var content = await spaceService.CreateContentRequestAndWaitForReceiptAsync(libReceipt[0].Event.LibraryAddress, cctReceipt[0].Event.ContentTypeAddress);
            var contentReceipt = content.DecodeAllEvents<CreateContentEventDTO>();

            return contentReceipt[0].Event.ContentAddress;
        }


        private static string HashString(string input)
        {
            return Sha3Keccack.Current.CalculateHash(input);
        }


        public string Key { get; private set; }
        private Nethereum.Web3.Accounts.Account account;
        private Web3 web3;
        private Nethereum.Contracts.ContractHandlers.ContractHandler contractHandler;
        private BaseContentService contentService;
        private BaseLibraryService libService;

        private BaseContentSpaceService spaceService;
        private Nethereum.Contracts.Event<Elv.NET.Contracts.BaseContentSpace.ContractDefinition.CreateLibraryEventDTO> cldto;
        private Nethereum.Contracts.Contract contract;
        private TextWriter tw;

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
