using System;
using TechTalk.SpecFlow;
//
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;
using OpenQA.Selenium;



namespace AcceptanceTests.Steps
{
    [Binding]
    public class TestSpecFlowFeature1Steps
    {
        
        [When(@"I Display Test Method (.*)")]
        public void WhenIDisplayTestMethod(int p0)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.testPage1.TestMethod1();
    
           
        }

        [When(@"I Finish a new Provider application")]
        public void WhenIFinishANewProviderApplication()
        {
            //ScenarioContext.Current.Pending();
            ProviderApplicationSteps step = new ProviderApplicationSteps();
            step.GivenIFinishANewProviderApplication();

        }

        [When(@"I Finish a new Scholarship application")]
        public void WhenIFinishANewScholarshipApplication()
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.testContext.applicationStatus = "Started";

            NewScholarshipApplicationSteps steps = new NewScholarshipApplicationSteps();
            steps.GivenIFinishANewScholarshipApplication();
        }





    }
}
