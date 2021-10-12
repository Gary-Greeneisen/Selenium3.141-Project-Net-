using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Common.Application;
using OpenQA.Selenium.Interactions;

namespace AcceptanceTests.PageObjects
{
    public partial class VerifyPageTabs
    {
        /// <summary>
        /// Click each tab based on program type
        /// Verify each tab is displayed
        /// </summary>
        public void ProviderSearchPageTabs(string program)
        {

            //Verify EdChoice Tabs
            TestRunnerInterface.Map.providerSearchPage.GeneralTab();
            TestRunnerInterface.Map.providerSearchPage.PersonnelTab();
            //TestRunnerInterface.Map.tabs.ServicesTab();
            TestRunnerInterface.Map.providerSearchPage.StaffTab();
            TestRunnerInterface.Map.providerSearchPage.DocsTab();
            TestRunnerInterface.Map.providerSearchPage.StatusFlagsTab();
            //TestRunnerInterface.Map.tabs.TuitionTab();
            TestRunnerInterface.Map.providerSearchPage.CommentsHistoryTab();

            //Click Back to Basic Search results
            //Verify PROVIDER SEARCH PAGE displayed
            TestRunnerInterface.Map.headerPage.BackToSearchResults("Back to Basic Search results");
            TestRunnerInterface.Map.providerSearchPage.WaitForProviderSearch(RunTimeVars.REPEAT_TIMES);


        }

    

        /// <summary>
        /// Based on the tab name in the tab List
        /// click the application tab
        /// </summary>
        /// <param name="tabList">The tab list.</param>
        public void VerifyProviderPageTabs(List<string> tabList)
        {


            foreach (var tab in tabList)
            {

                bool error = false;

                switch (tab.ToUpper().Trim())
                {
                    case "GENERAL":
                        TestRunnerInterface.Map.providerSearchPage.GeneralTab();
                    break;

                    case "STUDENT":
                        TestRunnerInterface.Map.providerSearchPage.StudentTab();
                        break;

                    case "PARENT/GUARDIAN":
                        TestRunnerInterface.Map.providerSearchPage.ParentGuardianTab();
                        break;

                    case "INCOME VERIFICATION":
                        TestRunnerInterface.Map.providerSearchPage.IncomeVerificationTab();
                        break;

                    case "APPLICATION":
                        TestRunnerInterface.Map.providerSearchPage.ApplicationTab();
                        break;

                    case "GRADUATION REQUIREMENTS":
                        TestRunnerInterface.Map.providerSearchPage.GraduationRequirementsTab();
                        break;

                    case "IEP":
                        TestRunnerInterface.Map.providerSearchPage.IEPTab();
                        break;


                    case "TUITION":
                        TestRunnerInterface.Map.providerSearchPage.TuitionTab();
                        break;

                    case "ASSESSMENT":
                        TestRunnerInterface.Map.providerSearchPage.AssessmentTab();
                        break;


                    case "STUDENT SUCCESS PLAN":
                        TestRunnerInterface.Map.providerSearchPage.StudentSuccessPlanTab();
                        break;

                    case "PERSONNEL":
                        TestRunnerInterface.Map.providerSearchPage.PersonnelTab();
                    break;

                    case "SERVICES":
                        TestRunnerInterface.Map.providerSearchPage.ServicesTab();
                    break;

                    case "STAFF":
                        TestRunnerInterface.Map.providerSearchPage.StaffTab();
                    break;

                    case "DOCS":
                        TestRunnerInterface.Map.providerSearchPage.DocsTab();
                    break;

                    case "STATUS/FLAGS":
                        TestRunnerInterface.Map.providerSearchPage.StatusFlagsTab();
                    break;

  
                    case "COMMENTS/HISTORY":
                        TestRunnerInterface.Map.providerSearchPage.CommentsHistoryTab();
                    break;

                    case "APPLICATIONQUESTIONS":
                        TestRunnerInterface.Map.providerSearchPage.ApplicationQuestionsTab();
                    break;

                    case "PARTICIPATING BUILDINGS":
                        TestRunnerInterface.Map.providerSearchPage.ParticipatingBuildingsTab();
                        break;



                    default:
                        error = true;
                    break;

                }

                if (error)
                {
                    throw new Exception("The Tab Name = " + tab + "Is Not Valid Name");
                }

            }


        }



