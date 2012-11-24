using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SeleniumWebdriver_Utility
{

    public static class Utility
    {
        public static void SetValue(IWebDriver driver, IWebElement element, string value)
        {
           ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].value = arguments[1]", element, value);
        }

        public static bool IsThisElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool TryFindElement(IWebDriver driver, By by, out IWebElement element)
        {
            try
            {
                element = driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                element = null;
                return false;
            }
            return true;
        }

        public static bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public static string GetRandomString(int len)
        {
            return Guid.NewGuid().ToString().Substring(0, len).Replace("-", string.Empty);
        }

        public static string GetRandomFirstname()
        {

            var firstnames = new List<string>(new string[]
	            {
	                "John",
	                "Peggy-Sue", 
	                "Ronald",    
	                "Rex",
	                "Montgomery",
                    "Genevieve"
	            });

            return firstnames[new Random().Next(0, firstnames.Count - 1)];

        }

        public static string GetRandomLastname()
        {

            var lastnames = new List<string>(new string[]
	            {
	                "Smith",
	                "O'Flaherty", 
	                "Burns",    
	                "Donaldson-Allensworth",
	                "Po",
                    "McMasters"
	            });

            return lastnames[new Random().Next(0, lastnames.Count - 1)];

        }

        public static string GetRandomJobTitle()
        {

            var jobtitles = new List<string>(new string[]
	            {
	                "Fitter and Turner",
	                "Grazier", 
	                "Receptionist",    
	                "Human Resources Coordinator",
	                "Chief Executive Officer",
                    "Diving Instructor"
	            });

            return jobtitles[new Random().Next(0, jobtitles.Count - 1)];

        }

        public static string GetRandomCompanyName()
        {

            var companynames = new List<string>(new string[]
	            {
	                "Microsoft Corporation",
	                "Apple Inc",
	                "John Deere",
	                "Donald Trump Incorporated",
                    "Digicon Pty Ltd",
                    "Smith & Wesson",
                    "Peters, Smith, Rogers Lawyers"
	            });

            return companynames[new Random().Next(0, companynames.Count - 1)];

        }

        public static string GetRandomEmail()
        {

            var users = new List<string>(new string[]
	            {
	                "john.smith",
	                "andrew.richards",
	                "sanath.sangakarra",
	                "kevin.strauss",
                    "peter.citizen",
                    "bill.gates"
	            });

            var urls = new List<string>(new string[] { "microsoft", "hotmail", "gmail", "apple", "geocities", "live", "bhpbilliton" });

            var domains = new List<string>(new string[] { ".com", ".com.au", ".net", ".biz", ".co.nz", ".jp", ".co.uk", ".org" });

            string user = users[new Random().Next(0, users.Count - 1)];
            string url = urls[new Random().Next(0, urls.Count - 1)];
            string domain = domains[new Random().Next(0, domains.Count - 1)];

            return String.Format("{0}@{1}{2}", user, url, domain);

        }

        public static string GetRandomMobileAU(bool showSpaces = false)
        {

            return showSpaces ?
                  String.Format("04{0}", new Random().Next(10000000, 99999999).ToString(CultureInfo.InvariantCulture)) :
                  String.Format("04{0} {1} {2}", new Random().Next(10, 99), new Random().Next(100, 999), new Random().Next(100, 999));

        }

        public static string GetRandomPhoneAU(bool showSpaces = false)
        {

            return showSpaces ?
                  String.Format("0{0}{1}", new Random().Next(2, 9), new Random().Next(10000000, 99999999)) :
                  String.Format("0{0} {1} {2}", new Random().Next(2, 9), new Random().Next(1000, 9999), new Random().Next(1000, 9999));

        }

        public static string GetRandomPostcodeAU()
        {

            return new Random().Next(1000, 9999).ToString(CultureInfo.InvariantCulture);

        }

        public static string GetRandomAddressLine1()
        {

            string streetNumber = new Random().Next(1, 999).ToString(CultureInfo.InvariantCulture);

            var streets = new List<string>(new string[]
	            {
	                "Beerworth",
	                "Berkshire", 
	                "Buddy Newchurch",    
	                "Casuarina",
	                "Essington Lewis",
                    "Flinders", "Hursthouse"
	            });

            var streettypes = new List<string>(new string[]
	            {
	                "Street",
	                "Lane", 
	                "Avenue",    
	                "ST",
	                "Ave",
                    "Drive",
                    "Crescent"
	            });

            return String.Format("{0} {1} {2}", streetNumber, streets[new Random().Next(0, streets.Count - 1)], streettypes[new Random().Next(0, streettypes.Count - 1)]);

        }

        public static string GetRandomSuburb()
        {

            var suburbs = new List<string>(new string[]
	            {
	                "Manly",
	                "Ipswich", 
	                "Wangaratta",    
	                "Queanbeyan",
	                "Devonport",
                    "Port Macquarie", 
                    "Mornington"
	            });

            return suburbs[new Random().Next(0, suburbs.Count - 1)];

        }

        public static string GetLoremIpsum(int length = 0)
        {
            const string lorem = "Nibh lacinia tempus. Wisi quia urna massa hendrerit ut. " +
                                 "Pulvinar quam erat. Porttitor eros feugiat malesuada auctor auctor ultricies consequat gravida tempus tincidunt vestibulum. " +
                                 "Turpis volutpat quis. Euismod mollis platea. Eu leo lorem adipisicing et ac rhoncus ea libero. Con porta orci erat ante et pariatur a lorem. " +
                                 "Quis praesent eu sed massa vivamus nisl arcu pellentesque. " +
                                 "Vitae lobortis mi. Mi vitae et. Urna mauris ipsum. Vestibulum quam nec arcu dolor erat. Sit dignissim molestie nisl maecenas lectus." +
                                "Pulvinar quam erat. Porttitor eros feugiat malesuada auctor auctor ultricies consequat gravida tempus tincidunt vestibulum. " +
                                "Turpis volutpat quis. Euismod mollis platea. Eu leo lorem adipisicing et ac rhoncus ea libero. Con porta orci erat ante et pariatur a lorem. " +
                                "Quis praesent eu sed massa vivamus nisl arcu pellentesque. " +
                                "Vitae lobortis mi. Mi vitae et. Urna mauris ipsum. Vestibulum quam nec arcu dolor erat. Sit dignissim molestie nisl maecenas lectus." +
                                "Pulvinar quam erat. Porttitor eros feugiat malesuada auctor auctor ultricies consequat gravida tempus tincidunt vestibulum. " +
                                "Turpis volutpat quis. Euismod mollis platea. Eu leo lorem adipisicing et ac rhoncus ea libero. Con porta orci erat ante et pariatur a lorem. " +
                                "Quis praesent eu sed massa vivamus nisl arcu pellentesque. " +
                                "Vitae lobortis mi. Mi vitae et. Urna mauris ipsum. Vestibulum quam nec arcu dolor erat. Sit dignissim molestie nisl maecenas lectus.";

            if (length == 0) length = lorem.Length;

            return lorem.Substring(0, length);
        }

        public static bool IsTextPresent(IWebDriver driver, string str)
        {
            IWebElement bodyElement = driver.FindElement(By.TagName("body"));
            return bodyElement.Text.Contains(str);
        }

        public static bool IsTitlePresent(IWebDriver driver, string str)
        {
            return driver.Title == str;
        }

        public static string EnsureLeadingForwardSlash(string text, bool ensureSlash = false)
        {
            return ensureSlash
                       ? (text.Substring(0, 1) == "/" ? text : "/" + text)
                       : (text.Substring(0, 1) == "/" ? text.Substring(1, text.Length - 1) : text);
        }

        public static List<LinkItem> GetUniqueLinks(string bodyText)
        {

            var list = new List<LinkItem>();

            MatchCollection m1 = Regex.Matches(bodyText, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            foreach (Match m in m1)
            {

                string value = m.Groups[1].Value;
                var i = new LinkItem();

                // 3. Get href attribute.
                Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                // 4. Remove inner tags from text.
                string t = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
                t = t.Replace("&amp;", "&");

                i.Text = t;
                i.IsValid = false;

                if (!string.IsNullOrEmpty(i.Text) && !string.IsNullOrEmpty(i.Href))
                {
                    i.IsValid = true;
                }

                if (!list.Any(c => c.Href == i.Href)) list.Add(i);

                // Console.WriteLine(m.Index + ": URL is " + i.Href + " | Text is " + i.Text);

            }

            return list;
        }

        public struct LinkItem
        {

            public string Href;
            public string Text;
            public bool IsValid;

            public override string ToString()
            {
                return Href + "\n\t" + Text;
            }

        }

    }
}
