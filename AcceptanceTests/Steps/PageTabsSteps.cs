using System;
using TechTalk.SpecFlow;
//
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class PageTabsSteps
    {

 
        [Then(@"I Test All Provider Search Page Tabs")]
        public void ThenITestAllProviderSearchPageTabs()
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.verifyPageTabs.ProviderSearchPageTabs("EdChoice");

        }


        [Then(@"I Test All Provider Search Page ""(.*)""")]
        public void ThenITestAllProviderSearchPage(string tabs)
        {
            //ScenarioContext.Current.Pending();

            //Convert the comma seperated tabs string into a list for processing
            string[] tabArray = tabs.Split(',');
            List<string> tabList = new List<string>();
            tabList.AddRange(tabArray);

            TestRunnerInterface.Map.verifyPageTabs.VerifyProviderPageTabs(tabList);


            //Click Back to Basic Search results
            //Verify PROVIDER SEARCH PAGE displayed
            TestRunnerInterface.Map.headerPage.BackToSearchResults("Back to Basic Search results");
            TestRunnerInterface.Map.providerSearchPage.WaitForProviderSearch(RunTimeVars.REPEAT_TIMES);
            TestRunnerInterface.Map.providerSearchPage.BasicSearchTab();

        }


        [Then(@"I Test All Student Search Page Tabs")]
        public void ThenITestAllStudentSearchPageTabs()
        {
            //ScenarioContext.Current.Pending();

        }


        [Then(@"I Test All Student Search Page ""(.*)""")]
        public void ThenITestAllStudentSearchPage(string tabs)
        {
            //ScenarioContext.Current.Pending();

            //Convert the comma seperated tabs string into a list for processing
            string[] tabArray = tabs.Split(',');
            List<string> tabList = new List<string>();
            tabList.AddRange(tabArray);

            TestRunnerInterface.Map.verifyPageTabs.VerifyStudentPageTabs(tabList);

            //Click Back to Basic Search results
            //Verify ADVANCED STUDENT SEARCH PAGE displayed
            TestRunnerInterface.Map.headerPage.BackToSearchResults("Back to student search results");
            TestRunnerInterface.Map.studentSearchPage.WaitForAdvancedStudentSearch(RunTimeVars.REPEAT_TIMES);
            TestRunnerInterface.Map.studentSearchPage.BasicSearchTab();

        }


        [Then(@"I Test All Parent Student Search Page ""(.*)""")]
        public void ThenITestAllParentStudentSearchPage(string tabs)
        {
            //ScenarioContext.Current.Pending();

            //Convert the comma seperated tabs string into a list for processing
            string[] tabArray = tabs.Split(',');
            //List<string> tabList = new List<string>();
            //tabList.AddRange(tabArray);
            List<string> tabList = new List<string>(tabArray);

            TestRunnerInterface.Map.verifyPageTabs.VerifyParentStudentPageTabs(tabList);

            //Click Back to Basic Search results
            //Verify ADVANCED STUDENT SEARCH PAGE displayed
            TestRunnerInterface.Map.headerPage.BackToSearchResults("Back to Parent search results");
            TestRunnerInterface.Map.studentSearchPage.WaitForAdvancedStudentSearch(RunTimeVars.REPEAT_TIMES);
            TestRunnerInterface.Map.parentStudentTab.ParentSearchTab();

        }


        [Then(@"I Test All Student Finance Search Page ""(.*)""")]
        public void ThenITestAllStudentFinanceSearchPage(string tabs)
        {
            //ScenarioContext.Current.Pending();

            //Convert the comma seperated tabs string into a list for processing
            string[] tabArray = tabs.Split(',');
            //List<string> tabList = new List<string>();
            //tabList.AddRange(tabArray);
            List<string> tabList = new List<string>(tabArray);

            TestRunnerInterface.Map.verifyPageTabs.VerifyStudentFinancePageTabs(tabList);          

            //Click Back to Basic Search results
            //Verify STUDENT FINANCE SEARCH PAGE displayed
            TestRunnerInterface.Map.headerPage.BackToSearchResults("Back to finance search results");
            TestRunnerInterface.Map.studentFinanceSearchPage.WaitForStudentFinanceSearch(RunTimeVars.REPEAT_TIMES);
            TestRunnerInterface.Map.studentFinanceSearchPage.BasicSearchTab();



        }


        [Then(@"I Test All Admin Pages ""(.*)""")]
        public void ThenITestAllAdminPages(string tabs)
        {
            //ScenarioContext.Current.Pending();
            //Convert the comma seperated tabs string into a list for processing
            string[] tabArray = tabs.Split(',');
            //List<string> tabList = new List<string>();
            //tabList.AddRange(tabArray);
            List<string> tabList = new List<string>(tabArray);

            TestRunnerInterface.Map.verifyPageTabs.VerifyAdminProgramsPageTabs(tabList);


        }






    }
}
