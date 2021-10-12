using System;
using TechTalk.SpecFlow;
//
using AcceptanceTests.Interface;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class MenuSteps
    {

        [Given(@"I Select Provider Search")]
        public void GivenISelectProviderSearch()
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.menu.SearchProvider();
        }

        [Given(@"I Select Provider ""(.*)""")]
        public void GivenISelectProvider(string search)
        {
            //ScenarioContext.Current.Pending();

            if(search.Equals("Search Provider", StringComparison.OrdinalIgnoreCase))
            {
                TestRunnerInterface.Map.menu.SearchProvider();
            }


        }

        [Given(@"I Select Student ""(.*)""")]
        public void GivenISelectStudent(string search)
        {
            //ScenarioContext.Current.Pending();

            if (search.Equals("Search Student", StringComparison.OrdinalIgnoreCase))
            {
                TestRunnerInterface.Map.menu.SearchStudent();
            }

            if (search.Equals("Search Scholarship Application", StringComparison.OrdinalIgnoreCase))
            {
                TestRunnerInterface.Map.menu.SearchScholarshipApplication();
            }

            if (search.Equals("Search College Credit Plus Application", StringComparison.OrdinalIgnoreCase))
            {
                TestRunnerInterface.Map.menu.SearchCCPApplication();
            }


        }



        [Given(@"I Select Advanced Student Search")]
        public void GivenISelectAdvancedStudentSearch()
        {
            //ScenarioContext.Current.Pending();
        }


        [Given(@"I Select Finance ""(.*)""")]
        public void GivenISelectFinance(string search)
        {
            //ScenarioContext.Current.Pending();
            TestRunnerInterface.Map.menu.FinanceSearch();

        }




        [When(@"I test all menus")]
        public void WhenITestAllMenus()
        {
            //ScenarioContext.Current.Pending();

            //*************************
            // Menu Parent = Provider
            //*************************
            TestRunnerInterface.Map.menu.SearchProvider();
            TestRunnerInterface.Map.menu.NewProviderApplication();
            TestRunnerInterface.Map.menu.RenewProviderApplication();

            //*************************
            // Menu Parent = Student
            //*************************
            TestRunnerInterface.Map.menu.SearchStudent();
            TestRunnerInterface.Map.menu.SearchScholarshipApplication();
            TestRunnerInterface.Map.menu.SearchIncomeVerification();
            TestRunnerInterface.Map.menu.ApplicationStatusSummary();
            TestRunnerInterface.Map.menu.StudentSSIDVerification();
            TestRunnerInterface.Map.menu.StudentAssessmentPreIDExport();
            TestRunnerInterface.Map.menu.StudentProgramTransfer();

            //*************************
            // Menu Parent = Finance
            //*************************
            TestRunnerInterface.Map.menu.FinanceSearch();
            TestRunnerInterface.Map.menu.InvoiceSearch();
            TestRunnerInterface.Map.menu.RefundPayment();
            TestRunnerInterface.Map.menu.PaymentSearch();
            TestRunnerInterface.Map.menu.BulkAttendance();
            TestRunnerInterface.Map.menu.FoundationSearch();

            //**************************************
            // Menu Parent = Compliance
            //**************************************
            TestRunnerInterface.Map.menu.ComplianceSearch();
            TestRunnerInterface.Map.menu.ScheduleSearch();
            TestRunnerInterface.Map.menu.IssueCAPSearch();
            TestRunnerInterface.Map.menu.TechnicalAssistanceSearch();

            //**************************************
            // Menu Parent = Admin
            //**************************************
            TestRunnerInterface.Map.menu.AdminPrograms();
            TestRunnerInterface.Map.menu.AdminNotifications();
            TestRunnerInterface.Map.menu.AdminBulkEmail();
            TestRunnerInterface.Map.menu.AdminLetters();
            TestRunnerInterface.Map.menu.AdminGenerateLetters();
            TestRunnerInterface.Map.menu.AdminPaymentBatch();
            TestRunnerInterface.Map.menu.AdminDesignatedSchool();
            TestRunnerInterface.Map.menu.AdminComplianceManagement();
            TestRunnerInterface.Map.menu.AdminRefundBatch();
            TestRunnerInterface.Map.menu.AdminConsultantAssignment();

            //**************************************
            // Menu Parent = User Manuals and Forms
            //**************************************
            //This opens a new page
            //Don't call unless the new page is closed by the test script
            //TestRunnerInterface.Map.menu.UserManualsAndForms();

            //*************************
            // Menu Parent = Contacts
            //*************************
            TestRunnerInterface.Map.menu.EdChoiceEmailContact();

        }

        [Given(@"I Select Menu ""(.*)""")]
        public void GivenISelectMenu(string menu)
        {
            //ScenarioContext.Current.Pending();
            if(menu.Equals("Admin Programs", StringComparison.OrdinalIgnoreCase))
            {
                TestRunnerInterface.Map.menu.AdminPrograms();
            }

        }





    }
}
