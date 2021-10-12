using System;
using TechTalk.SpecFlow;
//
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;
using System.Collections.Generic;


namespace AcceptanceTests.Steps
{
    [Binding]
    public class ProviderApplicationSteps
    {

        [Given(@"I Create a new application")]
        public void GivenICreateANewApplication()
        {
            //ScenarioContext.Current.Pending();

       
        }

        [Given(@"I Start a new Provider application")]
        public void GivenIStartANewProviderApplication()
        {
            //ScenarioContext.Current.Pending();
            //Set Test Context
            TestRunnerInterface.Map.providerApplicationData.hardCodedData = true;
            TestRunnerInterface.Map.testContext.applicationStatus = "Started";

            TestRunnerInterface.Map.newProviderApplication.StartApplication();

        }

        [Given(@"I Start a new Provider application")]
        public void GivenIStartANewProviderApplication(Table table)
        {
            //ScenarioContext.Current.Pending();
           

            //string personnelRole;
            //List<string> services = new List<string>();
            //string staff;

            //Set Test Context
            TestRunnerInterface.Map.providerApplicationData.hardCodedData = false;
            TestRunnerInterface.Map.testContext.applicationStatus = "Started";

            foreach (var row in table.Rows)
            {
                string element = row["Personnel Role"];
                if (!String.IsNullOrEmpty(element))
                {
                    TestRunnerInterface.Map.providerApplicationData.personnelRoleList.Add(element);

                }

                element = row["Services"];
                if (!String.IsNullOrEmpty(element))
                {
                    TestRunnerInterface.Map.providerApplicationData.servicesList.Add(element);
                }

                element = row["Staff"];
                if (!String.IsNullOrEmpty(element))
                {
                    TestRunnerInterface.Map.providerApplicationData.staffList.Add(element);
                }

            } //end foreach (var row in table.Rows)

            TestRunnerInterface.Map.newProviderApplication.StartApplication();

        }

        
        [Given(@"I Finish a new Provider application")]
        public void GivenIFinishANewProviderApplication()
        {
            //ScenarioContext.Current.Pending();
            //Sign out and sign back in using test context
            //Search for records status = Started
            //Select record(1), and continue creating Application

            //Sign out 
            TestRunnerInterface.Map.headerPage.SignOut();
            
            //sign back in using test context
            var role = TestRunnerInterface.Map.testContext.role;
            LoginRolesSteps loginStep = new LoginRolesSteps();
            loginStep.LoginToExistingURL(role);

            var program = TestRunnerInterface.Map.testContext.program;
            ProgramSelectionSteps programStep = new ProgramSelectionSteps();
            programStep.WhenISelectTheProgram(program);

            //Provider Search and select record(1)
            TestRunnerInterface.Map.providerSearchPage.SetApplicationStatus(TestRunnerInterface.Map.testContext.applicationStatus);
            TestRunnerInterface.Map.providerSearchPage.SetApplicationPeroid("All");
            TestRunnerInterface.Map.providerSearchPage.Search();
            TestRunnerInterface.Map.providerSearchPage.SelectRecord(1);

            //Finish the Application
            //Check if(Application uses Table Data or Hard Coded Data)
            if (TestRunnerInterface.Map.providerApplicationData.hardCodedData)
            {
                TestRunnerInterface.Map.newProviderApplication.FinishApplication();
            }
            else
            {
                TestRunnerInterface.Map.newProviderApplication.FinishApplication(TestRunnerInterface.Map.providerApplicationData);
            }

        }



        [When(@"I Update the Application to Submitted Status")]
        public void WhenIUpdateTheApplicationToSubmittedStatus()
        {
            //ScenarioContext.Current.Pending();

        }

        [When(@"I Update the Provider Application Status to ""(.*)""")]
        public void WhenIUpdateTheProviderApplicationStatusTo(string status)
        {
            //ScenarioContext.Current.Pending()

            //Submit Application
            TestRunnerInterface.Map.providerSearchPage.StatusFlagsTab();
            TestRunnerInterface.Map.statusFlagsTab.SetStatus(status);

        }

        [Then(@"The Application Status is displayed as ""(.*)""")]
        public void ThenTheApplicationStatusIsDisplayedAs(string status)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.providerSearchPage.StatusFlagsTab();
            TestRunnerInterface.Map.statusFlagsTab.AssertStatus(status, RunTimeVars.REPEAT_TIMES);
           
        }


        [Then(@"The Application Status Submitted is displayed")]
        public void ThenTheApplicationStatusSubmittedIsDisplayed()
        {
            //ScenarioContext.Current.Pending();


            TestRunnerInterface.Map.headerPage.SignOut();
            TestRunnerInterface.Map.safePage.BrowserClose();
            
        }



 
        [Then(@"The Application Status Approved is displayed")]
        public void ThenTheApplicationStatusApprovedIsDisplayed()
        {
            //ScenarioContext.Current.Pending();
        }


    }
}
