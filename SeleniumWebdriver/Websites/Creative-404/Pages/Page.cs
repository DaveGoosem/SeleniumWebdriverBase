using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumWebdriver.Websites.Creative_404.Pages
{
    /// <summary>
    /// All page objects should inherit from this. This class should contain helpers
    /// that are expected to be on all pages. Examples include a page title, doctype,
    /// css files, js files, and navigation. Think of this as a 'masterpage'.
    /// </summary>
    public class Page
    {
        public string Title;
        private readonly IWebDriver _driver;

        public Page(IWebDriver driver)
        {
            _driver = driver;
            Title = _driver.Title;
        }
    }
}
