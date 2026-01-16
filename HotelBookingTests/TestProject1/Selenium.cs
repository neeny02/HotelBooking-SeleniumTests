using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class Selenium
    {
        [TestMethod]

        public void SeleniumTests() {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/formPage.html");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //selector for dropdown
            IWebElement dropdown = driver.FindElement(By.Name("selectomatic"));

            //select country by creating an instance of the select objecct
            SelectElement selectCountry = new SelectElement(dropdown);
            selectCountry.SelectByText("Two");
            //
            SelectElement selectGuests = new SelectElement(driver.FindElement(By.Name("select-default")));
            selectGuests.SelectByText("Still learning how to count, apparently");

            var selectSpaces = new SelectElement(driver.FindElement(By.Name("select_with_spaces")));
            selectSpaces.SelectByIndex(3);
            //click button to assert on next page
            driver.FindElement(By.Id("imageButton")).Click();

            //testing multi-select
            SelectElement multiselect = new SelectElement(driver.FindElement(By.Name("multi")));
            multiselect.SelectByIndex(0);
            multiselect.SelectByValue("ham");

            ////interact with checkbox
            //IWebElement checkbox = driver.FindElement(By.Id("cheese"));
            //checkbox.Click();

            //assert that can see text on next page
            string successMessage = driver.FindElement(By.Id("greeting")).Text;

            Assert.AreEqual("Success!", successMessage);



        }
    }
}