        /// <summary>
        /// Based on the tab name in the tab List
        /// click the application tab
        /// </summary>
        /// <param name="tabList">The tab list.</param>
        public void VerifyStudentPageTabs(List<string> tabList)
        {

            foreach (var tab in tabList)
            {

                bool error = false;

                switch (tab.ToUpper().Trim())
                {
                    case "GENERAL":
                        TestRunnerInterface.Map.studentSearchPage.GeneralTab();
                        break;

                    case "STUDENT":
                        TestRunnerInterface.Map.studentSearchPage.StudentTab();
                        break;

                    case "PARENT/GUARDIAN":
                        TestRunnerInterface.Map.studentSearchPage.ParentGuardianTab();
                        break;

                    case "INCOME VERIFICATION":
                        TestRunnerInterface.Map.studentSearchPage.IncomeVerificationTab();
                        break;

                    case "APPLICATION":
                        TestRunnerInterface.Map.studentSearchPage.ApplicationTab();
                        break;

                    case "GRADUATION REQUIREMENTS":
                        TestRunnerInterface.Map.studentSearchPage.GraduationRequirementsTab();
                        break;

                    case "IEP":
                        TestRunnerInterface.Map.studentSearchPage.IEPTab();
                        break;


                    case "TUITION":
                        TestRunnerInterface.Map.studentSearchPage.TuitionTab();
                        break;

                    case "ASSESSMENT":
                        TestRunnerInterface.Map.studentSearchPage.AssessmentTab();
                        break;


                    case "STUDENT SUCCESS PLAN":
                        TestRunnerInterface.Map.studentSearchPage.StudentSuccessPlanTab();
                        break;

                    case "PERSONNEL":
                        TestRunnerInterface.Map.studentSearchPage.PersonnelTab();
                        break;

                    case "SERVICES":
                        TestRunnerInterface.Map.studentSearchPage.ServicesTab();
                        break;

                    case "STAFF":
                        TestRunnerInterface.Map.studentSearchPage.StaffTab();
                        break;

                    case "DOCS":
                        TestRunnerInterface.Map.studentSearchPage.DocsTab();
                        break;

                    case "STATUS/FLAGS":
                        TestRunnerInterface.Map.studentSearchPage.StatusFlagsTab();
                        break;


                    case "COMMENTS/HISTORY":
                        TestRunnerInterface.Map.studentSearchPage.CommentsHistoryTab();
                        break;

                    case "APPLICATIONQUESTIONS":
                        TestRunnerInterface.Map.studentSearchPage.ApplicationQuestionsTab();
                        break;

                    case "PARTICIPATING BUILDINGS":
                        TestRunnerInterface.Map.studentSearchPage.ParticipatingBuildingsTab();
                        break;



                    default:
                        error = true;
                        break;

                }

                if (error)
                {
                    throw new Exception("The Tab Name = " + tab + "Is Not Valid Name");
                }

            }


        }





