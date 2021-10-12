using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;
using AcceptanceTests.Common.Library;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace AcceptanceTests.PageObjects
{
    public partial class Menu
    {
        //*************************
        // Menu Parent = Provider
        //*************************
        public void SearchProvider()
        {
            this.ClickMenuIJavaScript("Provider", "Search Provider");
            //this.ClickMenuActions("Provider", "Search Provider");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);
        }

        public void NewProviderApplication()
        {
            this.ClickMenuIJavaScript("Provider", "New Provider Application");
            //this.ClickMenuActions("Provider", "New Provider Application");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);
        }

        public void RenewProviderApplication()
        {
            this.ClickMenuIJavaScript("Provider", "Renew Provider Application");
            //this.ClickMenuActions("Provider", "Renew Provider Application");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        //*************************
        // Menu Parent = Student
        //*************************
        public void SearchCCPApplication()
        {
            this.ClickMenuIJavaScript("Student", "Search College Credit Plus Application");
            //this.ClickMenuActions("Student", "Search College Credit Plus Application");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void SearchStudent()
        {
            this.ClickMenuIJavaScript("Student", "Search Student");
            //this.ClickMenuActions("Student", "Search Student");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        public void SearchScholarshipApplication()
        {
            this.ClickMenuIJavaScript("Student", "Search Scholarship Application");
            //this.ClickMenuActions("Student", "Search Scholarship Application");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void SearchIncomeVerification()
        {
            this.ClickMenuIJavaScript("Student", "Search Income Verification");
            //this.ClickMenuActions("Student", "Search Income Verification");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void NewScholarshipApplication()
        {
            this.ClickMenuIJavaScript("Student", "New Scholarship Application");
            //this.ClickMenuActions("Student", "New Scholarship Application");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void RenewScholarshipApplication()
        {
            this.ClickMenuIJavaScript("Student", "Renew Scholarship Application");
            //this.ClickMenuActions("Student", "Renew Scholarship Application");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        public void ApplicationStatusSummary()
        {
            this.ClickMenuIJavaScript("Student", "Application Status Summary");
            //this.ClickMenuActions("Student", "Application Status Summary");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        public void StudentSSIDVerification()
        {
            this.ClickMenuIJavaScript("Student", "Student SSID verification");
            //this.ClickMenuActions("Student", "Student SSID verification");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void StudentAssessmentPreIDExport()
        {
            this.ClickMenuIJavaScript("Student", "Assessment Pre-ID Export");
            //this.ClickMenuActions("Student", "Assessment Pre-ID Export");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void StudentProgramTransfer()
        {
            this.ClickMenuIJavaScript("Student", "Student Program Transfer");
            //this.ClickMenuActions("Student", "Student Program Transfert");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        //*************************
        // Menu Parent = Finance
        //*************************
        public void FinanceSearch()
        {
            this.ClickMenuIJavaScript("Payment", "Finance Search");
            //this.ClickMenuActions("Payment", "Finance Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void InvoiceSearch()
        {
            this.ClickMenuIJavaScript("Payment", "Invoice Search");
            //this.ClickMenuActions("Payment", "Invoice Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void RefundPayment()
        {
            this.ClickMenuIJavaScript("Payment", "Refund Payment");
            //this.ClickMenuActions("Payment", "Refund Payment");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void PaymentSearch()
        {
            this.ClickMenuIJavaScript("Payment", "Payment Search");
            //this.ClickMenuActions("Payment", "Payment Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void BulkAttendance()
        {
            this.ClickMenuIJavaScript("Payment", "Bulk Attendance");
            //this.ClickMenuActions("Payment", "Bulk Attendance");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void FoundationSearch()
        {
            this.ClickMenuIJavaScript("Payment", "Foundation Search");
            //this.ClickMenuActions("Payment", "Foundation Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        //**************************************
        // Menu Parent = Compliance
        //**************************************
        public void ComplianceSearch()
        {
            this.ClickMenuIJavaScript("Compliance", "Compliance Search");
            //this.ClickMenuActions("Compliance", "Compliance Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void ScheduleSearch()
        {
            this.ClickMenuIJavaScript("Compliance", "Schedule Search");
            //this.ClickMenuActions("Compliance", "Schedule Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void IssueCAPSearch()
        {
            this.ClickMenuIJavaScript("Compliance", "Issue/CAP Search");
            //this.ClickMenuActions("Compliance", "Issue/CAP Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }
        public void TechnicalAssistanceSearch()
        {
            this.ClickMenuIJavaScript("Compliance", "Technical Assistance Search");
            //this.ClickMenuActions("Compliance", "Technical Assistance Search");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        //**************************************
        // Menu Parent = Admin
        //**************************************

        public void AdminPrograms()
        {
            this.ClickMenuIJavaScript("Admin", "Programs");
            //this.ClickMenuActions("Admin", "Programs");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void AdminNotifications()
        {
            this.ClickMenuIJavaScript("Admin", "Notifications");
            //this.ClickMenuActions("Admin", "Notifications");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }
        public void AdminBulkEmail()
        {
            this.ClickMenuIJavaScript("Admin", "Bulk Email");
            //this.ClickMenuActions("Admin", "Bulk Email");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void AdminLetters()
        {
            this.ClickMenuIJavaScript("Admin", "Letters");
            //this.ClickMenuActions("Admin", "Letters");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void AdminGenerateLetters()
        {
            this.ClickMenuIJavaScript("Admin", "Generate Letters");
            //this.ClickMenuActions("Admin", "Generate Letters");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }
        public void AdminPaymentBatch()
        {
            this.ClickMenuIJavaScript("Payment", "Payment Batch");
            //this.ClickMenuActions("Payment", "Payment Batch");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }
        public void AdminDesignatedSchool()
        {
            //Date 3/5/16
            // Can not click this menu option
            // The Parent menu locator "Student" has the same "Student" locator name as the other menu
            // sub-menu names
            //Need a code change to rename the menu parent names
            //Admin - Designated School
            //< a href = "https://scholarshipqa.ode.state.oh.us/Student/DesignatedSchool/Search" > Designated School </ a >
            //
            //Student - Search Student
            //< a href = "https://scholarshipqa.ode.state.oh.us/Student/Home/Index/1" > Search Student </ a >
    

           //this.ClickMenuIJavaScript("Student", "Designated School");
           //this.ClickMenuActions("Student", "Designated School");

           //Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void AdminComplianceManagement()
        {
            this.ClickMenuIJavaScript("Compliance", "Compliance Management");
            //this.ClickMenuActions("Compliance", "Compliance Management");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }
        public void AdminRefundBatch()
        {
            this.ClickMenuIJavaScript("Payment", "Refund Batch");
            //this.ClickMenuActions("Payment", "Refund Batch");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void AdminConsultantAssignment()
        {
            this.ClickMenuIJavaScript("Admin", "Consultant Assignment");
            //this.ClickMenuActions("Admin", "Consultant Assignment");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        //**************************************
        // Menu Parent = User Manuals and Forms
        //**************************************
        public void UserManualsAndForms()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            browser.FindElement(By.LinkText("User Manuals and Forms")).Click();

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);
        }

        //*************************
        // Menu Parent = Contacts
        //*************************
        public void AutismEmailContact()
        {
            this.ClickMenuIJavaScript("Contacts", "Autism Email Contact");
            //this.ClickMenuActions("Contacts", "Autism Email Contact");

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void EdChoiceEmailContact()
        {
            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //browser.FindElement(By.LinkText("EdChoice Email Contact")).Click();


            //Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);
        }


        /// <summary>
        /// Use actions to move the move to the Menu item
        /// </summary>
        /// <param name="topMenu"></param>
        /// <param name="submenu"></param>
        public void ClickMenuActions(string topMenu, string submenu)
        {

            //Date - 9/11/15
            //This works in Chrome
            //This doesn't work in Firefox or IE, timesout 

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find parent menu item
            //IWebElement element = browser.FindElement(By.LinkText("Provider"));
            IWebElement element = browser.FindElement(By.LinkText(topMenu));

            // Move cursor to the Main Menu Element
            Actions action = new Actions(browser);
            action.MoveToElement(element).ClickAndHold().Build().Perform();

            /***************** orginal code ****************************
            //9/11/15 comment out the orginal Thread.Sleep(1000 / 2);
            //and browser.FindElement(By.LinkText(submenu)).Click();
            //and replace it with Explicit Wait
            
            // Giving .5 Secs for submenu to be displayed
            Thread.Sleep(1000 / 2);

            // Clicking on the Hidden SubMenu
            //browser.FindElement(By.LinkText("New Provider Application")).Click();
            browser.FindElement(By.LinkText(submenu)).Click();
            
             ***************** orginal code  ******************************/

            //Wait for submenu item using Explicit Wait
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));
            // Find the submenu using Explicit Wait
            IWebElement element2 = wait.Until(x => x.FindElement(By.LinkText(submenu)));

            action.MoveToElement(element2).ClickAndHold().Build().Perform();

            // Clicking on the Hidden SubMenu
            element2.Click();

        }


        /// <summary>
        /// Use IJavaScriptExecutor to move the move to the Menu item
        /// </summary>
        public void ClickMenuIJavaScript(string topMenu, string submenu)
        {
            //Date - 9/11/15
            //This works in Chrome, Firefox
            //This doesn't work in IE, timesout 

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Create query string
            string query = "return $(\"a:contains('" + topMenu + "')\").mouseover();";    //this works
            //string query = "return $(\"a:contains('" + topMenu + "')\").hover();";        //this did not work
            //string query = "return $(\"a:contains('" + topMenu + "')\").mouseenter();";     //this works

            //Find parent menu item
            // Mouse hove to main menu 
            var jsDriver = (IJavaScriptExecutor)browser;
            //jsDriver.ExecuteScript("return $(\"a:contains('Provider')\").mouseover();");
            jsDriver.ExecuteScript(query);

            /***************** orginal code ****************************
            /9/11/15 comment out the orginal Thread.Sleep(1000 / 2);
            //and browser.FindElement(By.LinkText(submenu)).Click();
            //and replace it with Explicit Wait
            // Giving 1/2 Secs for submenu to be displayed
            Thread.Sleep(1000 / 2);

            // Clicking on the Hidden SubMenu
            //browser.FindElement(By.LinkText("New Provider Application")).Click();
            browser.FindElement(By.LinkText(submenu)).Click();
            
            ***************** orginal code ****************************/

            //Wait for submenu item using Explicit Wait
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));
            // Find the submenu using Explicit Wait
            IWebElement element2 = wait.Until(x => x.FindElement(By.LinkText(submenu)));

            //Find submenu item
            // Mouse hove to sub menu 
            //Create query string
            query = "return $(\"a:contains('" + submenu + "')\").mouseover();";
            jsDriver.ExecuteScript(query);

            // Clicking on the Hidden SubMenu
            element2.Click();
        }

    } //end public partial class Menu


}  //end namespace AcceptanceTests.PageObjects
