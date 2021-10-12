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
    public partial class AdvancedStudentSearchPage
    {

        public void WaitForStudentSearch(int retrys)
        {

            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {

                try
                {
                    var pageText = browser.FindElement(By.TagName("body")).Text;
                    if (pageText.IndexOf("ADVANCED STUDENT SEARCH PAGE", StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000); //Wait 1-sec
                        controlWaitTime--;
                    }

                }
                catch
                {
                    //Empty catch
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("ADVANCED STUDENT SEARCH PAGE Page Not Displayed");
            }

        }


        public bool IsSeachPageDisplayed()
        {
            bool isFound = false;

            try
            {
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
                var pageText = browser.FindElement(By.TagName("body")).Text;

                if (pageText.IndexOf("ADVANCED STUDENT SEARCH PAGE", StringComparison.OrdinalIgnoreCase) > 0)
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


            //Xpath locator Multiple records Row(1), Col(15) 1-based
            //*[@id="myTable"]/tbody/tr[1]/td[15]/a/img
            //
            //Xpath locator 1-record    
            //*[@id="myTable"]/tbody/tr/td[15]/a/img

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
                        //query = "//*[@id="myTable"]/tbody/tr/td[15]/a/img";
                        query =   "//*[@id='myTable']/tbody/tr/td[" + colCount.ToString() + "]/a/img";
                    }
                    else
                    {
                        //Xpath locator Multiple records
                        //query = " //*[@id="myTable"]/tbody/tr[1]/td[15]/a/img";
                        query =   "//*[@id='myTable']/tbody/tr[" + record.ToString() + "]/td[" + colCount.ToString() + "]/a/img";
                    }

                    //Libary.WaitForElementByXpath(browser, query, RunTimeVars.PAGELOADWAIT);
                    //System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec

                    //IWebElement element = browser.FindElement(By.XPath(query));
                    IWebElement element = Libary.GetPageElement(browser,RunTimeVars.ELEMENTSEARCH.XPATH,query ,RunTimeVars.REPEAT_TIMES);
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
                throw new Exception("Advanced Student Search Results Not Displayed");
            }

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

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

            //Set Status
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            SelectElement select = new SelectElement(browser.FindElement(By.Id("ddlRptPer"))); //Locating select list
            select.SelectByText(peroid);
        }

        public void SetFirstName(string name)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtFirstName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(name);

        }

        public void SetLastName(string name)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtLastName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(name);

        }

        public void Search()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //*[@id="Search"]
            IWebElement element = browser.FindElement(By.Id("Search"));
            //Displays runtime error
            //  Message=unknown error: Element is not clickable at point (734, 457). 
            // Other element would receive the click
            element.Click();
            // Resolution - Use Actions Class
            //Actions action = new Actions(browser);
            //action.MoveToElement(element).Click().Perform();


            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }

        public void Reset()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //<input type="button" tabindex="19" value="Reset" onclick="ResetForm();">
            //*[@id="tabBasicSearch"]/table/tbody/tr[11]/td/input[2]
            IWebElement tabBasicSearch = browser.FindElement(By.Id("tabBasicSearch"));
            IWebElement reset = tabBasicSearch.FindElement(By.XPath("//input[@type='button' and @value='Reset']"));

            reset.Click();

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }




    } //end public partial class AdvancedStudentSearchPage



} //end namespace AcceptanceTests.PageObjects