        /// <summary>
        /// Based on the tab name in the tab List
        /// click the application tab
        /// </summary>
        /// <param name="tabList">The tab list.</param>
        public void VerifyParentStudentPageTabs(List<string> tabList)
        {


            foreach (var tab in tabList)
            {

                bool error = false;

                switch (tab.ToUpper().Trim())
                {
                    case "STUDENT":
                        TestRunnerInterface.Map.parentStudentTab.StudentTab();
                        break;

                    case "PARENT/GUARDIAN":
                        TestRunnerInterface.Map.parentStudentTab.ParentGuardianTab();
                        break;


                    case "APPLICATION":
                        TestRunnerInterface.Map.parentStudentTab.ApplicationTab();
                        break;


                    case "IEP":
                        TestRunnerInterface.Map.parentStudentTab.IEPTab();
                        break;


                    case "CREDIT HOURS":
                        TestRunnerInterface.Map.parentStudentTab.CreditHoursTab();
                        break;

                    case "DOCS":
                        TestRunnerInterface.Map.parentStudentTab.DocsTab();
                        break;


                    case "STATUS/FLAGS":
                        TestRunnerInterface.Map.parentStudentTab.StatusFlagsTab();
                        break;


                    case "COMMENTS/HISTORY":
                        TestRunnerInterface.Map.parentStudentTab.CommentsHistoryTab();
                        break;



                    default:
                        error = true;
                        break;

                }

                if (error)
                {
                    throw new Exception("The Tab Name = " + tab + "Is Not Valid Name");
                }

            }

        }



        /// <summary>
        /// Based on the tab name in the tab List
        /// click the application tab
        /// </summary>
        /// <param name="tabList">The tab list.</param>
        public void VerifyStudentFinancePageTabs(List<string> tabList)
        {


            foreach (var tab in tabList)
            {

                bool error = false;

                switch (tab.ToUpper().Trim())
                {
                    case "ALLOCATION FORM":
                        TestRunnerInterface.Map.studentFinanceSearchPage.AllocationFormTab();
                        break;

                    case "PROGRESS REPORT":
                        TestRunnerInterface.Map.studentFinanceSearchPage.ProgressReportTab();
                        break;

                    case "INVOICE":
                        TestRunnerInterface.Map.studentFinanceSearchPage.InvoiceTab();
                        break;

                    case "ACCOUNT SUMMARY":
                        TestRunnerInterface.Map.studentFinanceSearchPage.AccountSummaryTab();
                        break;

                    case "PAYMENT":
                        TestRunnerInterface.Map.studentFinanceSearchPage.PaymentTab();
                        break;

                    case "FINANCE DOCS":
                        TestRunnerInterface.Map.studentFinanceSearchPage.FinanceDocsTab();
                        break;

                    case "FINANCE COMMENTS":
                        TestRunnerInterface.Map.studentFinanceSearchPage.FinanceCommentsTab();
                        break;


                    default:
                        error = true;
                        break;

                }

                if (error)
                {
                    throw new Exception("The Tab Name = " + tab + "Is Not Valid Name");
                }

            }

        }


        /// <summary>
        /// Based on the tab name in the tab List
        /// click the application tab
        /// </summary>
        /// <param name="tabList">The tab list.</param>
        public void VerifyAdminProgramsPageTabs(List<string> tabList)
        {


            foreach (var tab in tabList)
            {

                bool error = false;

                switch (tab.ToUpper().Trim())
                {
                    case "PROGRAM MANAGEMENT":
                        TestRunnerInterface.Map.adminPrograms.ProgramManagementTab();
                        break;

                    case "FUNDING CATEGORY SETUP":
                        TestRunnerInterface.Map.adminPrograms.FundingCategorySetupTab();
                        break;

                    case "BILLING SCHEDULE":
                        TestRunnerInterface.Map.adminPrograms.BillingScheduleTab();
                        break;


                    case "ADDIN/DEDUCT SCHEDULE":
                        TestRunnerInterface.Map.adminPrograms.AddinDeductScheduleTab();
                        break;


                    default:
                        error = true;
                        break;

                }

                if (error)
                {
                    throw new Exception("The Tab Name = " + tab + "Is Not Valid Name");
                }

            }

            //For some reason after the last admin page is displayed
            //the driver can not locate the signout link
            //so for a work-around Refresh the application
            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

        }


    } //end public partial class VerifyPageTabs


} //end namespace AcceptanceTests.PageObjects
