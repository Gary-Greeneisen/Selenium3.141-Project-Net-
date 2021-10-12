using System;
using TechTalk.SpecFlow;
//
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;
using System.Collections.Generic;


namespace AcceptanceTests.Steps
{
    [Binding]
    public class NewScholarshipApplicationSteps
    {
        [Given(@"I Start a new Scholarship application")]
        public void GivenIStartANewScholarshipApplication()
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.testContext.applicationStatus = "Started";
            TestRunnerInterface.Map.newScholarshipApplication.StartApplication();

        }

        [Given(@"I Start a new Scholarship application")]
        public void GivenIStartANewScholarshipapplication(Table table)
        {

            //foreach (var row in table.Rows)
            //{
            //    var filename = row["Filename"];
            //}

            string filename = table.Rows[0]["Filename"];
            TestRunnerInterface.Map.newScholarshipApplication.LoadXMLApplicationData(filename);
            TestRunnerInterface.Map.testContext.applicationStatus = "Started";
            TestRunnerInterface.Map.newScholarshipApplication.StartApplication(TestRunnerInterface.Map.scholarshipApplicationData);


        }

        [Given(@"I Finish a new Scholarship application")]
        public void GivenIFinishANewScholarshipApplication()
        {
            var program = TestRunnerInterface.Map.testContext.program;

            if (program.Equals("Autism", StringComparison.OrdinalIgnoreCase))
            {
                //Search and select record(1)
                //Advanced Student Search Page and select record(1)
                TestRunnerInterface.Map.menu.SearchScholarshipApplication();
                TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationPeroid("Autism FY 2016");
                TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationStatus(TestRunnerInterface.Map.testContext.applicationStatus);
                TestRunnerInterface.Map.advancedStudentSearchPage.Search();
                TestRunnerInterface.Map.advancedStudentSearchPage.SelectRecord(1);

                //Finish the Application
                TestRunnerInterface.Map.newScholarshipApplication.FinishApplication(TestRunnerInterface.Map.scholarshipApplicationData);
            }

            if (program.Equals("JPSN", StringComparison.OrdinalIgnoreCase))
            {
                //Search and select record(1)
                //Advanced Student Search Page and select record(1)
                TestRunnerInterface.Map.menu.SearchScholarshipApplication();
                TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationPeroid("JPSN FY 2016");
                TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationStatus(TestRunnerInterface.Map.testContext.applicationStatus);
                TestRunnerInterface.Map.advancedStudentSearchPage.Search();
                TestRunnerInterface.Map.advancedStudentSearchPage.SelectRecord(1);

                //Finish the Application
                TestRunnerInterface.Map.newScholarshipApplication.FinishApplication(TestRunnerInterface.Map.scholarshipApplicationData);
            }


            if (program.Equals("EdChoice", StringComparison.OrdinalIgnoreCase))
            {
                //Search and select record(1)
                //Advanced Student Search Page and select record(1)
                TestRunnerInterface.Map.menu.SearchScholarshipApplication();
                TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationPeroid("EdChoice FY 2016");
                TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationStatus(TestRunnerInterface.Map.testContext.applicationStatus);
                TestRunnerInterface.Map.advancedStudentSearchPage.Search();
                TestRunnerInterface.Map.advancedStudentSearchPage.SelectRecord(1);

                //Finish the Application
                TestRunnerInterface.Map.newScholarshipApplication.FinishApplication(TestRunnerInterface.Map.scholarshipApplicationData);

            }

        }

        [Given(@"I Update the Student SSID")]
        public void GivenIUpdateTheStudentSSID()
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.newScholarshipApplication.SetSSID();
        }



        [Given(@"I Finish a new Scholarship application")]
        public void GivenIFinishANewScholarshipapplication(Table table)
        {
            //ScenarioContext.Current.Pending();
            string filename = table.Rows[0]["Filename"];
  

        }


        [Given(@"I Search for Scholarship Applications Status ""(.*)""")]
        public void GivenISearchForScholarshipApplicationsStatus(string status)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.menu.SearchScholarshipApplication();
            TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationPeroid("All");
            TestRunnerInterface.Map.advancedStudentSearchPage.SetApplicationStatus(status);
            TestRunnerInterface.Map.advancedStudentSearchPage.Search();


        }


        [Given(@"I Select Scholarship Record (.*)")]
        public void GivenISelectScholarshipRecord(int record)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.advancedStudentSearchPage.SelectRecord(record);

        }



        [When(@"I Update the Scholarship Application Status to ""(.*)""")]
        public void WhenIUpdateTheScholarshipApplicationStatusTo(string status)
        {
            //ScenarioContext.Current.Pending();

            if (status.ToUpper().Equals("REVIEW COMPLETED"))
            {
                //Before setting status = Review Completed
                //need pre-processing to add Student SSID# and IEP
                TestRunnerInterface.Map.newScholarshipApplication.SetReviewCompleted();
            }
            //After pre-processing, continue and set status
            TestRunnerInterface.Map.providerSearchPage.StatusFlagsTab();
            TestRunnerInterface.Map.statusFlagsTab.SetScholarshipStatus(status);


        }

        [When(@"I Update the Application Status to ""(.*)""")]
        public void WhenIUpdateTheApplicationStatusTo(string p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I Search for Scholarship Applications First Name ""(.*)""")]
        public void GivenISearchForScholarshipApplicationsFirstName(string name)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.menu.SearchScholarshipApplication();
            TestRunnerInterface.Map.advancedStudentSearchPage.SetFirstName(name);
            TestRunnerInterface.Map.advancedStudentSearchPage.Search();
        }

        [Given(@"I Search for Scholarship Applications Last Name ""(.*)""")]
        public void GivenISearchForScholarshipApplicationsLastName(string name)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.menu.SearchScholarshipApplication();
            TestRunnerInterface.Map.advancedStudentSearchPage.SetLastName(name);
            TestRunnerInterface.Map.advancedStudentSearchPage.Search();
        }


        [Then(@"I Repeat Actions (.*) Times")]
        public void ThenIRepeatActionsTimes(int cycles)
        {
            //ScenarioContext.Current.Pending();

            while(cycles > 0)
            {

                this.GivenIStartANewScholarshipApplication();
                //this.GivenIFinishANewScholarshipApplication();
                this.GivenIUpdateTheStudentSSID();

                cycles--;
            }


        }










    }

}
