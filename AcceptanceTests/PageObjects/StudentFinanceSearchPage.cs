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
    public partial class StudentFinanceSearchPage
    {


        public void BasicSearchTab()
        {
            this.ClickLink("BASIC SEARCH");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "APPLICATION ID", RunTimeVars.REPEAT_TIMES);

        }

        public void AllocationFormTab()
        {
            this.ClickLink("ALLOCATION FORM");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Student Information", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Student", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Primary Guardian", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Application Period", RunTimeVars.REPEAT_TIMES);


        }


        public void ProgressReportTab()
        {
            this.ClickLink("PROGRESS REPORT");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verify the #cols displayed
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Determine Table #Col Width max #Cols
            //IWebElement table = browser.FindElement(By.Id("tblProgressReports"));
            IWebElement table = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "tblProgressReports", RunTimeVars.REPEAT_TIMES);
            ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
            ReadOnlyCollection<IWebElement> tableColumns = table.FindElements(By.TagName("th"));

            //Get Table #records
            var rowCount = tableRows.Count;
            var colCount = tableColumns.Count;

            //Check Table #Columns
            if(colCount != 6)
            {
                throw new Exception("The table #Columns Expected = 6 " +
                                        "The Actual table #Columns = " + colCount);
            }


        }

        public void InvoiceTab()
        {
            this.ClickLink("INVOICE");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verify the #cols displayed
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Invoice Information", RunTimeVars.REPEAT_TIMES);

            //Determine Table #Col Width max #Cols
            //IWebElement table = browser.FindElement(By.Id("myTable"));
            IWebElement table = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "myTable", RunTimeVars.REPEAT_TIMES);
            ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
            ReadOnlyCollection<IWebElement> tableColumns = table.FindElements(By.TagName("th"));

            //Get Table #records
            var rowCount = tableRows.Count;
            var colCount = tableColumns.Count;

            //Check Table #Columns
            if (colCount != 14)
            {
                throw new Exception("The table #Columns Expected = 14 " +
                                        "The Actual table #Columns = " + colCount);
            }

        }

        public void AccountSummaryTab()
        {
            this.ClickLink("ACCOUNT SUMMARY");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verify the #cols displayed
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Account Information", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Provider Name", RunTimeVars.REPEAT_TIMES);

            //Determine Table #Col Width max #Cols
            //IWebElement table = browser.FindElement(By.Id("tblAccInfo"));
            IWebElement table = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "tblAccInfo", RunTimeVars.REPEAT_TIMES);
            ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
            ReadOnlyCollection<IWebElement> tableColumns = table.FindElements(By.TagName("th"));

            //Get Table #records
            var rowCount = tableRows.Count;
            var colCount = tableColumns.Count;

            //Check Table #Columns
            //The Total #columns = the sum of both tables
            //Account Information table #columns = 7
            //Provider Name table #columns = 6
            //The sum of both tables = 6+7 = 13

            var colTotal = 6 + 7;
            if (colCount != colTotal)
            {
                throw new Exception("The table #Columns Expected = " + colTotal +
                                        "The Actual table #Columns = " + colCount);
            }


        }

        public void PaymentTab()
        {
            this.ClickLink("PAYMENT");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verify the #cols displayed
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Determine Table #Col Width max #Cols
            //IWebElement table = browser.FindElement(By.Id("PaymentList"));
            IWebElement table = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "PaymentList", RunTimeVars.REPEAT_TIMES);
  
            //Determine Table #Col Width max #Cols
            ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
            ReadOnlyCollection<IWebElement> tableColumns = table.FindElements(By.TagName("th"));

            //Get Table #records
            var rowCount = tableRows.Count;
            var colCount = tableColumns.Count;

            if (colCount != 9)
            {
                throw new Exception("The table #Columns Expected = 9 " +
                                        "The Actual table #Columns = " + colCount);
            }


        }

        public void FinanceDocsTab()
        {
            this.ClickLink("FINANCE DOCS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verify the #cols displayed
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "DOCUMENTS", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "DOCUMENTS ON FILE", RunTimeVars.REPEAT_TIMES);


        }


        public void FinanceCommentsTab()
        {
            this.ClickLink("FINANCE COMMENTS");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            //Verify the #cols displayed
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Comments Summary", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Comments", RunTimeVars.REPEAT_TIMES);


        }







        public void WaitForStudentFinanceSearch(int retrys)
        {

            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {

                try
                {
                    var pageText = browser.FindElement(By.TagName("body")).Text;
                    if (pageText.IndexOf("STUDENT FINANCE SEARCH PAGE", StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(5 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }

                }
                catch
                {
                    //Empty catch
                    System.Threading.Thread.Sleep(5 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("STUDENT FINANCE SEARCH PAGE Not Displayed");
            }

        }


        public bool IsStudentFinanceSearchPageDisplayed()
        {
            bool isFound = false;

            try
            {
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
                var pageText = browser.FindElement(By.TagName("body")).Text;

                if (pageText.IndexOf("STUDENT FINANCE SEARCH PAGE", StringComparison.OrdinalIgnoreCase) > 0)
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
            browser.FindElement(By.Id("Search")).Click();

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        public void SetApplicationPeroid(string peroid)
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement appPeroid = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ddlRptPer", RunTimeVars.REPEAT_TIMES);
            SelectElement element = new SelectElement(appPeroid);

            element.SelectByText(peroid);


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


            //Row(1) = Table header
            //Row(2) = start of search results
            //(1)-record displayed Row(1) Col(12) 1-based
            //*[@id="myTable"]/tbody/tr/td[12]/a/img

            //Multiple records displayed Row(1) Col(12) 1-based
            //*[@id="myTable"]/tbody/tr[1]/td[12]/a/img

            var controlWaitTime = RunTimeVars.REPEAT_TIMES;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            var query = string.Empty;

            while (controlWaitTime > 0)
            {
                try
                {

                    //Determine Table #Col Width max #Cols
                    IWebElement table = browser.FindElement(By.Id("myTable"));
                    ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
                    ReadOnlyCollection<IWebElement> tableColumns = table.FindElements(By.TagName("th"));

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
                        //query = "//*[@id="myTable"]/tbody/tr/td[12]/a/img"
                        query = "//*[@id='myTable']/tbody/tr/td[" + colCount.ToString() + "]/a/img";
                    }
                    else
                    {
                        //Xpath locator Multiple records
                        //*[@id="myTable"]/tbody/tr[1]/td[12]/a/img
                        //query = "//*[@id='myTable']/tbody/tr[" + record.ToString() + "]/td[15]/a/img";
                        query = "//*[@id='myTable']/tbody/tr[" + record.ToString() + "]/td[" + colCount.ToString() + "]/a/img";
                    }

                    //IWebElement element = browser.FindElement(By.XPath(query));
                    IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, query, RunTimeVars.REPEAT_TIMES);
                    element.Click();

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
                throw new Exception("STUDENT FINANCE SEARCH PAGE Results Not Displayed");
            }

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

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


















    } //end public partial class StudentFinanceSearchPage

} //end namespace AcceptanceTests.PageObjects
