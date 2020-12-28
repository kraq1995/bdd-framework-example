using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace bddFrontendTests
{
    [Binding]
    public class WikipediaTitleValidationSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;

        public WikipediaTitleValidationSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = _context["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I have navigated to the ""(.*)"" page on Wikipedia")]
        public void GivenIHaveNavigatedToThePageOnWikipedia(string subject)
        {
            _webDriver.Url = $"https://en.wikipedia.org/wiki/{subject}";
        }
        
        [Then(@"the title of the page should be ""(.*)""")]
        public void ThenTheTitleOfThePageShouldBe(string title)
        {
            Assert.Equal(title, _webDriver.Title);
        }
    }
}
