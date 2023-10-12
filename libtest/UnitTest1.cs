using Eluvio;
using Nethereum.ABI.Util;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Util;
using NethereumSample.BaseContent.ContractDefinition;
using System.Diagnostics;
using SimpleBase;
using System.Text;

namespace libtest
{
    public class Tests
    {

        [SetUpFixture]
        public class SetupTrace
        {

            [OneTimeSetUp]
            public void StartTest()
            {

            }

            [OneTimeTearDown]
            public void EndTest()
            {
                Trace.Flush();
            }
        }

        [Test]
        public void TestToken()
        {
            try
            {
                string? pwd = Environment.GetEnvironmentVariable("CHAIN_PASS");
                if (pwd == null)
                {
                    Assert.Fail("Need a password!!");
                }
                BlockchainPrimitives bcp = new(pwd, "https://host-76-74-28-235.contentfabric.io/eth/", "0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Debug.WriteLine(string.Format("MyFunkyKey = {0}", bcp.Key));
                var spaceID = "66699ab88";
                Dictionary<string, object> jsonUpdate = new()
            {
                { "spc", "ispc" + spaceID },
                {"qid",  "iq__777666555ABCDEF"},
                {"sub", "subject007"},
                {"iat", -1},
                {"gra", "update"},
                {"exp", -1},
            };
                Dictionary<string, object> jupdate2 = new()
            {
                { "spc", "ispc" + spaceID },
                {"qid",  "iq__777666555ABCDEF"},
                {"sub", "subject007"},
                {"iat", -1},
                {"gra", "update"},
                {"exp", -1},
            };
                var tupdate = bcp.MakeToken("ascsj_", jsonUpdate);
                TestContext.Progress.WriteLine(string.Format("Token Update = {0}", tupdate));
                var tupdateu = bcp.MakeToken("ascuj_", jupdate2);
                TestContext.Progress.WriteLine(string.Format("Token Update = {0}", tupdateu));
                Dictionary<string, object> jsonTxn = new()
            {
                { "spc", $"ispc{spaceID}" },
            };
                var t = bcp.MakeToken("atxsj_", jsonTxn);
                //Assert.AreNotEqual(t.Result, null);
                TestContext.Progress.WriteLine(string.Format("Token = {0}", t));
                Dictionary<string, object> jsonU = new()
            {
                { "spc", $"ispc{spaceID}" },
            };
                var tl = bcp.MakeToken("atxuj_", jsonU);
                TestContext.Progress.WriteLine(string.Format("Token u = {0}", tl));
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("e = {0}", e);
                Assert.Fail();
            }

            //
        }

        [Test]
        public void TestContent()
        {
            try
            {
                string? pwd = Environment.GetEnvironmentVariable("CHAIN_PASS");
                if (pwd == null)
                {
                    Assert.Fail("Need a password!!");
                }
                BlockchainPrimitives bcp = new(pwd, "https://host-76-74-28-235.contentfabric.io/eth/", "0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var ct = bcp.CreateContentType();
                ct.Wait();
                TestContext.Progress.WriteLine("content type = {0}", ct.Result);
                var lib = bcp.CreateLibrary("0x501382E5f15501427D1Fc3d93e949C96b25A2224");
                lib.Wait();
                TestContext.Progress.WriteLine("lib = {0} fab addrs {1}", lib.Result, BlockchainUtils.LibFromBlockchainAddress(lib.Result));
                var content = bcp.CreateContent(ct.Result, lib.Result);
                TestContext.Progress.WriteLine("content = {0} QID = {1}", content.Result, BlockchainUtils.QIDFromBlockchainAddress(content.Result));
                Assert.Multiple(() =>
                {
                    Assert.That(content.IsCompletedSuccessfully);
                    Assert.That(content.Result, Is.Not.EqualTo(""));
                });

                var res = bcp.UpdateRequest(content.Result);
                var qid = BlockchainUtils.QIDFromBlockchainAddress(content.Result);
                // tw.WriteLine("Public Address: " + ethECKey.GetPublicAddress());
                byte[] txhBytes = Encoding.UTF8.GetBytes(res.TransactionHash[2..]);
                Dictionary<string, object> updateJson = new()
                {
                    { "spc", BlockchainUtils.SpaceFromBlockchainAddress("0x501382E5f15501427D1Fc3d93e949C96b25A2224") },
                    { "txh", Convert.ToBase64String(txhBytes) }
                };
                var token = bcp.MakeToken("atxsj_", updateJson);
                TestContext.Progress.WriteLine(" Token = {0} \n content = {1}\n fabid = {2}", token, content.Result, qid);
                //BlockchainPrimitives.

            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("ERROR e= {0}", e);
                Assert.Fail();
            }

            //
        }

    }
}
