using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlivoAssignment.Pages;
using System.Threading;

namespace PlivoAssignment
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {

           IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.youtube.com/";
            Thread.Sleep(500);
            LoginPage loginpage = new LoginPage(driver);
            loginpage.searchkeyword("Tester Talk");
            Thread.Sleep(500);

            driver.Quit();
        }
    }
}