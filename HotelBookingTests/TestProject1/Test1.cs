using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers; // This is crucial for ExpectedConditions


namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trivago.co.za/");

            IWebElement Destination = driver.FindElement(By.CssSelector("[data-testid='search-form-input']"));
            Destination.Click();


            //wait until it is clickablle
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement DestinationInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='suggestion-list']/ul/li[1]")));
            DestinationInput.Click();

            //IWebElement CheckIn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid='search-form-calendar']")));
            //CheckIn.Click();

            //IWebElement CheckInDate = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid='valid-calendar-day-2025-11-27'] time")));
            //CheckInDate.Click();
            string date = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"); // tomorrow
            string selector = $"button[data-testid='valid-calendar-day-{date}']";
            IWebElement checkInDate = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(selector)));
            checkInDate.Click();
            //IWebElement checkInDate = wait.Until(driver => driver.FindElement(By.CssSelector("button[data-testid='valid-calendar-day-2025-11-27']")));
            //checkInDate.Click();

            IWebElement CheckOutDate = wait.Until(driver => driver.FindElement(By.CssSelector("time[datetime='2025-12-02']")));
            CheckOutDate.Click();
            //wait to be fully inteactable

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[data-testid='search-form-guest-selector']"))).Click();

            //selecting guests
           // wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("adults"))).SendKeys("4");
            //click apply button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("data-testid='search-button-with-loader']"))).Click();
            //click submit button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[data-testid='search-button-with-loader']"))).Click();
                }
    }
}
