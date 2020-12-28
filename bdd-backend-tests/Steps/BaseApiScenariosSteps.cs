using bdd_backend_tests.Apis;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace bdd_backend_tests.Steps
{
    [Binding]
    public class BaseApiScenariosSteps
    {
        private readonly ScenarioContext _context;
        public BaseApiScenariosSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"I Post a tweet of ""(.*)""")]
        public void GivenIPostATweetOf(string tweet)
        {
            BaseApiTests.PostTweet(tweet);
        }

        [When(@"I retrieve the resource of ""(.*)""")]
        public void WhenIRetrieveTheResourceOf(string apiResource)
        {
            BaseApiTests.GetResponseOfResource(apiResource);
        }

        [Then(@"the latest tweet is my message of ""(.*)""")]
        public void ThenTheLatestTweetIsMyMessageOf(string tweet)
        {
            BaseApiTests.AssertTweetWasPosted(tweet);
        }

    }
}
