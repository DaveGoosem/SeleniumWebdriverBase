using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver_Utility;

namespace SeleniumWebdriver.Websites.Creative_404.Pages
{
    class LoginPage : Page
    {
        private IWebDriver _driver;
        public string emailValidationMessage = "Your email address is required.";
        public string passwordValidationMessage = "A password is required.";

        //set up/define locators for all elements you are going to use in your test.
        [FindsBy(How = How.ClassName, Using = "form-button")]
        private IWebElement _loginButton;

        [FindsBy(How = How.Id, Using = "LoginForm_TxtPassword")]
        private IWebElement _PasswordInputBox;

        [FindsBy(How = How.Id, Using = "LoginForm_TxtUserName")]
        private IWebElement _emailInputBox;

        [FindsBy(How = How.Id, Using = "LoginForm_EmailNotNullValidator")]
        private IWebElement _emailValidationText;

        [FindsBy(How = How.Id, Using = "LoginForm_PasswordNotNullValidator")]
        private IWebElement _passwordValidationText;
        

        public LoginPage(IWebDriver driver) 
            : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        //define all of your commands as functions. There should be none of these in your acutal tests. You should just call these functions as you need them.
        public void ClickLoginButton()
        {
            _loginButton.Click();
        }

        public void inputEmailAdressText(string emailText)
        {
            _emailInputBox.Clear();
            _emailInputBox.SendKeys(emailText);
        }

        public bool CheckEmailValidationExists()
        {
            return Utility.IsThisElementPresent(_driver, By.Id("LoginForm_EmailNotNullValidator"));
        }

        public bool LoginFormExistsCheck()
        {
            return (Utility.IsThisElementPresent(_driver, By.Id("LoginForm_TxtPassword")) &&
                    Utility.IsThisElementPresent(_driver, By.Id("LoginForm_TxtUserName")) &&
                    Utility.IsThisElementPresent(_driver, By.ClassName("form-button")));
        }


    }
}
