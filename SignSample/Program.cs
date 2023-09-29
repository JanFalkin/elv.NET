using Eluvio;
using System.Text;

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
        var lib = bcp.CreateLibrary("0x501382E5f15501427D1Fc3d93e949C96b25A2224");
        lib.Wait();
        var libid = BlockchainPrimitives.LibFromBlockchainAddress(lib.Result);
        Console.WriteLine("lib = {0} fab addrs {1}", lib.Result, libid);
        var content = bcp.CreateContent(ct.Result, lib.Result);
        Console.WriteLine("content = {0} QID = {1}", content.Result, BlockchainPrimitives.QIDFromBlockchainAddress(content.Result));

        var res = bcp.AccessRequest(content.Result);
        var qid = BlockchainPrimitives.QIDFromBlockchainAddress(content.Result);
        // tw.WriteLine("Public Address: " + ethECKey.GetPublicAddress());
        byte[] txhBytes = Encoding.UTF8.GetBytes(res.TransactionHash[2..]);
        Dictionary<string, object> updateJson = new()
                {
                    { "spc", BlockchainPrimitives.SpaceFromBlockchainAddress("0x501382E5f15501427D1Fc3d93e949C96b25A2224") },
                    { "txh", Convert.ToBase64String(txhBytes) }
                };
        var token = bcp.MakeToken("atxsj_", updateJson);
        Console.WriteLine(" Token = {0} \n content = {1}\n fabid = {2}", token, content.Result, qid);
        var ec = BlockchainPrimitives.CallEditContent(token, libid, qid);
        ec.Wait();
        Console.WriteLine(String.Format("Edit returns: status {0} result {1}", ec.Status, ec.Result));
    }
}
