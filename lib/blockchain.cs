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
using SimpleBase;
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
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using Nethereum.JsonRpc.Client.RpcMessages;


namespace Eluvio
{
    public interface IBlockchainPrimitives
    {
        string Key { get; }

        Task<string> CreateContent(string contentTypeAddress, string libraryAddress);
        Task<string> CreateContentType();
        Task<string> CreateLibrary(string space);
        string MakeToken(string prefix, Dictionary<string, object> jsonToken);
        TransactionReceipt UpdateRequest(string contractAddress);
    }

    public class BlockchainPrimitives : IBlockchainPrimitives
    {
        readonly static string baseURL = "https://demov3.net955210.contentfabric.io/";

        static async Task<string> CallFunction(string url, string token, JArray metadata)
        {
            HttpClient client = new();

            // Set the authentication token in the request headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Create the request content with the metadata
            HttpContent content = new StringContent(metadata.ToString());
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Send the POST request to the specified URL

            HttpResponseMessage response = await client.PostAsync(url, content);

            // Handle the response
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "";
            }
        }

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

        public static async Task<string> CallEditContent(string token, string libid, string qid)
        {
            var url = BlockchainPrimitives.baseURL + String.Format("qlibs/{0}/q/{1}", libid, qid);
            Console.WriteLine("url = {0} token={1}", url, token);
            return await CallFunction(url, token, new JArray());
        }

        public static async Task<string> CallGetMetadata(string token, string libid, string qid)
        {
            var url = BlockchainPrimitives.baseURL + String.Format("qlibs/{0}/q/{1}/meta", libid, qid);
            return await CallRestApi(url, token);
        }
        public static async Task<string> UpdateMetadata(string token, string libid, string qid, JArray jsonUpdate)
        {
            var url = BlockchainPrimitives.baseURL + String.Format("qlibs/{0}/q/{1}/meta", libid, qid);
            return await CallFunction(url, token, jsonUpdate);
        }
        public static async Task<string> FinalizeContent(string token, string libid, string qwt)
        {
            var url = BlockchainPrimitives.baseURL + String.Format("qlibs/{0}/q/{1}/meta", libid, qwt);
            return await CallFunction(url, token, new JArray());
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
        public Nethereum.RPC.Eth.DTOs.TransactionReceipt UpdateRequest(string contractAddress)
        {
            BaseContentService cs = new(web3, contractAddress);
            var res = cs.UpdateRequestRequestAndWaitForReceiptAsync();
            res.Wait();
            return res.Result;
        }

        public Nethereum.RPC.Eth.DTOs.TransactionReceipt AccessRequest(string contractAddress)
        {
            BaseContentService cs = new(web3, contractAddress);
            var res = cs.AccessRequestRequestAndWaitForReceiptAsync(0,"","", new List<Byte[]>(), new List<string>());
            res.Wait();
            return res.Result;
        }        

        public static string FabricIdFromBlckchainAdress(string prefix, string bcAdress)
        {
            if (bcAdress[..2] == "0x")
            {
                bcAdress = bcAdress[2..];
            }
            return prefix + Base58.Bitcoin.Encode(BlockchainPrimitives.DecodeString(bcAdress));
        }

        public static string QIDFromBlockchainAddress(string bcAdress)
        {
            return FabricIdFromBlckchainAdress("iq__", bcAdress);
        }
        public static string SpaceFromBlockchainAddress(string bcAdress)
        {
            return FabricIdFromBlckchainAdress("ispc", bcAdress);
        }
        public static string LibFromBlockchainAddress(string bcAdress)
        {
            return FabricIdFromBlckchainAdress("ilib", bcAdress);
        }


        private static byte[] DecodeString(string val)
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

        private static string EncodeBytes(byte[] bytes)
        {
            string hexString = BitConverter.ToString(bytes).Replace("-", "");
            return "0x" + hexString;
        }

        private static byte[] SignMessage(EthECKey key, byte[] hashedBytes)
        {
            var signer = new EthereumMessageSigner();
            var ethECDSASignature = signer.SignAndCalculateV(hashedBytes, key);
            var signed = ethECDSASignature.CreateStringSignature();
            var decoded = DecodeString(signed);
            return decoded;
        }

        // private static bool Verify(byte[] signature, )
        // {

        // }
        public string MakeToken(string prefix, Dictionary<string, object> jsonToken)
        {
            tw ??= Console.Out;
            var ethECKey = new EthECKey(Key);
            jsonToken.Add("adr", ethECKey.GetPublicAddressAsBytes());
            var tok = JsonSerializer.Serialize(jsonToken);
            var strToken = tok;
            tw.WriteLine("token= " + strToken);
            byte[] hashedBytes = DecodeString(new Sha3Keccack().CalculateHash(strToken));
            tw.WriteLine(BitConverter.ToString(hashedBytes));//.Replace("-", ""));

            byte[] signature = Array.Empty<byte>();
            if (prefix[3] == 's')
            {
                signature = SignMessage(ethECKey, hashedBytes);
            }
            // // Signing
            byte[] concat = signature.Concat(Encoding.UTF8.GetBytes(strToken)).ToArray();

            string signatureString = prefix + Base58.Bitcoin.Encode(concat);
            tw.WriteLine("Signature: " + signatureString);

            return signatureString;

        }

        public async Task<string> CreateContentType()
        {
            var ct = await spaceService.CreateContentTypeRequestAndWaitForReceiptAsync();
            var cctReceipt = ct.DecodeAllEvents<CreateContentTypeEventDTO>();
            return cctReceipt[0].Event.ContentTypeAddress;
        }

        public async Task<string> CreateLibrary(string space)
        {
            // should be using space "0x501382E5f15501427D1Fc3d93e949C96b25A2224"
            var lib = await spaceService.CreateLibraryRequestAndWaitForReceiptAsync(space);
            var libReceipt = lib.DecodeAllEvents<CreateLibraryEventDTO>();
            return libReceipt[0].Event.LibraryAddress;
        }

        public async Task<string> CreateContent(string contentTypeAddress, string libraryAddress)
        {
            var content = await spaceService.CreateContentRequestAndWaitForReceiptAsync(libraryAddress, contentTypeAddress);
            var contentReceipt = content.DecodeAllEvents<CreateContentEventDTO>();

            return contentReceipt[0].Event.ContentAddress;
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
