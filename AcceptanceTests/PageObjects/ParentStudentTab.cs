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
    public partial class ParentStudentTab
    {



        public void ParentSearchTab()
        {
            this.ClickLink("PARENT SEARCH");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "APPLICATION ID", RunTimeVars.REPEAT_TIMES);

        }

        public void StudentTab()
        {
            this.ClickLink("STUDENT");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Student Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Student Information ", RunTimeVars.REPEAT_TIMES);
            //Libary.WaitForPageText(browser, "Student Home Mailing Address", RunTimeVars.REPEAT_TIMES);


        }


        public void ParentGuardianTab()
        {
            this.ClickLink("PARENT / GUARDIAN");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Parent Guardian Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Students", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Primary Guardian", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Current Home Physical Address", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Current Home Mailing Address", RunTimeVars.REPEAT_TIMES);


        }

        public void ApplicationTab()
        {
            this.ClickLink("APPLICATION");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for APPLICATION Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Application Information", RunTimeVars.REPEAT_TIMES);
            //Libary.WaitForPageText(browser, "Legal District of Residency", RunTimeVars.REPEAT_TIMES);
            //Libary.WaitForPageText(browser, "List of Colleges/Universities", RunTimeVars.REPEAT_TIMES);
   
        }

        public void IEPTab()
        {
            this.ClickLink("IEP");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Page Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "CURRENT IEP STATUS", RunTimeVars.REPEAT_TIMES);
 
        }


        public void CreditHoursTab()
        {
            this.ClickLink("CREDIT HOURS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Credit Hours Table to be displayed
            TestRunnerInterface.Map.creditHoursTab.WaitForCreditHoursTable(RunTimeVars.REPEAT_TIMES);

        }

        public void DocsTab()
        {
            this.ClickLink("DOCS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Docs Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "DOCUMENTS ON FILE", RunTimeVars.REPEAT_TIMES);


        }

        public void StatusFlagsTab()
        {
            this.ClickLink("STATUS / FLAGS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Page Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "CURRENT APPLICATION STATUS", RunTimeVars.REPEAT_TIMES);


        }

        public void CommentsHistoryTab()
        {
            this.ClickLink("COMMENTS / HISTORY");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);


            //Wait for Page Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Comments Summary", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Comments", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "History", RunTimeVars.REPEAT_TIMES);


        }








        private void ClickLink(string link)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //IWebElement element = browser.FindElement(By.LinkText(link));
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.LinkText, link, RunTimeVars.REPEAT_TIMES);

            //tab.Click();
            //Actions actions = new Actions(browser);
            //actions.MoveToElement(element).Click().Perform();

            element.Click();


            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
        }

        private void TabLoadWait()
        {
            //Wait additional time for tab to load
            System.Threading.Thread.Sleep(RunTimeVars.TABLOADWAIT * 1000);

        }







    } //end public partial class ParentStudentTab



} //end namespace AcceptanceTests.PageObjects
