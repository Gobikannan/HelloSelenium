using Halo.SpecFlow.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Halo.SpecFlow.PageObjects
{
    public class GoogleSearchPageObject
    {
        [FindsBy(How = How.CssSelector, Using = "#searchform input.gsfi")]
        protected IWebElement SearchTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#searchform input.gNO89b")]
        protected IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "result-stats")]
        protected IWebElement SearchResultsStats { get; set; }

        private readonly IWebDriver _driver;

        public GoogleSearchPageObject(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void SetSearchText(string searchText)
        {
            this.SearchTextBox.SendKeys(searchText);
        }

        public void SubmitSearch()
        {
            this.SearchButton.Click();
        }

        public void WaitForSearchResults()
        {
            WebDriverHelper.WaitForElementToBecomeVisibleWithinTimeout(this._driver, this.SearchResultsStats);
            Console.WriteLine(this.SearchResultsStats.Text);
        }
    }
}
