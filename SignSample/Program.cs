using Eluvio;
using NethereumSample.BaseContent;
using Nethereum.Contracts;
using Newtonsoft.Json.Linq;
using McMaster.Extensions.CommandLineUtils;

namespace SignSample;

class Program
{
    static async Task<bool> DoSampleAsync(BlockchainPrimitives bcp)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var ct = "0x0a5bc8d97be691970df876534a3433901fafe5d9";
        Console.WriteLine("content type = {0}", ct);
        var libAddress = "0x76d5287501f6d8e3b72AA34545C9cbf951702C74";
        var libid = BlockchainUtils.LibFromBlockchainAddress(libAddress);
        // Console.WriteLine("lib = {0} fab addrs {1}", lib.Result, libid);
        var content = await bcp.CreateContent(ct, libAddress);
        Console.WriteLine("content = {0} QID = {1}", content, BlockchainUtils.QIDFromBlockchainAddress(content));
        var newContentService = new BaseContentService(bcp.web3, content);


        var res = await newContentService.UpdateRequestRequestAndWaitForReceiptAsync();
        var qid = BlockchainUtils.QIDFromBlockchainAddress(content);
        // tw.WriteLine("Public Address: " + ethECKey.GetPublicAddress());
        Console.WriteLine(String.Format("transaction hash = {0}", res.TransactionHash));
        byte[] txhBytes = BlockchainUtils.DecodeString(res.TransactionHash);
        Dictionary<string, object> updateJson = new()
                {
                    { "spc", BlockchainUtils.SpaceFromBlockchainAddress("0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3") },
                    { "txh", Convert.ToBase64String(txhBytes) }
                };
        var token = bcp.MakeToken("atxsj_", updateJson);
        Console.WriteLine(" Token = {0} \n content = {1}\n fabid = {2}", token, content, qid);
        var ec = await bcp.CallEditContent(token, libid, qid);
        Console.WriteLine(String.Format("Edit returns: content {0}", ec));
        JObject ecValues = JObject.Parse(ec);
        var qwt = ecValues["write_token"].ToString();
        Console.WriteLine("write_token = {0}", qwt);
        string newMeta = "{\"key1\":{\"subkey1\":[\"value1\", \"value2\", \"value3\"]}}";

        var um = await bcp.UpdateMetadata(token, libid, qwt, JObject.Parse(newMeta));

        var fin = await bcp.FinalizeContent(token, libid, qwt);
        Console.WriteLine("finalized output = {0}", fin);
        JObject finVals = JObject.Parse(fin);
        var hash = finVals["hash"].ToString();

        var decHash = BlockchainUtils.BlockchainFromFabric(hash);
        Console.WriteLine("hash = {0} dec = {1}", hash, decHash);
        var commitService = new BaseContentService(bcp.web3, decHash);

        var commitReceipt = bcp.Commit(commitService, hash);
        var cpe = commitReceipt.Logs.DecodeAllEvents<Elv.NET.Contracts.BaseContentSpace.ContractDefinition.CommitPendingEventDTO>();
        if (cpe.Count > 0)
        {
            Console.WriteLine("commitReceipt tx hash = {0}, tx idx {1}, hash pending {2}", commitReceipt.TransactionHash, commitReceipt.TransactionIndex, cpe[0].Event.ObjectHash);
        }
        else
        {
            Console.WriteLine("commitReceipt status = {0}, No Events", commitReceipt.Status);
        }
        return true;
    }
    static int DoSample(string pwd, string ep, string contractAddr)
    {
        try
        {
            BlockchainPrimitives bcp = new(pwd, ep, contractAddr);
            var f = DoSampleAsync(bcp);
            f.Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine("exception {0}", e);
            return -1;
        }
        return 0;
    }
    static void Main(string[] args)
    {
        var app = new CommandLineApplication();

        app.HelpOption();

        var passwordOption = app.Option("-p|--pwd <PASSWORD>", "The password", CommandOptionType.SingleValue);
        var endpoint = app.Option("-e|--ep <EndPoint>", "eth endpoint eg https://host-76-74-28-235.contentfabric.io/eth/", CommandOptionType.SingleValue);
        var contractAdress = app.Option("-c|--contract <Contract>", "Contract address eg \"0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3\"", CommandOptionType.SingleValue);

        app.OnExecute(() =>
        {
            string? password = passwordOption.Value();

            if (string.IsNullOrEmpty(password))
            {
                password = Environment.GetEnvironmentVariable("CHAIN_PASS");
                if (password == null)
                {
                    Console.WriteLine("Need a password!!");
                    return -1;
                }
            }
            else
            {
                Console.WriteLine($"Password provided: {password}");
            }

            string? ep = endpoint.Value();

            if (string.IsNullOrEmpty(ep))
            {
                Console.WriteLine("Need an endpoint!!");
                return -1;
            }
            else
            {
                Console.WriteLine($"Endpoint provided: {ep}");
            }

            string? contractAddr = contractAdress.Value();

            if (string.IsNullOrEmpty(contractAddr))
            {
                Console.WriteLine("Need an contract address!!");
                return -1;
            }
            else
            {
                Console.WriteLine($"Contract Address provided: {contractAddr}");
            }

            return DoSample(password, ep, contractAddr);
        });

        app.Execute(args);

    }
}
