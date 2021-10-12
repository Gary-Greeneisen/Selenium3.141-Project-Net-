using System;
using TechTalk.SpecFlow;
//
using AcceptanceTests.Interface;



namespace AcceptanceTests.Steps
{
    [Binding]
    public class SearchSteps
    {

        [When(@"I Select Provider Record (.*)")]
        public void WhenISelectProviderRecord(int record)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.providerSearchPage.SelectRecord(record);
        }


        [When(@"I Select Student Record (.*)")]
        public void WhenISelectStudentRecord(int record)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.studentSearchPage.SelectRecord(record);
        }


        [Given(@"I Select Provider Record (.*)")]
        public void GivenISelectProviderRecord(int record)
        {
            //ScenarioContext.Current.Pending();

            TestRunnerInterface.Map.providerSearchPage.SelectRecord(record);

        }

        [When(@"I Select Finance Record (.*)")]
        public void WhenISelectFinanceRecord(int record)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.studentFinanceSearchPage.SelectRecord(record);
        }



        [Given(@"I Search for Submitted Applications")]
        public void GivenISearchForSubmittedApplications()
        {
            //ScenarioContext.Current.Pending();


        }


        [Given(@"I Search for Provider Applications Status ""(.*)""")]
        public void GivenISearchForProviderApplicationsStatus(string status)
        {
            //ScenarioContext.Current.Pending();
            //TestRunnerInterface.Map.providerSearchPage.SetCounty("Franklin");

            //Set Application refresh values
            TestRunnerInterface.Map.testContext.applicationStatus = status;

            TestRunnerInterface.Map.providerSearchPage.SetApplicationStatus(status);
            TestRunnerInterface.Map.providerSearchPage.Search();


        }


        [When(@"I Search For Provider")]
        public void WhenISearchForProvider()
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.providerSearchPage.Search();
        }

        [When(@"I Search For Student")]
        public void WhenISearchForStudent()
        {
            //ScenarioContext.Current.Pending();

            //Set Application Peroid = 2nd Option
            //FY 2017
            //FY 2016
            TestRunnerInterface.Map.studentSearchPage.SetListBox("ddlApplicationPeriod", 1);
            TestRunnerInterface.Map.studentSearchPage.Search();

        }

        [When(@"I Search For Finance Student")]
        public void WhenISearchForFinanceStudent()
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.studentFinanceSearchPage.SetApplicationPeroid("All");
            TestRunnerInterface.Map.studentFinanceSearchPage.Search();
        }


        [Given(@"I Select Admin Record (.*)")]
        public void GivenISelectAdminRecord(int record)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.adminPrograms.SelectRecord(record);
        }





    }




}
