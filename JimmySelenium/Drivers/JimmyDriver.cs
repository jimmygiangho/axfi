using JimmySelenium.Pages;
using JimmySelenium.Reports;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenio.Core.SUT;
using Selenio.HtmlReporter;
using System.Diagnostics;

namespace JimmySelenium
{
    public class JimmyDriver : SUTDriver 
    {
        
        public static void Initialize<T>() where T : IWebDriver
        {   string assemblyLocation = TestContext.CurrentContext.TestDirectory;
            string methodName = TestContext.CurrentContext.Test.MethodName;
            string className = TestContext.CurrentContext.Test.ClassName;
            string[] browsers = { "chrome", "firefox", "iexplore", "MiJimmyosoftEJimmye" };

            foreach (string b in browsers)
            { Process[] localByName = Process.GetProcessesByName(b);

                foreach (Process item in localByName)
                {
                    item.Kill();
                }

            }
            
            InitDriver<T>(new Reporter(new ReportSettingsProvider(), assemblyLocation, className, methodName));
           
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
        }

        //Jimmy Pages
        #region Jimmy Pages 

        public static Signup Signup => GetPage<Signup>();

        public static SponsorConfirmation SponsorConfirmation => GetPage<SponsorConfirmation>();

       



        #endregion





    }
}
