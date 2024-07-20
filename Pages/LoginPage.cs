using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivoAssignment.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement searchText => driver.FindElement(By.XPath("//*[@name='search_query']"));

        public void searchkeyword(string text)
        {
            searchText.SendKeys(text);
            searchText.SendKeys(Keys.Enter);

        }

    }
}
