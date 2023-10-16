using Eluvio;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Elv.NET.Contracts.BaseContentSpace;
using NethereumSample.BaseContent;
using Nethereum.Contracts;
using System.Globalization;
using System.Text;
using Nethereum.ABI.Util;

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
                BlockchainPrimitives bcp = new(pwd, "https://host-76-74-28-235.contentfabric.io/eth/", "0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3", "0x0a5bc8d97be691970df876534a3433901fafe5d9", "0x76d5287501f6d8e3b72AA34545C9cbf951702C74");
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

        static string MakeUpper(string s)
        {
            StringBuilder result = new();
            CultureInfo culture = CultureInfo.InvariantCulture;

            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    result.Append(char.ToUpper(c, culture));
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
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
                BlockchainPrimitives bcp = new(pwd, "https://host-76-74-28-235.contentfabric.io/eth/", "0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3", "0x0a5bc8d97be691970df876534a3433901fafe5d9", "0x76d5287501f6d8e3b72AA34545C9cbf951702C74");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var spaceService = new BaseContentSpaceService(bcp.web3, bcp.baseContract);

                var ct = "0x0a5bc8d97be691970df876534a3433901fafe5d9";
                TestContext.Progress.WriteLine("content type = {0}", ct);
                var libAddress = "0x76d5287501f6d8e3b72AA34545C9cbf951702C74";
                var libid = BlockchainUtils.LibFromBlockchainAddress(libAddress);
                var content = BlockchainUtils.CreateContent(spaceService, ct, libAddress);
                content.Wait();
                TestContext.Progress.WriteLine("content = {0} QID = {1}", content.Result, BlockchainUtils.QIDFromBlockchainAddress(content.Result));
                Assert.Multiple(() =>
                {
                    Assert.That(content.IsCompletedSuccessfully);
                    Assert.That(content.Result, Is.Not.EqualTo(""));
                });
                var newContentService = new BaseContentService(bcp.web3, content.Result);
                var res = newContentService.UpdateRequestRequestAndWaitForReceiptAsync();
                res.Wait();
                var qid = BlockchainUtils.QIDFromBlockchainAddress(content.Result);
                Console.WriteLine(String.Format("transaction hash = {0}", res.Result.TransactionHash));
                byte[] txhBytes = BlockchainUtils.DecodeString(res.Result.TransactionHash);
                Dictionary<string, object> updateJson = new()
                {
                    { "spc", BlockchainUtils.SpaceFromBlockchainAddress("0x9b29360efb1169c801bbcbe8e50d0664dcbc78d3") },
                    { "txh", Convert.ToBase64String(txhBytes) }
                };
                var token = bcp.MakeToken("atxsj_", updateJson);
                Console.WriteLine(" Token = {0} \n content = {1}\n fabid = {2}", token, content, qid);
                var ec = bcp.CallEditContent(token, libid, qid);
                ec.Wait();
                Console.WriteLine(String.Format("Edit returns: content {0}", ec));
                JObject ecValues = JObject.Parse(ec.Result);
                Assert.That(ecValues, Is.Not.Null);
                Assert.That(ecValues["write_token"], Is.Not.Null);
                var qwt = ecValues["write_token"].ToString();
                Assert.That(qwt, Is.Not.Empty);
                Console.WriteLine("write_token = {0}", qwt);
                string newMeta = "{\"key1\":{\"subkey1\":[\"value1\", \"value2\", \"value3\"]}}";

                var um = bcp.UpdateMetadata(token, libid, qwt, JObject.Parse(newMeta));
                um.Wait();

                var fin = bcp.FinalizeContent(token, libid, qwt);
                fin.Wait();
                Console.WriteLine("finalized output = {0}", fin);
                JObject finVals = JObject.Parse(fin.Result);
                Assert.That(finVals, Is.Not.Null);
                Assert.That(finVals["hash"], Is.Not.Null);
                var hash = finVals["hash"].ToString();

                var decHash = BlockchainUtils.BlockchainFromFabric(hash);
                Assert.That(decHash[2..], Is.EqualTo(MakeUpper(content.Result[2..])));
                // decHash == content
                Console.WriteLine("hash = {0} dec = {1}", hash, decHash);
                var commitService = new BaseContentService(bcp.web3, decHash);

                var commitReceipt = BlockchainUtils.Commit(commitService, hash);
                var cpe = commitReceipt.Logs.DecodeAllEvents<Elv.NET.Contracts.BaseContentSpace.ContractDefinition.CommitPendingEventDTO>();
                if (cpe.Count > 0)
                {
                    Console.WriteLine("commitReceipt tx hash = {0}, tx idx {1}, hash pending {2}", commitReceipt.TransactionHash, commitReceipt.TransactionIndex, cpe[0].Event.ObjectHash);
                }
                else
                {
                    Console.WriteLine("commitReceipt status = {0}, No Events", commitReceipt.Status);
                }
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
