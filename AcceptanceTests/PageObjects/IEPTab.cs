using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Common.Application;
using OpenQA.Selenium.Interactions;



namespace AcceptanceTests.PageObjects
{
    public partial class IEPTab
    {

        /// <summary>
        /// Add New IEP Driver
        /// </summary>
        public void AddNewIEP()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement addNewIEP = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "//input [@type='submit'] [@value='Add new IEP']", RunTimeVars.REPEAT_TIMES);
            addNewIEP.Click();

            //Wait for page to Load
            Libary.WaitForPageText(browser, "IEP Information", RunTimeVars.REPEAT_TIMES);

            //Set IEP Start Date: = current Date
            var date = DateTime.Today.ToString("MM/dd/yyyy");
            this.SetIEPStartDate(date);


            //Set IEP End Date: = current Date + 1-year
            date = DateTime.Today.AddDays(365).ToString("MM/dd/yyyy");
            this.SetIEPEndDate(date);

            //Set Date of Last Evaluation: = current Date - 1-year
            date = DateTime.Today.AddDays(-365).ToString("MM/dd/yyyy");
            this.SetDateofLastEvalation(date);

            //Primary Disability Condition
            this.SetPrimaryDisabilityCondition("Autism");

            //Add Available Services
            this.AddService("Aide Services");

            //Save the data
            this.AddButton().Click();
   
            //Wait for IEP Tab to be displayed
            this.WaitForIEPTabDisplay(RunTimeVars.REPEAT_TIMES);

            IWebElement serviceFinalized = this.ServiceFinalized();
            serviceFinalized.Click();

            //*****************************************************
            //Debug the dialog 
            // Try #1
            //When Service Finalized buuton is clicked
            // a seperate popup is displayed, with the same
            // browser handle
            // The popup is NOT a seperate window
            //just part of the current browser
            //It has no attributes on the controls to search
            //The OK button has focus, so just send a Enter key
            // to the current browser
            //*****************************************************
            //The windows handles are the same
            //var currentWindow = browser.CurrentWindowHandle;
            //Number of availableWindows = 1
            //var availableWindows = new List<string>(browser.WindowHandles);

            //The OK button has focus, so just send a Enter key
            // to the current browser
            //Actions action = new Actions(browser);
            //action.SendKeys(Keys.Enter).Perform();

            //Result - Exception Popup displayed

            // Try #2
            //The OK button has focus, so just send a Enter key
            // to the Service Finalized button
            //serviceFinalized.SendKeys(Keys.Enter);
            //Result - Same behavior Exception Popup displayed

            // Try #3
            //Handle Unknown Alerts
            //IAlert is an Interface to handle Javascripts alerts
            IAlert alert = browser.SwitchTo().Alert();
            alert.Accept(); //Accept the Alert, same as pressing OK button
            //alert.Dismiss(); //Don't Accept the Alert, same as pressing Cancel button


        }


        public void SetIEPStartDate(string date)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtiepStartDate", RunTimeVars.REPEAT_TIMES);
            element.Clear();
            element.SendKeys(date + Keys.Enter);

        }

        public void SetIEPEndDate(string date)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtiepEndDate", RunTimeVars.REPEAT_TIMES);
            element.Clear();
            element.SendKeys(date + Keys.Enter);

        }

        public void SetDateofLastEvalation(string date)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtiepLastEvalDate", RunTimeVars.REPEAT_TIMES);
            element.Clear();
            element.SendKeys(date + Keys.Enter);

        }

        public void SetPrimaryDisabilityCondition(string condition)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement primaryDisabilityCondition = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ddlDisabilityCategory", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(primaryDisabilityCondition);
            select.SelectByText(condition); //Select item from list having option text as "Item1"

        }

        public void AddService(string service)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Select the service
            IWebElement availableSelected = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "availableSelected", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(availableSelected);
            select.SelectByText(service); //Select item from list having option text as "Item1"
            
            //Unless this wait time is added
            //a Run-time exception is displayed
            //Another control would receive the click event ???
            System.Threading.Thread.Sleep(1 * 1000);

            //Add the services
            IWebElement addServicesControl = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "addServiceButton", RunTimeVars.REPEAT_TIMES);
            IWebElement addServices = addServicesControl.FindElement(By.XPath("//input[@type='button'][@name='addServiceButton']"));
            //IWebElement addServices = browser.FindElement(By.XPath("//*[@id='addServiceButton']"));

            //Libary.HighLight(browser, addServices);
            addServices.Click();

            //Run-time error displayed, Had to add action class 
            //Actions action = new Actions(browser);
            //action.MoveToElement(addServices).Click().Build().Perform();
            //Libary.ClickElement(browser, addServices, true, RunTimeVars.REPEAT_TIMES);

        }

        public IWebElement AddButton()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement add = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "AddIEP", RunTimeVars.REPEAT_TIMES);

            return add;

        }

        public IWebElement CancelButton()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement cancel = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "Cancel", RunTimeVars.REPEAT_TIMES);

            return cancel;

        }


        public IWebElement ServiceFinalized()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement divTable = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "viewIepDiv", RunTimeVars.REPEAT_TIMES);
            IWebElement element = divTable.FindElement(By.XPath("//span[contains(text(), 'Service Finalized')]"));

            return element;

        }







        public void WaitForIEPTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Verify Student Information Edit
                    IWebElement iepEdit = browser.FindElement(By.Id("updateIEPInformationDialog"));

                    //Verify SSID STATUS
                    var pageText = browser.FindElement(By.TagName("body")).Text;

                    if ((iepEdit.Displayed && iepEdit.Enabled)
                        && (pageText.Contains("CURRENT IEP STATUS")))
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
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
                throw new Exception("IEP Tab Is Not Displayed");
            }

        }




    }


}
