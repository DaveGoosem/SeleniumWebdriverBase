using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumWebdriver_Utility;

namespace SeleniumWebdriver
{
    public static class CommonLibrary
    {
        #region "Standardised XPath locators"

        private const string txtUsernameXPath = "//*[contains(@id, 'txtUsername')][1]";
        private const string txtPasswordXPath = "//*[contains(@id, 'txtPassword')][1]";
        private const string btnSubmitXPath = "//*[contains(@id, 'btnSubmit')][1]";
        private const string btnLogoutXPath = "//*[contains(@id, 'btnLogout')][1]"; 

        #endregion

        #region "Link Methods"

        public static bool LinkClickAndFindText(IWebDriver driver, IWebElement linkToClick, string textToFind)
        {
            linkToClick.SendKeys(Keys.Enter);

            return Utility.IsTextPresent(driver, textToFind);
        }

        public static bool LinkClickAndFindTitle(IWebDriver driver, IWebElement linkToClick, string titleToFind)
        {
            linkToClick.SendKeys(Keys.Enter);

            return Utility.IsTitlePresent(driver, titleToFind);
        } 

        #endregion

        #region "Login Methods"

        public static bool FillOutLoginForm(IWebDriver driver, string username, string password, IWebElement submitButton = null, IWebElement usernameField = null, IWebElement passwordField = null)
        {
            try
            {
                if (usernameField == null && driver.FindElements(By.XPath(txtUsernameXPath)).Count > 0)
                    usernameField = driver.FindElement(By.XPath(txtUsernameXPath));
                if (passwordField == null && driver.FindElements(By.XPath(txtPasswordXPath)).Count > 0)
                    passwordField = driver.FindElement(By.XPath(txtPasswordXPath));
                if (submitButton == null && driver.FindElements(By.XPath(btnSubmitXPath)).Count > 0)
                    submitButton = driver.FindElement(By.XPath(btnSubmitXPath));

                if (usernameField != null && passwordField != null && submitButton != null)
                {
                    usernameField.SendKeys(username);
                    passwordField.SendKeys(password);
                    submitButton.SendKeys(Keys.Enter);

                    return true;
                }

                return false;

            }
            catch (IllegalLocatorException e)
            {
                return false;
            }
        }

        public static bool LoginAndFindTitle(IWebDriver driver, string username, string password, string titleToFind, IWebElement submitButton = null, IWebElement usernameField = null, IWebElement passwordField = null)
        {
            try
            {
                return FillOutLoginForm(driver, username, password, submitButton, usernameField, passwordField) &&
                       driver.Title == titleToFind;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoginAndFindText(IWebDriver driver, string username, string password, string textToFind, IWebElement submitButton = null, IWebElement usernameField = null, IWebElement passwordField = null)
        {
            try
            {
                return FillOutLoginForm(driver, username, password, submitButton, usernameField, passwordField) && 
                        Utility.IsTextPresent(driver, textToFind);
            }
            catch
            {
                return false;
            }

        }

        public static bool CheckEmptyUsernameValidation(IWebDriver driver, string validationTextToFind, IWebElement submitButton = null, IWebElement usernameField = null, IWebElement passwordField = null)
        {
            try
            {
                return FillOutLoginForm(driver, "", Utility.GetRandomString(8), submitButton, usernameField, passwordField) &&
                        Utility.IsTextPresent(driver, validationTextToFind);
            }
            catch
            {
                return false;
            }

        }

        public static bool CheckEmptyPasswordValidation(IWebDriver driver, string validationTextToFind, IWebElement submitButton = null, IWebElement usernameField = null, IWebElement passwordField = null)
        {
            try
            {
                return FillOutLoginForm(driver, Utility.GetRandomString(8), "", submitButton, usernameField, passwordField) &&
                        Utility.IsTextPresent(driver, validationTextToFind);
            }
            catch
            {
                return false;
            }

        }

        #endregion

        #region "Image Methods"

        public static bool CheckImagesOnPage(IWebDriver driver)
        {

            var allImages = driver.FindElements(By.TagName("img"));

            bool isOK = true;

            foreach (IWebElement image in allImages)
            {

                var loaded = (bool) ((IJavaScriptExecutor) driver).ExecuteScript("return arguments[0].complete", image);

                if (loaded) continue;
                isOK = false;
                break;
            }

            return isOK;

        }

        #endregion
    }

}

