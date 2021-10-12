using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using AcceptanceTests.Common.Application;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Config;
using AcceptanceTests.Interface;
using OpenQA.Selenium;



namespace AcceptanceTests.PageObjects
{
    public partial class StatusFlagsTab
    {


        /// <summary>
        /// Before the status is Updated
        /// the status element is located in a //span not a //div
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(string status)
        {
            //Approve the staff list
            if (status.ToUpper().Equals("UNDER REVIEW"))
            {
                TestRunnerInterface.Map.providerSearchPage.StaffTab();
                TestRunnerInterface.Map.staffTab.StaffDataApproved();

                //Keep the previous status, we haven't updated it yet
                Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);
 
            }


            //Switch to Status/Flags Tab
            TestRunnerInterface.Map.providerSearchPage.StatusFlagsTab();

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //IWebElement submitted = browser.FindElement(By.XPath("//div[text()='Submitted']"));
            var query = "//span[text()='" + status + "']";
            //IWebElement submitted = browser.FindElement(By.XPath(query));
            IWebElement submitted = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, query, RunTimeVars.REPEAT_TIMES);

            submitted.Click();


            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);
 
        }

        public void SetScholarshipStatus(string status)
        {

            //Switch to Status/Flags Tab
            TestRunnerInterface.Map.providerSearchPage.StatusFlagsTab();

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //IWebElement submitted = browser.FindElement(By.XPath("//div[text()='Submitted']"));
            var query = "//span[text()='" + status + "']";
            //IWebElement submitted = browser.FindElement(By.XPath(query));
            IWebElement submitted = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, query, RunTimeVars.REPEAT_TIMES);

            submitted.Click();


            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);
 


        }


        /// <summary>
        /// After the status is Updated
        /// the status element is located in a //div not a //span
        /// </summary>
        /// <param name="status"></param>
        /// <param name="retrys"></param>
        public void AssertStatus(string status, int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
         
            while (controlWaitTime > 0)
            {
                try
                {
                    //Assert Page Status
                    //IWebElement submitted = browser.FindElement(By.XPath("//div[text()='Submitted']"));
                    var query = "//div[text()='" + status + "']";
                    IWebElement element = browser.FindElement(By.XPath(query));

                    if (element.Displayed)
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
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                }
            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Page Status = " + status + " Not Displayed");
            }

        }

        public bool IsPageTextDisplayed(string text, int retrys)
        {

            bool isFound = false;
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    var pageText = browser.FindElement(By.TagName("body")).Text;
                    if (pageText.IndexOf(text, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        isFound = true;
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
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                }
            }

            return isFound;
        }


        public void AssertStatusFlagsTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Assert Page Status
                    IWebElement element = browser.FindElement(By.Id("tab-5"));

                    if (element.Displayed)
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
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                }
            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Status/Flags Tab Is Not Displayed");
            }

        }


    } //end public partial class StatusFlags



} //end namespace AcceptanceTests.PageObjects
