using Halo.SpecFlow.Helpers;
using Halo.SpecFlow.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

namespace Halo.SpecFlow.Steps
{
    [Binding]
    public class GoogleSearchSteps
    {
        private IWebDriver webDriver;
        private GoogleSearchPageObject pageObject;

        public GoogleSearchSteps(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            this.pageObject = new GoogleSearchPageObject(this.webDriver);
        }

        [Given(@"I am on the google page")]
        public void GivenIAmOnTheGooglePageFor()
        {
            webDriver.Url = $"https://www.google.com";
        }
        
        [When(@"I enter search term as ""(.*)""")]
        public void WhenISearchFor(string searchText)
        {
            this.pageObject.SetSearchText(searchText);
        }

        [When(@"I click search")]
        public void WhenIClickSearch()
        {
            this.pageObject.SubmitSearch();
        }

        [Then(@"I should see title ""(.*)""")]
        public void ThenIShouldSeeTitle(string result)
        {
            this.pageObject.WaitForSearchResults();
            Assert.Equal(result, webDriver.Title);
        }
    }
}
