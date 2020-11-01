using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using Selenio.Core.Reporting;

namespace JimmySelenium
{
    [TestFixture]
    public class MasterTestClass
    {
        public IReporter Reporter;


        [SetUp]
        public void Setup()
        {
            JimmyDriver.Initialize<ChromeDriver>();
            Reporter = JimmyDriver.Reporter;
        }

        [TearDown]
        public void Teardown()
        {
            JimmyDriver.Reporter.FinishTest(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed, TestContext.CurrentContext.Result.Message);
            JimmyDriver.Driver?.Quit();
        }
    }
}
