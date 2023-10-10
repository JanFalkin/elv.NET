using Eluvio;
using Elv.NET.Contracts.BaseContentSpace.ContractDefinition;
using NethereumSample.BaseContent;
using Nethereum.Contracts;
using SimpleBase;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using NethereumSample.BaseContent.ContractDefinition;

namespace SignSample;

class Program
{
    static void Main(string[] args)
    {
        string? pwd = Environment.GetEnvironmentVariable("CHAIN_PASS");
        if (pwd == null)
        {
            Console.WriteLine("Need a password!!");
            return;
        }

        BlockchainPrimitives bcp = new(pwd, "https://host-76-74-28-235.contentfabric.io/eth/", "0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3", Console.Out);
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var ct = bcp.CreateContentType();
        ct.Wait();
        Console.WriteLine("content type = {0}", ct.Result);
        // var lib = bcp.CreateLibrary("0x501382E5f15501427D1Fc3d93e949C96b25A2224");
        // lib.Wait();
        var libAddress = "0x76d5287501f6d8e3b72AA34545C9cbf951702C74";
        var libid = BlockchainPrimitives.LibFromBlockchainAddress(libAddress);
        // Console.WriteLine("lib = {0} fab addrs {1}", lib.Result, libid);
        var content = bcp.CreateContent(ct.Result, libAddress);
        content.Wait();
        Console.WriteLine("content = {0} QID = {1}", content.Result, BlockchainPrimitives.QIDFromBlockchainAddress(content.Result));
        var newContentService = new BaseContentService(bcp.web3, content.Result);


        var res = newContentService.UpdateRequestRequestAndWaitForReceiptAsync();
        res.Wait();
        var qid = BlockchainPrimitives.QIDFromBlockchainAddress(content.Result);
        // tw.WriteLine("Public Address: " + ethECKey.GetPublicAddress());
        Console.WriteLine(String.Format("transaction hash = {0}", res.Result.TransactionHash));
        byte[] txhBytes = BlockchainPrimitives.DecodeString(res.Result.TransactionHash);
        Dictionary<string, object> updateJson = new()
                {
                    { "spc", BlockchainPrimitives.SpaceFromBlockchainAddress("0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3") },
                    { "txh", Convert.ToBase64String(txhBytes) }
                };
        var token = bcp.MakeToken("atxsj_", updateJson);
        Console.WriteLine(" Token = {0} \n content = {1}\n fabid = {2}", token, content.Result, qid);
        var ec = bcp.CallEditContent(token, libid, qid);
        ec.Wait();
        Console.WriteLine(String.Format("Edit returns: status {0} result {1} exception {2}", ec.Status, ec.Result, ec.Exception));
        JObject ecValues = JObject.Parse(ec.Result);
        var qwt = ecValues["write_token"].ToString();
        Console.WriteLine("write_token = {0}", qwt);
        string newMeta = "{\"key1\":{\"subkey1\":[\"value1\", \"value2\", \"value3\"]}}";

        var um = bcp.UpdateMetadata(token, libid, qwt, JObject.Parse(newMeta));
        um.Wait();

        var fin = bcp.FinalizeContent(token, libid, qwt);
        fin.Wait();
        Console.WriteLine("finalized output = {0}", fin.Result);
        JObject finVals = JObject.Parse(fin.Result);
        var hash = finVals["hash"].ToString();

        var decHash = BlockchainPrimitives.BlockchainFromFabric(hash);
        Console.WriteLine("hash = {0} dec = {1}", hash, decHash);
        var commitService = new BaseContentService(bcp.web3, decHash);

        var commitReceipt = bcp.Commit(commitService, decHash);
        Console.WriteLine("commitReceipt status = {0}, {1}", commitReceipt.Status, commitReceipt);

    }
}
