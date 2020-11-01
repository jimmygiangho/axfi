using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenio.Core.SUT;
using Selenio.Extensions;
using System.Linq;
using System.Threading;

namespace JimmySelenium.Pages
{
    public class SponsorConfirmation : PageObject
    {

        [FindsBy(How = How.XPath, Using = ".//h1[contains(text(), 'Sponsor Confirmation')]")]
        public IWebElement sponsorConfirmationHeader { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(text(), 'Yes, I want to assign this sponsor')]")]
        public IWebElement YesButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(text(), 'No, I want a different one')]")]
        public IWebElement NoButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='sponsor-info']/p[1]")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='sponsor-info']/p[2]/span")]
        public IWebElement Id { get; set; }

        public SponsorConfirmation WaitForScreenToLoad(IWebElement element = null)
        {
            this.WaitForScreen(element ?? sponsorConfirmationHeader);
            return this;
        }



        public SponsorConfirmation ClickYesOnSponsorConfirmationPopUp()
        {
            JimmyDriver.Signup.Driver.SwitchTo().ActiveElement();
            JimmyDriver.SponsorConfirmation.WaitForScreenToLoad();
            JimmyDriver.SponsorConfirmation.YesButton.Click();
            return this;
        }


    }
}
