using Eluvio;
using Nethereum.Hex.HexConvertors.Extensions;
using System.Diagnostics;

namespace libtest;

public class Tests
{

    [SetUpFixture]
    public class SetupTrace
    {
        [OneTimeSetUp]
        public void StartTest()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            Trace.Flush();
        }
    }

    [Test]
    public void Test1()
    {
        try
        {
            BlockchainPrimitives bcp = new Eluvio.BlockchainPrimitives("0x4f3e910d1e438582dc520d8bd7c4ca43c92f50ee660b1a090bd8e237b7a102fc", "https://host-76-74-28-235.contentfabric.io/eth/", "0xc05e0274158442b7d595e5ac6d483d18df8fc93e");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Debug.WriteLine(string.Format("MyFunkyKey = {0}", bcp.Key));
            var t = bcp.MakeToken("66699ab88");
            t.Wait();
            Assert.AreNotEqual(t.Result, null);
            Debug.WriteLine(string.Format("Token = {0}", t.Result));
        }
        catch (Exception e)
        {
            Console.WriteLine("e = {0}", e);
            Assert.Fail();
        }

        //
    }
}