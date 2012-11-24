using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System;

namespace SeleniumWebdriver
{
    public class BaseSetup
    {
        private FirefoxProfile _ffp;
        private IWebDriver _driver;

        private static TimeSpan _defaultTimeSpan = new TimeSpan(0, 0, 15);
        public static string WebBrowser { get; set; }

        public static TimeSpan DriverTimeout
        {
            get { return _defaultTimeSpan; }
            set { _defaultTimeSpan = value; }
        }

        public static bool _debugMode = false;

        public static bool DebugModeOn
        {
            get
            {
                string isDebugOn = ConfigurationManager.AppSettings["Settings_DebugMode"];

                if (isDebugOn == "on") _debugMode = true;
                return _debugMode;

            }

            set { _debugMode = value; }
        }

        public IWebDriver StartBrowser()
        {

            WebBrowser = ConfigurationManager.AppSettings["Settings_Browser"];

            switch (WebBrowser)
            {
                case "firefox":
                    _ffp = new FirefoxProfile();
                    _ffp.AcceptUntrustedCertificates = true;
                    _driver = new FirefoxDriver(_ffp);
                    break;
                case "iexplore":
                    _driver = new InternetExplorerDriver();
                    break;
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
            }

            string timeoutSeconds = ConfigurationManager.AppSettings["Settings_Timeout"];
            int iTimeoutSeconds;

            if (Int32.TryParse(timeoutSeconds, out iTimeoutSeconds)) { DriverTimeout = new TimeSpan(0,0,0,iTimeoutSeconds); }
            
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(DriverTimeout.TotalSeconds));

            return _driver;

        }
    }
}