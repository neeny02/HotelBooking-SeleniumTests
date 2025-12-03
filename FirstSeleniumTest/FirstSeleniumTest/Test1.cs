using Microsoft.Extensions.DependencyModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq.Expressions;

namespace FirstSeleniumTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/?zx=1764674555070&no_sw_cr=1");

            //click gmail link and verify it takes me to the correct URL
            driver.FindElement(By.LinkText("Gmail")).Click();
            string ActualUrl = driver.Url;
            Console.WriteLine(ActualUrl);
            //check that it navigates to the URL "https://mail.google.com/mail/u/0/#inbox"
            Assert.AreEqual("https://workspace.google.com/intl/en-US/gmail/", ActualUrl);

        }
    }
}
