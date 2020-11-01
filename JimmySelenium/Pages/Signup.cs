using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using JimmySelenium.Support;
using Selenio.Core.SUT;
using Selenio.Extensions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace JimmySelenium.Pages
{
    public class Signup : PageObject
    {

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='sponsorDistId']")]
        public IWebElement sponsorDistId { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='sponsorZip']")]
        public IWebElement sponsorZip { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='sponsorFirstName']")]
        public IWebElement sponsorFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='sponsorLastName']")]
        public IWebElement sponsorLastName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ng-select[@formcontrolname='sponsorCountry']")]
        public IWebElement sponsorCountry { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ng-select[@formcontrolname='sponsorState']")]
        public IWebElement sponsorState { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='sponsorCity']")]
        public IWebElement sponsorCity { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='button-group']/button")]
        public IWebElement continueButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@id ='account-individual']")]
        public IWebElement accountIndividualCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@id ='account-business']")]
        public IWebElement accountBusinessCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ng-select[@formcontrolname ='country']/div/div[2]/span")]
        public IWebElement country { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ng-select[@formcontrolname ='country']/div/ul/li[1]")]
        public IWebElement countryUS { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='company']")]
        public IWebElement comapny { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='taxId']")]
        public IWebElement taxId { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='firstName']")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='middleName']")]
        public IWebElement middleName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='lastName']")]
        public IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder ='MM/DD/YYYY']")]
        public IWebElement DoB { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'I confirm that I am 18 years of age or older')]")]
        public IWebElement ageConfirmationCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='email']")]
        public IWebElement email { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='mobilePhone']")]
        public IWebElement mobilePhone { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='phone']")]
        public IWebElement phone { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='textMessages']")]
        public IWebElement textMessagesCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='password']")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='confirmPassword']")]
        public IWebElement confirmPassword { get; set; }

        //Shipping

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='name']")]
        public IWebElement shippingBizName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='addressLine1']")]
        public IWebElement shippingAddressLine1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='addressLine2']")]
        public IWebElement shippingAddressLine2 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname='city']")]
        public IWebElement shippingCity { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ng-select[@formcontrolname='state']")]
        public IWebElement shippingState { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ng-select[@formcontrolname ='state']/div/ul/li[5]")]
        public IWebElement shippingStateCA { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@formcontrolname ='zip']")]
        public IWebElement shippingZip { get; set; }

        //Accetp terms

        [FindsBy(How = How.XPath, Using = ".//button[contains(text(), 'Distributor Policies')]")]
        public IWebElement DistributorPoliciesProcedures { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(text(), 'Minimum Advertised')]")]
        public IWebElement MinimumAdvertisedPricePolicy { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(text(), 'Accept')]")]
        public IWebElement AcceptButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//h1[@class ='legal-agreement-header']")]
        public IWebElement LegalDocHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'I acknowledge that I have read and understood the Minimum Advertised Price Policy.')]")]
        public IWebElement acknowledgeCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'agree-terms-conditions')]")]
        public IWebElement agreeTermsConditionsCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(text(), 'Submit Order')]")]
        public IWebElement SubmittButton { get; set; }

        public Signup WaitForScreenToLoad(IWebElement element = null)
        {
            this.WaitForScreen(element ?? sponsorDistId);
            return this;
        }

        public Signup Open(string url = null)
        {
            Driver.Url = url ?? AutoConfig.SeneGence_signin_Url;
            JimmyDriver.Signup.WaitForScreenToLoad();
            return this;
        }

        public Signup SearchBySponsorDistId(string Id = null)
        {
            JimmyDriver.Signup.sponsorDistId.SetText(Id ?? "734339" + Keys.Enter);
            return this;
        }

        public Signup ClickContinue()
        {
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.continueButton);
            JimmyDriver.Signup.continueButton.Click();
            return this;
        }

        public Signup SelectContry(string country = "United States")
        {

            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.country);
            JimmyDriver.Signup.country.Click();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.countryUS);
                      
            JimmyDriver.Signup.countryUS.Click();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.comapny);
            return this;
        }

        public Signup EntertaxID(string Id = null)
        {
            //this is good SSN 242542525
            JimmyDriver.Signup.taxId.SetText(Id ?? "242542525" + Keys.Tab);
            return this;
        }

        public Signup EnterFullName(string firstName = null, string middleName = null, string lastName = null)

        {
            JimmyDriver.Signup.firstName.SetText(firstName ??JimmyHelpers.GetRandomText());
            JimmyDriver.Signup.middleName.SetText(JimmyHelpers.GetRandomText());
            JimmyDriver.Signup.lastName.SetText(lastName ?? JimmyHelpers.GetRandomText());

            return this;
        }

        public Signup EnterDoB()

        {
            JimmyDriver.Signup.DoB.SetText("01/01/2001" + Keys.Tab);
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.ageConfirmationCheckbox);
            JimmyDriver.Signup.ageConfirmationCheckbox.Click();
            
            return this;
        }

        public Signup SetPassword(string password = null)

        {
            string pw = "P@44word" + JimmyHelpers.GetRandomText();
            
            JimmyDriver.Signup.password.SetText(password ?? pw);
            JimmyDriver.Signup.confirmPassword.SetText(password ?? pw);

            return this;
        }

        public Signup ClickOnContinueButtom()

        {
            JimmyDriver.Signup.Wait.Until(ExpectedConditions.ElementIsEnabled(JimmyDriver.Signup.continueButton));
            JimmyDriver.Signup.continueButton.Click();

            return this;
        }

        public Signup EnterShippingAddress()

        {
            JimmyDriver.Signup.Wait.Until(ExpectedConditions.ElementIsEnabled(JimmyDriver.Signup.shippingBizName));
            JimmyDriver.Signup.shippingAddressLine1.SetText(JimmyHelpers.GetRandomNumber(4) +" " + JimmyHelpers.GetRandomText() + " Street");
            JimmyDriver.Signup.shippingCity.SetText(JimmyHelpers.GetRandomText() + " City");
            JimmyDriver.Signup.shippingState.Click();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.shippingState);
            JimmyDriver.Signup.shippingStateCA.Click();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.shippingZip);
            JimmyDriver.Signup.shippingZip.SetText("90210");
            return this;
        }

        public Signup AcceptDistributorPoliciesProcedures()
        {
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.DistributorPoliciesProcedures);
            JimmyDriver.Signup.DistributorPoliciesProcedures.Click();
            JimmyDriver.Signup.Driver.SwitchTo().ActiveElement();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.LegalDocHeader);
            JimmyHelpers.ScrollIntoView(JimmyDriver.Signup.AcceptButton);            
            JimmyDriver.Signup.AcceptButton.Click();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.SubmittButton);
            return this;
        }

        public Signup AcceptMinimumAdvertisedPricePolicy()
        {
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.MinimumAdvertisedPricePolicy);
            JimmyDriver.Signup.MinimumAdvertisedPricePolicy.Click();
            JimmyDriver.Signup.Driver.SwitchTo().ActiveElement();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.LegalDocHeader);
            JimmyHelpers.ScrollIntoView(JimmyDriver.Signup.acknowledgeCheckbox);

            JimmyDriver.Signup.acknowledgeCheckbox.Click();
            JimmyDriver.Signup.WaitForScreenToLoad(JimmyDriver.Signup.SubmittButton);
            return this;
        }
    }
}
