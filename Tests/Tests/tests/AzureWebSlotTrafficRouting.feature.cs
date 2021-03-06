// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlow.GeneratedTests.Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AzureWebSlotTrafficRouting")]
    public partial class AzureWebSlotTrafficRoutingFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AzureWebSlotTrafficRouting.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AzureWebSlotTrafficRouting", "\tIn order to A/B test using the Staging and Production slots \r\n\tAs a route me adm" +
                    "inistrator\r\n\tI want to have an automated approach to test the alpha environment " +
                    "to allow automated scaling up or down of the percentage of users hitting the alp" +
                    "ha environment", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("GetRoutingDirection - Routing to alpha increasing")]
        [NUnit.Framework.CategoryAttribute("basic")]
        public virtual void GetRoutingDirection_RoutingToAlphaIncreasing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetRoutingDirection - Routing to alpha increasing", new string[] {
                        "basic"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("I have a build with no problem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I have a default of 10% with a 5% increment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.When("I deploy a new staging build", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I expect to see the percentage of traffic go up to 15%", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("GetRoutingDirection - Routing to alpha decreasing")]
        [NUnit.Framework.CategoryAttribute("validation")]
        [NUnit.Framework.TestCaseAttribute("Router issues", "metrics", "availabilityResults/availabilityPercentage", "As determined load testing on Azure", "5%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Javascript errors", "metrics", "exceptions/browser", "Application insights", "0%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Server side errors", "metrics", "exceptions/server", "Application insights", "0%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Latency regression", "metrics", "browserTimings/receiveDuration", "Must be less than 20% regression", "5%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Customer conversion regression", "events", "customEvents", "Are users getting through the sales funnel.", "5%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Customer bounce rate", "metrics", "pageViews/count", "How far do users get through our sales funnel", "5%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Customer average time spent on page", "metrics", "pageViews/duration", "Are users engaged enough with content?", "5%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Server side errors & Latency regression", "N/A", "N/A", "Many technical", "0%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Customer bounce rate & Customer average time spent on page", "N/A", "N/A", "Many business", "5%", new string[0])]
        [NUnit.Framework.TestCaseAttribute("All issue types", "N/A", "N/A", "Many technical and business", "0%", new string[0])]
        public virtual void GetRoutingDirection_RoutingToAlphaDecreasing(string problem, string azureAPI, string azureAPIMetric, string description, string stagingRoutingPercentage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "validation"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetRoutingDirection - Routing to alpha decreasing", @__tags);
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
testRunner.Given(string.Format("I have a build with {0}", problem), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.And("I have a default of 10% with a 5% increment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.When("I deploy a new staging build", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then(string.Format("I expect to see the the percentage of traffic go down to {0}", stagingRoutingPercentage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
