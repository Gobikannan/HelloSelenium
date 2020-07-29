using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Halo.SpecFlow.Helpers
{
    public class WebDriverHelper
    {
        public static void WaitForElementToBecomeVisibleWithinTimeout(IWebDriver driver, IWebElement element, int timeout = 10)
        {
            var webDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            var resultsDisplayed = false;
            while (resultsDisplayed == false)
            {
                resultsDisplayed = webDriver.Until(ElementIsVisible(element));
            }
        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception ex)
                {
                    // If element is null, stale or if it cannot be located
                    throw ex;
                }
            };
        }
    }
}
