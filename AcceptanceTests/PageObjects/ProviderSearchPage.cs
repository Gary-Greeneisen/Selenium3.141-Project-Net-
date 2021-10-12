using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AcceptanceTests.Common.Library;
//
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace AcceptanceTests.PageObjects
{
    public partial class ProviderSearchPage
    {
        public void WaitForProviderSearch(int retrys)
        {
            //*********** comment out **********
            //Switch from WebDriver Explicit Wait to Implicit Wait

            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //IWebElement element = browser.FindElement(By.Id("Search"));
            //Libary.HighLight(browser, element);

            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {

                try
                {
                    var pageText = browser.FindElement(By.TagName("body")).Text;
                    if (pageText.IndexOf("PROVIDER SEARCH PAGE", StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(5* 1000); //Wait 1-sec
                        controlWaitTime--;
                    }

                }
                catch
                {
                    //Empty catch
                    System.Threading.Thread.Sleep(5*1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Provider Search Page Not Displayed");
            }

        }


        public bool IsSeachPageDisplayed()
        {
            bool isFound = false;

            try
            {
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
                var pageText = browser.FindElement(By.TagName("body")).Text;

                if (pageText.IndexOf("PROVIDER SEARCH PAGE", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    isFound = true;
                }
            }
            catch
            {
                isFound = false;
            }

            return isFound;
        }



        public void Search()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //browser.FindElement(By.Id("btnDFSearch")).Click();
            browser.FindElement(By.Id("Search")).Click();

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        public void SetCounty(string county)
        {

            //Set County
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            SelectElement select = new SelectElement(browser.FindElement(By.Id("ddCountyList"))); //Locating select list
            select.SelectByText(county);
        }

        public void SetApplicationStatus(string status)
        {

            //Set Status
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            SelectElement select = new SelectElement(browser.FindElement(By.Id("listStatus"))); //Locating select list
            select.SelectByText(status);
        }

        public void SetApplicationPeroid(string peroid)
        {

            //Set Peroid
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            SelectElement select = new SelectElement(browser.FindElement(By.Id("ddFY"))); //Locating select list
            select.SelectByText(peroid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        public void SelectRecord(int record)
        {
            //*******************************************************
            //* Date - 9/29/15
            //* This only works in Chrome
            //* For what ever reason, the Firefox driver
            //* hangs and does not click the record details
            //* so the record does not load from the search page
            //
            //* probably due to Xpath locator instead of CSS locator
            //********************************************************


            //Xpath locator Multiple records Row(1), Col(7) 1-based
            //*[@id="myTable"]/tbody/tr[1]/td[7]/a/img
            //
            //Xpath locator 1-record    
            //*[@id="myTable"]/tbody/tr/td[7]/a/img

            var controlWaitTime = RunTimeVars.REPEAT_TIMES;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            var query = string.Empty;

            while (controlWaitTime > 0)
            {
                try
                {
                
                    //Determine Table #Col Width could be Col(7) or Col(8)
                    IWebElement table = browser.FindElement(By.Id("myTable"));
                    //ReadOnlyCollection <IWebElement> rowCollection = table.FindElements(By.XPath("//*[@id='myTable']/tbody/tr"));
                    //Need to subtract (1)-from tableRows because it includes the Column Header Text
                    ReadOnlyCollection <IWebElement> tableRows = table.FindElements(By.TagName("tr"));
                    ReadOnlyCollection <IWebElement> tableColumns = table.FindElements(By.TagName("th"));


                    //Get Table #records
                    //var rowCount = browser.FindElements(By.XPath("//*[@id='myTable']/tbody/tr")).Count;
                    var rowCount = tableRows.Count;
                    rowCount--;
                    var colCount = tableColumns.Count;


                    if (rowCount == 0)
                    {
                        //No records displayed, don't click any record
                        break;
                    }

                    if (rowCount == 1)
                    {
                        //Xpath locator 1-record    
                        //query = "//*[@id='myTable']/tbody/tr/td[7]/a/img";
                        query = "//*[@id='myTable']/tbody/tr/td[" + colCount.ToString() + "]/a/img";
                    }
                    else
                    {
                        //Xpath locator Multiple records
                        //query = "//*[@id='myTable']/tbody/tr[" + record.ToString() + "]/td[7]/a/img";
                        query = "//*[@id='myTable']/tbody/tr[" + record.ToString() + "]/td[" + colCount.ToString() + "]/a/img";
                    }

                    //Libary.WaitForElementByXpath(browser, query, RunTimeVars.PAGELOADWAIT);
                    //System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
         
                    //IWebElement element = browser.FindElement(By.XPath(query));
                    IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, query, RunTimeVars.REPEAT_TIMES);
                    element.Click();
              
                    //System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
          
                    break;
                }
                catch
                {
                    System.Threading.Thread.Sleep(5 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Provider Search Results Not Displayed");
            }

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        //Create call methods to access each Program Tabs
        //<a href="#ui-tabs-1">STUDENT</a>
        //<a href="#ui-tabs-1">GENERAL</a>
        //<a href="#ui-tabs-2">PERSONNEL</a>
        //<a href="#ui-tabs-3">SERVICES</a>
        //<a href="#ui-tabs-4">STAFF</a>
        //<a href="#ui-tabs-5">DOCS</a>
        //<a href="#ui-tabs-6">STATUS / FLAGS</a>
        //<a href="#ui-tabs-7">COMMENTS / HISTORY</a>

        public void StudentTab()
        {
            this.ClickLink("STUDENT");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Student Information Edit Link
            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "updateStudentInformation", RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Student Information", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "CURRENT SSID STATUS:", RunTimeVars.REPEAT_TIMES);



        }
        public void GraduationRequirementsTab()
        {
            this.ClickLink("GRADUATION REQUIREMENTS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "CURRENT STATUS", RunTimeVars.REPEAT_TIMES);

        }


        public void BasicSearchTab()
        {
            this.ClickLink("BASIC SEARCH");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "PROVIDER NAME", RunTimeVars.REPEAT_TIMES);

        }


        public void ParentGuardianTab()
        {
            this.ClickLink("PARENT / GUARDIAN");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Wait for Add New Primary Guardian button 
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "addNewGuardian", RunTimeVars.REPEAT_TIMES);

        }

        public void IncomeVerificationTab()
        {
            this.ClickLink("INCOME VERIFICATION");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Wait for Fiscal Year Listbox
            Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ddlFyHshd", RunTimeVars.REPEAT_TIMES);


            //Wait for Add Household button
            //Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "btnAddHshdForFy", RunTimeVars.REPEAT_TIMES);

        }
        public void ApplicationTab()
        {
            this.ClickLink("APPLICATION");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Legal District of Residency", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "List of Providers", RunTimeVars.REPEAT_TIMES);

        }

        public void CreditHourrsTab()
        {
            this.ClickLink("CREDIT HOURS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verfiy Page Table Headers
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "College", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Term", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "INSTRUCTION DELIVERY TYPE", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "NUMBER OF CREDIT HOURS", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "SELECT", RunTimeVars.REPEAT_TIMES);

        }

        public void StudentSuccessPlanTab()
        {
            this.ClickLink("STUDENT SUCCESS PLAN");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "CURRENT STATUS", RunTimeVars.REPEAT_TIMES);

        }


        public void IEPTab()
        {
            this.ClickLink("IEP");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "CURRENT IEP STATUS", RunTimeVars.REPEAT_TIMES);

        }

        public void GeneralTab()
        {
            this.ClickLink("GENERAL");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            //TestRunnerInterface.Map.general.AssertGeneralTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "PROVIDER/PROGRAM STATUS INFO", RunTimeVars.REPEAT_TIMES);

            this.TabLoadWait();

        }

        public void PersonnelTab()
        {
            this.ClickLink("PERSONNEL");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            //TestRunnerInterface.Map.personnel.AssertPersonnelTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "PERSONNEL DETAILS", RunTimeVars.REPEAT_TIMES);
            //Libary.WaitForPageText(browser, "AVAILABLE ROLES", RunTimeVars.REPEAT_TIMES);
            //Libary.WaitForPageText(browser, "ASSIGNED ROLES", RunTimeVars.REPEAT_TIMES);

            this.TabLoadWait();
        }

        public void ServicesTab()
        {
            this.ClickLink("SERVICES");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            //TestRunnerInterface.Map.services.AssertServicesTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //Libary.WaitForPageText(browser, "Types of Services", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Services Provided", RunTimeVars.REPEAT_TIMES);

            this.TabLoadWait();
        }

        public void StaffTab()
        {
            this.ClickLink("STAFF");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            TestRunnerInterface.Map.staffTab.AssertStaffTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "indicates ODE Approval needed", RunTimeVars.REPEAT_TIMES);

            this.TabLoadWait();
        }

        public void DocsTab()
        {
            this.ClickLink("DOCS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            //TestRunnerInterface.Map.docs.AssertDocsTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "DOCUMENTS ON FILE", RunTimeVars.REPEAT_TIMES);

            this.TabLoadWait();

        }


        public void StatusFlagsTab()
        {
            this.ClickLink("STATUS / FLAGS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            //TestRunnerInterface.Map.statusFlags.AssertStatusFlagsTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "CURRENT APPLICATION STATUS", RunTimeVars.REPEAT_TIMES);

            this.TabLoadWait();

        }

        public void TuitionTab()
        {
            this.ClickLink("TUITION");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Verify School Year Start Date Textbox
            IWebElement schoolStartDate = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "SchoolYearStartDate", RunTimeVars.REPEAT_TIMES);

            //Verify School Year End Date Textbox
            IWebElement schoolEndDate = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "SchoolYearEndDate", RunTimeVars.REPEAT_TIMES);


            /********** comment out ******************
            //Note:
            //Save and Cancel buttons are only displayed for Admin Roles


            //Verify the Save button
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement form = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "tuition-form", RunTimeVars.REPEAT_TIMES);
            IWebElement save = form.FindElement(By.XPath("//input[@type='submit' and @value='Save']"));
            Libary.HighLight(browser, save);

            //Verify the Cancel button
            IWebElement cancel = form.FindElement(By.XPath("//input[@type='button' and @value='Cancel']"));
            Libary.HighLight(browser, cancel);

            ********** comment out ******************/

        }

        public void AssessmentTab()
        {
            this.ClickLink("ASSESSMENT");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Student Information", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "INSTRUCTIONS FOR MANUAL ENTRY", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Student's Assessments", RunTimeVars.REPEAT_TIMES);
            //Libary.WaitForPageText(browser, "Student's Assessment Status", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Student Assessment Comments", RunTimeVars.REPEAT_TIMES);


        }
        public void CommentsHistoryTab()
        {
            this.ClickLink("COMMENTS / HISTORY");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            //TestRunnerInterface.Map.commentsHistory.AssertCommentsHistoryTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Comments Summary", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Comments", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "History", RunTimeVars.REPEAT_TIMES);

            this.TabLoadWait();

        }

        public void ApplicationQuestionsTab()
        {
            this.ClickLink("APPLICATION");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verfiy Question 1 displayed
            //This page uses an IFrame, need to switch to the page IFrame
            //to access any page controls
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find and switch to the iframe tag
            //IWebElement iframe = browser.FindElement(By.TagName("iFrame"));
            IWebElement iframe = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.TagName, "iFrame", RunTimeVars.REPEAT_TIMES);
            browser.SwitchTo().Frame(iframe);

            //Switch to 1st iframe
            //browser.SwitchTo().Frame(0);

            //Switch to 2nd iframe
            //browser.SwitchTo().Frame(1);


            Libary.WaitForPageText(browser, "Question 1", RunTimeVars.REPEAT_TIMES);

            //switch back to orginal window
            browser.SwitchTo().DefaultContent();


        }


        public void ParticipatingBuildingsTab()
        {
            this.ClickLink("PARTICIPATING BUILDINGS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);


            //Verify the #cols displayed
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Determine Table #Col Width max #Cols
            //IWebElement table = browser.FindElement(By.Id("myTable"));
            IWebElement table = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "myTable", RunTimeVars.REPEAT_TIMES);
            ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
            ReadOnlyCollection<IWebElement> tableColumns = table.FindElements(By.TagName("th"));

            //Get Table #records
            var rowCount = tableRows.Count;
            var colCount = tableColumns.Count;

            //Check Table #Columns
            if (colCount != 7)
            {
                throw new Exception("The table #Columns Expected = 7 " +
                                        "The Actual table #Columns = " + colCount);
            }



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

    

    } //end public partial class ProviderSearchPage


} //end namespace AcceptanceTests.PageObjects
