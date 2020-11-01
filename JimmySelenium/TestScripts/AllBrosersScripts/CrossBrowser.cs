using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenio.Core.Reporting;


namespace JimmySelenium
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class CrossBrowser<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public IReporter Reporter;

        [SetUp]
        public void Setup()
        {
            JimmyDriver.Initialize<TWebDriver>();
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