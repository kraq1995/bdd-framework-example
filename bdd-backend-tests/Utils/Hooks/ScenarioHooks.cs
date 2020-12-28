using bdd_backend_tests.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace bdd_backend_tests.Utils.Hooks
{
    [Binding]
    internal static class ScenarioHooks
    {
        [BeforeScenario()]
        internal static void BeforeHooks(ScenarioContext scenarioContext)
        {
            if (scenarioContext.ScenarioInfo.Tags.Contains("Api"))
            {
                BaseApiTests.SetBaseUriAndAuth();
            }
        }
    }
}
