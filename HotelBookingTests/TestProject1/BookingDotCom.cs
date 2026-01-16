using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class BookingDotCom
    {
        [TestMethod]
        public void BookingTests()
        {
            // Initialize ChromeDriver
            IWebDriver driver = new ChromeDriver();

            try
            {
                // Navigate to Booking.com
                driver.Navigate().GoToUrl("https://www.booking.com");
                driver.Manage().Window.Maximize();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Close cookie banner if it appears
                try
                {
                    IWebElement cookieBanner = wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("button[aria-label='Dismiss sign-in info.']")));
                    cookieBanner.Click();
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("No cookie banner appeared.");
                }

                // Click check-in input to open calendar
                IWebElement checkInInput = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.CssSelector("[data-testid='searchbox-dates-container']")));
                checkInInput.Click();

                // Select check-in date dynamically
                //"2025-11-27"
                DateTime CheckInDate = DateTime.Parse("2025-11-27");
                Console.WriteLine(CheckInDate);
                //wait for the date before clicking it
                IWebElement dateLocator = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"[date-time='{CheckInDate:yyyy-MM-dd}']")));
                dateLocator.Click();
                //DateTime targetCheckInDate = new DateTime(2025, 11, 27);
                //IWebElement checkInDate = wait.Until(ExpectedConditions.ElementToBeClickable(
                //    By.CssSelector($"[data-date='{targetCheckInDate:yyyy-MM-dd}']")));
                //checkInDate.Click();

                // Select check-out date dynamically
                DateTime targetCheckOutDate = new DateTime(2025, 12, 5);
                string targetMonthYear = targetCheckOutDate.ToString("MMMM yyyy");

                // keep clicking until the correct month appears
                while (true)
                {
                    IWebElement monthHeader = driver.FindElement(By.CssSelector("h3"));
                    string visibleMonthYear = monthHeader.Text;

                    if (visibleMonthYear.Equals(targetMonthYear))
                        break;

                    wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("[aria-label='Next month']"))).Click();
                }

                // now click the correct day
                IWebElement checkOutDate = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.CssSelector($"[data-date='{targetCheckOutDate:yyyy-MM-dd}']")));

                checkOutDate.Click();

            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }
    }
}
