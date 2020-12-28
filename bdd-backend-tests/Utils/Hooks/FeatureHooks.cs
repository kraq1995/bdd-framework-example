using bdd_backend_tests.Apis;
using Gherkin.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace bdd_backend_tests.Utils.Hooks
{
    [Binding]
    internal static class FeatureHooks
    {
        [BeforeFeature()]
        internal static void BeforeHooks(FeatureContext featureContext)
        {
            if (featureContext.FeatureInfo.Tags.Contains("Api"))
            {
                BaseApiTests.SetBaseUriAndAuth();
            }
        }
    }
}
