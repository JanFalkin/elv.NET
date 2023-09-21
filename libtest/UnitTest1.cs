using Eluvio;
using Nethereum.ABI.Util;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Util;
using NethereumSample.BaseContent.ContractDefinition;
using System.Diagnostics;
using SimpleBase;

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
                BlockchainPrimitives bcp = new("0x4f3e910d1e438582dc520d8bd7c4ca43c92f50ee660b1a090bd8e237b7a102fc", "https://host-76-74-28-235.contentfabric.io/eth/", "0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3", TestContext.Progress);
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
                Debug.WriteLine(string.Format("Token Update = {0}", tupdate.Result));
                tupdate.Wait();
                var tupdateu = bcp.MakeToken("ascuj_", jupdate2);
                Debug.WriteLine(string.Format("Token Update = {0}", tupdateu.Result));
                tupdate.Wait();
                Dictionary<string, object> jsonTxn = new()
            {
                { "spc", $"ispc{spaceID}" },
            };
                var t = bcp.MakeToken("atxsj_", jsonTxn);
                t.Wait();
                //Assert.AreNotEqual(t.Result, null);
                Debug.WriteLine(string.Format("Token = {0}", t.Result));
                Dictionary<string, object> jsonU = new()
            {
                { "spc", $"ispc{spaceID}" },
            };
                var tl = bcp.MakeToken("atxuj_", jsonU);
                tl.Wait();
                Debug.WriteLine(string.Format("Token u = {0}", tl.Result));
            }
            catch (Exception e)
            {
                Console.WriteLine("e = {0}", e);
                Assert.Fail();
            }

            //
        }

        [Test]
        public void TestContent()
        {
            try
            {
                BlockchainPrimitives bcp = new("0x4f3e910d1e438582dc520d8bd7c4ca43c92f50ee660b1a090bd8e237b7a102fc", "https://host-76-74-28-235.contentfabric.io/eth/", "0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3", TestContext.Progress);
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var ct = bcp.CreateContentType();
                ct.Wait();
                TestContext.Progress.WriteLine("content type = {0}", ct.Result);
                var lib = bcp.CreateLibrary("0x501382E5f15501427D1Fc3d93e949C96b25A2224");
                lib.Wait();
                TestContext.Progress.WriteLine("lib = {0} fab addrs {1}", lib.Result, BlockchainPrimitives.LibFromBlockchainAddress(lib.Result));
                var content = bcp.CreateContent(ct.Result, lib.Result);
                TestContext.Progress.WriteLine("content = {0} QID = {1}", content.Result, BlockchainPrimitives.QIDFromBlockchainAddress(content.Result));
                Assert.Multiple(() =>
                {
                    Assert.That(content.IsCompletedSuccessfully);
                    Assert.That(content.Result, Is.Not.EqualTo(""));
                });
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
