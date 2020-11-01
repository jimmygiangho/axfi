using System.Configuration;


namespace JimmySelenium.Support
{
    public static class AutoConfig
    {
        public static string SeneGence_signin_Url => ConfigurationManager.AppSettings["SeneGence_signin_Url"];

    }
}
