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
using OpenQA.Selenium.Interactions;

namespace AcceptanceTests.PageObjects
{
    public partial class AdminPrograms
    {


        public void ProgramManagementTab()
        {
            this.ClickLink("PROGRAM MANAGEMENT");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Program Information", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Fund Sources", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Notification Information", RunTimeVars.REPEAT_TIMES);

        }
        public void FundingCategorySetupTab()
        {
            this.ClickLink("FUNDING CATEGORY SETUP");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageText(browser, "Funding Categories", RunTimeVars.REPEAT_TIMES);
            Libary.WaitForPageText(browser, "Mappings", RunTimeVars.REPEAT_TIMES);
  
        }

        public void BillingScheduleTab()
        {
            this.ClickLink("BILLING SCHEDULE");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ODEBufferSpace", RunTimeVars.REPEAT_TIMES);
  
        }

        public void AddinDeductScheduleTab()
        {
            this.ClickLink("ADDIN/DEDUCT SCHEDULE");
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ODEBufferSpace", RunTimeVars.REPEAT_TIMES);

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


            //Xpath locator Multiple records Row(1) Col(6)  1-based
            //*[@id="myTable"]/tbody/tr[1]/td[6]/a/img
            //
            //Xpath locator Multiple records Row(3) Col(6)  1-based
            //*[@id="myTable"]/tbody/tr[3]/td[6]/a/img
            //
            //Xpath locator 1-record    
            //*[@id="myTable"]/tbody/tr/td[6]/a/img

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
                        //*[@id="myTable"]/tbody/tr/td[6]/a/img
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
                throw new Exception("Admin Program Results Not Displayed");
            }

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


        private void ClickLink(string link)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //IWebElement element = browser.FindElement(By.LinkText(link));
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.LinkText, link, RunTimeVars.REPEAT_TIMES);

            //To resolve the run-time exception
            //Result Message:System.InvalidOperationException : unknown error: 
            //Element is not clickable at point(671, 312).Other element would receive the click: < div class="ui-widget-overlay" style="width: 1484px; height: 937px; z-index: 1001;"></div>
            //
            //Use actions

            //tab.Click();
            Actions actions = new Actions(browser);
            actions.MoveToElement(element).Click().Perform();

            //element.Click();


            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
        }

        private void TabLoadWait()
        {
            //Wait additional time for tab to load
            System.Threading.Thread.Sleep(RunTimeVars.TABLOADWAIT * 1000);

        }






    } //end public partial class AdminPrograms

} //end namespace AcceptanceTests.PageObjects
