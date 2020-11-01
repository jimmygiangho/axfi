using JimmySelenium.Support;
using NUnit.Framework;
using System;


namespace JimmySelenium
{
    [TestFixture]
    public class JimmyScripts : MasterTestClass
    {
      
        [Test]
        public void SeneGenceDistributorSignup()


        {
            try
            {
                Reporter.TestDescription = "Validate Valid DistributorSignup";

                Reporter.TestStep = "Go to SeneGence DistributorSignup Page";
                JimmyDriver.Signup.Open();
                
                Reporter.TestStep = "SearchBySponsorDistId ";
                JimmyDriver.Signup.SearchBySponsorDistId();                         
                
                Reporter.TestStep = "ClickYesOnSponsorConfirmationPopUp";
                JimmyDriver.SponsorConfirmation.ClickYesOnSponsorConfirmationPopUp();

                Reporter.TestStep = "ClickContinue";
                JimmyDriver.Signup.ClickContinue();

                Reporter.TestStep = "SelectContry";
                JimmyDriver.Signup.SelectContry("United Stated");

                Reporter.TestStep = "Enter Email";
                JimmyDriver.Signup.email.SetText(JimmyHelpers.GetRandomText() + "@yomail.com");

                Reporter.TestStep = "Enter Comany";
                JimmyDriver.Signup.comapny.SetText(JimmyHelpers.GetRandomText()+ "Company");

                Reporter.TestStep = "Enter mobilePhone";
                JimmyDriver.Signup.mobilePhone.SetText(JimmyHelpers.GetRandomNumber());

                Reporter.TestStep = "Enter otherPhone";
                JimmyDriver.Signup.phone.SetText(JimmyHelpers.GetRandomNumber());
                                                
                Reporter.TestStep = "EntertaxID";
                //Need to use a new SNN/taxID
                JimmyDriver.Signup.EntertaxID();

                Reporter.TestStep = "Enter Fill name";
                JimmyDriver.Signup.EnterFullName();

                Reporter.TestStep = "Enter DoB abd check age confirmation check box";
                JimmyDriver.Signup.EnterDoB();

                Reporter.TestStep = "Set password";
                JimmyDriver.Signup.SetPassword();

                Reporter.TestStep = "Click On Continue button";
                JimmyDriver.Signup.ClickOnContinueButtom();

                Reporter.TestStep = "Click On Continue button";
                JimmyDriver.Signup.ClickOnContinueButtom();

                Reporter.TestStep = "Enter Shipping address";
                JimmyDriver.Signup.EnterShippingAddress();

                Reporter.TestStep = "Click On Continue button";
                JimmyDriver.Signup.ClickOnContinueButtom();

                Reporter.TestStep = "Accept DistributorPoliciesProcedures";
                JimmyDriver.Signup.AcceptDistributorPoliciesProcedures();

                Reporter.TestStep = "Accept AcceptMinimumAdvertisedPricePolicy";
                JimmyDriver.Signup.AcceptMinimumAdvertisedPricePolicy();
                
                Reporter.TestStep = "Verify SubmittButton is now and Enabled";
                JimmyDriver.Signup.Wait.Until(ExpectedConditions.ElementIsEnabled(JimmyDriver.Signup.SubmittButton));
                Assert.AreEqual(true, JimmyDriver.Signup.SubmittButton.Enabled, "SubmittButton is not enabled");
                    
            }

            catch (Exception e)

            {
                Reporter.StatusUpdate(e.ToString(), false);
            }


        }

       
    }
}