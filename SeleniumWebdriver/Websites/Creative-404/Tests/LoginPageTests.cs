using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver;
using SeleniumWebdriver.Websites.Creative_404.Pages;

namespace SeleniumWebdriver.Websites.Cretive_404.Tests
{
    [TestFixture]
    public class LoginPageTests : BaseSetup
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private string _baseURL = "";

        //Using this as well as [SetUp] so we don't need to open a new browser for each test.
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _driver = StartBrowser();
        }

        //Using this as well as [TearDown] so we don't need to open a new browser for each test.
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _driver.Quit();
        }


        [SetUp]
        public void SetupTest()
        {
            //usually you would have start a new browser code in here too. This can be moved from [TestFixtureSetup] if you need it to beahve this way.
            //Grab the baseURL from the config file.
            _baseURL = ConfigurationManager.AppSettings["Creative-404"];
            _loginPage = new LoginPage(_driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            //only need code in here if you want each test to close the browser after finishing. It will run faster if you don't do this but there may be a reaosn you do want to do so.
            //move it here from the [TestFixtureTearDown] section.
        }



        /* 
         * All test code should just pull things from the 'Page' associated with the tests and no actual standard selenium locate element code
         * should appear in a 'Test' file. This ensures there's no repitition as the page has been objectified in all ways required.
         * If you need to perform an action, there should be a relevant function on the associated Page file
         */

        [Test(Description = "Test to check email validation is triggered on an empty login form submission")]
        public void CheckEmptyLoginFormSubmissions()
        {
            bool formFoundSuccess = false;
            bool validationMessageExists = false;
            _driver.Navigate().GoToUrl(_baseURL + "account/login.aspx");
            if (_loginPage.LoginFormExistsCheck())
            {
                formFoundSuccess = true;
                _loginPage.ClickLoginButton();

                if (_loginPage.CheckEmailValidationExists())
                {
                    validationMessageExists = true;
                    Assert.IsTrue(validationMessageExists, _loginPage.emailValidationMessage);
                }
                Assert.IsTrue(validationMessageExists, "Was not able to find any validation messages on the Login page.");
            }
            Assert.IsTrue(formFoundSuccess, "Was not able to find the Login form on the Login page.");
        }


    }
}
