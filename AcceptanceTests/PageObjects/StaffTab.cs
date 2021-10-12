using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Common.Application;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace AcceptanceTests.PageObjects
{
    public partial class StaffTab
    {

        /// <summary>
        /// Add Staff Driver
        /// Parse the Staff CSV string by
        /// First name, last name, DOB
        /// </summary>
        /// <param name="staff"></param>
        public void AddStaff(string staff)
        {

            //this.AddStaff("Lynn", "Cosmo", "01/01/2001");
            string[] results = staff.Split(',');

            this.AddStaff(results[0], results[1], results[2]);

        }


        /// <summary>
        /// Add Service Driver
        /// </summary>
        public void AddService()
        {
            this.AddService("Adapted Physical Education Services");
            this.AddService("Aide Services");

        }




        public void AddStaff(string firstName
                                    ,string lastName
                                    ,string DOB)
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //click the Add Staff button
            //browser.FindElement(By.Id("addNewStaffDialog")).Click();
            IWebElement staffButton = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "addNewStaffDialog", RunTimeVars.REPEAT_TIMES);
            staffButton.Click();

            //1-Search Results
            //Name: Susan Cosmo
            //Date Of Birth: 09/30/1965 

            //6-Search Results
            //Name: Lynn Cosmo
            //Date Of Birth: 01/01/2001 

            //Libary.WaitForElementByID(browser, "searchStaffFName", RunTimeVars.PAGELOADWAIT);

            //First Name
            //IWebElement element = browser.FindElement(By.Id("searchStaffFName"));
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "searchStaffFName", RunTimeVars.REPEAT_TIMES);
            //element.SendKeys("Susan");
            //element.SendKeys("Lynn");
            element.SendKeys(firstName);

            //Last Name
            element = browser.FindElement(By.Id("searchStaffLName"));
            //element.SendKeys("Cosmo");
            //element.SendKeys("Cosmo");
            element.SendKeys(lastName);

            //DOB
            element = browser.FindElement(By.Id("searchStaffDob"));
            //element.SendKeys("09/30/1965" + Keys.Enter);
            //element.SendKeys("01/01/2001" + Keys.Enter);
            element.SendKeys(DOB + Keys.Enter);
 
            //Click Search Button
            //Orginal deep nested Parnet-Child trees
            //IWebElement search = browser.FindElement(By.XPath("/html/body/div[56]/div[11]/div/button[1]/span"));
            IWebElement search = this.AddStaffSearch();
            IWebElement cancel = this.AddStaffCancel();

            search.Click();

            //Select Search Results
            this.SelectSearchResults(1);

        }


        private void SelectSearchResults(int number)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            Libary.WaitForElementByXpath(browser, "//input[@type='button' and @value='Add']", RunTimeVars.PAGELOADWAIT);

            ReadOnlyCollection<IWebElement> addButtons = browser.FindElements(By.XPath("//input[@type='button' and @value='Add']"));
            var count = addButtons.Count;

            if (count == 1)
            {
                addButtons[0].Click();
            }
            else
            {
                addButtons[--number].Click();
            }


        }

        public void AddService(string service)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Click Add Service Link
            //IWebElement element = browser.FindElement(By.XPath("//input[contains(.,'Edit services provided')]"));
            //IWebElement element = browser.FindElement(By.XPath("//*[@id='Staff-Services-View']/table/tbody/tr/td/fieldset/legend/input"));

            //Libary.WaitForElementByXpath(browser, "//input[@src ='/Provider/Content/Images/update.gif']", RunTimeVars.PAGELOADWAIT);
            //IWebElement element = browser.FindElement(By.XPath("//input[@src ='/Provider/Content/Images/update.gif']"));

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "//input[@src ='/Provider/Content/Images/update.gif']", RunTimeVars.REPEAT_TIMES);
            element.Click();

            //Select the service
            //Libary.WaitForElementByID(browser, "availableSelected", RunTimeVars.PAGELOADWAIT);
            //SelectElement select = new SelectElement(browser.FindElement(By.Id("availableSelected"))); //Locating select list
            //select.SelectByText("Counseling Services"); //Select item from list having option text as "Item1"

            IWebElement availableSelected = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "availableSelected", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(availableSelected);
            select.SelectByText(service.Trim()); //Select item from list having option text as "Item1"

            //Add the services
            //browser.FindElement(By.Id("addServiceButtonForStaff")).Click();
            IWebElement addServices = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "addServiceButtonForStaff", RunTimeVars.REPEAT_TIMES);
            addServices.Click();

            //Save the Dialog Services
            IWebElement save = this.UpdateServiceSave();
            IWebElement cancel = this.UpdateServiceCancel();

            save.Click();

        }

        public void EditEmployment()
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            var query = "//*[@id='EmploymetDetails']/fieldset/legend/img";

            //Libary.WaitForElementByXpath(browser, query, RunTimeVars.PAGELOADWAIT);
            //Click the Employment Link
            //IWebElement element = browser.FindElement(By.XPath("//input[contains(.,'Edit Employment')]"));
            //IWebElement element = browser.FindElement(By.XPath(query));

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, query,RunTimeVars.REPEAT_TIMES);
            element.Click();

            //Set Employment Start Date = current Date
            //Libary.WaitForElementByName(browser, "StartDate", RunTimeVars.PAGELOADWAIT);
            var date = DateTime.Today.ToString("MM/dd/yyyy");
            //element = browser.FindElement(By.Name("StartDate"));
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.NAME, "StartDate", RunTimeVars.REPEAT_TIMES);
            element.Clear();
            element.SendKeys(date + Keys.Enter);

            //Set Employment End Date = current Date + 1-year
            date = DateTime.Today.AddDays(365).ToString("MM/dd/yyyy");
            //element = browser.FindElement(By.Name("EndDate"));
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.NAME, "EndDate", RunTimeVars.REPEAT_TIMES);
            element.Clear();
            element.SendKeys(date + Keys.Enter);


            //Save Data
            //Libary.WaitForElementByID(browser, "EmploymentSave", RunTimeVars.PAGELOADWAIT);
            //browser.FindElement(By.Id("EmploymentSave")).Click();
            //element = browser.FindElement(By.Id("EmploymentSave"));
            //Libary.HighLight(browser, element);
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "EmploymentSave", RunTimeVars.REPEAT_TIMES);
 
            //Actions action = new Actions(browser);
            //action.MoveToElement(element).Click().Build().Perform();
            //action.MoveToElement(element).ClickAndHold().Build().Perform();

            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("arguments[0].click();", element);

        }

        public void StaffDataApproved()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //browser.FindElement(By.Id("odeapproved")).Click();

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "odeapproved", RunTimeVars.REPEAT_TIMES);
            if (!element.Selected)
            {
                element.Click();
            }

        }


        public void ProfessionalConductIssue()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //browser.FindElement(By.Id("chkApprove")).Click();
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "chkApprove", RunTimeVars.REPEAT_TIMES);
            element.Click();
        }


        public void AssertStaffTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Assert Page Status
                    if (Libary.IsPageTextDIsplayed("indicates ODE Approval needed",1))
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
                    System.Threading.Thread.Sleep(5 * 1000); //Wait 5-sec
                    controlWaitTime--;
                }
            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Staff Tab Is Not Displayed");
            }

        }

        public IWebElement AddStaffSearch()
        {

            //*************************************************************
            // * Another one of those deeply nested Parent-Child Levels
            //1. Find the form by #ID
            //2. Find the Child Save and Cancel buttons
            //     nested below relative to the Parent form #ID
            //**************************************************************

            /**************************************************
            //** Attempt #6 **
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            IWebElement form = browser.FindElement(By.Id("dialog-form2"));

            //Click Search Button
            //Orginal deep nested Parnet-Child trees
            //IWebElement search = browser.FindElement(By.XPath("/html/body/div[56]/div[11]/div/button[1]/span"));
            //IWebElement search = form.FindElement(By.XPath("//div[9]/div/button[1]/span"));
            IWebElement search = form.FindElement(By.XPath("//span[text()='Search']"));
            *******************************************************/
            
            //Date - 10/6/2015 I give up
            //You can find the search button using the XPath expressino above
            //IWebElement search = form.FindElement(By.XPath("//span[text()='Search']"));
            //
            //* Use the Original XPath Locators, relative to the top of the page
            //<span class="ui-button-text">Search</span>
            //html/body/div[56]/div[11]/div/button[1]/span
            
            //Orginal XPath locator
            //Search
            //html/body/div[56]/div[11]/div/button[1]/span
            //Cancel
            //html/body/div[61]/div[11]/div/button[2]/span
            
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement dialogform2 = browser.FindElement(By.Id("ui-dialog-title-dialog-form2"));
            //Move up to (2)-parent dir
            IWebElement parent = dialogform2.FindElement(By.XPath("../.."));

            //This is the same element as //html/body/div[56] or //html/body/div[61]
            //IWebElement test1 = browser.FindElement(By.XPath("//html/body/div[56]"));

            IWebElement search = parent.FindElement(By.XPath("div[11]/div/button[1]/span"));
            //Libary.HighLight(browser, save);

            //IWebElement cancel = parent.FindElement(By.XPath("div[11]/div/button[2]/span"));
            //Libary.HighLight(browser, cancel);

             return search;
        }

        public IWebElement AddStaffCancel()
        {

            //*************************************************************
            // * Another one of those deeply nested Parent-Child Levels
            //1. Find the form by #ID
            //2. Find the Child Save and Cancel buttons
            //     nested below relative to the Parent form #ID
            //**************************************************************

            /**************************************************
            //** Attempt #6 **
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            IWebElement form = browser.FindElement(By.Id("dialog-form2"));

            //Click Search Button
            //Orginal deep nested Parnet-Child trees
            //IWebElement search = browser.FindElement(By.XPath("/html/body/div[56]/div[11]/div/button[2]/span"));
            IWebElement cancel = form.FindElement(By.XPath("//span[text()='Cancel']"));
 
            /**************************************************/

            //Date - 10/6/2015 I give up
            //You can find the search button using the XPath expressino above
            //IWebElement search = form.FindElement(By.XPath("//span[text()='Search']"));
            //
            //* Use the Original XPath Locators, relative to the top of the page
            //<span class="ui-button-text">Search</span>
            //html/body/div[56]/div[11]/div/button[1]/span

            //Orginal XPath locator
            //Search
            //html/body/div[56]/div[11]/div/button[1]/span
            //Cancel
            //html/body/div[61]/div[11]/div/button[2]/span

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement dialogform2 = browser.FindElement(By.Id("ui-dialog-title-dialog-form2"));
            //Move up to (2)-parent dir
            IWebElement parent = dialogform2.FindElement(By.XPath("../.."));

            //This is the same element as //html/body/div[56] or //html/body/div[61]
            //IWebElement test1 = browser.FindElement(By.XPath("//html/body/div[56]"));

            //IWebElement search = parent.FindElement(By.XPath("div[11]/div/button[1]/span"));
            //Libary.HighLight(browser, save);

            IWebElement cancel = parent.FindElement(By.XPath("div[11]/div/button[2]/span"));
            //Libary.HighLight(browser, cancel);

            return cancel;
}

public IWebElement UpdateServiceSave()
{
            /************************************
            //Save the Services
            //Libary.WaitForElementByXpath(browser, "/html/body/div[59]/div[3]/div/button[1]/span", RunTimeVars.PAGELOADWAIT);
            Libary.WaitForElementByXpath(browser, "/html/body/div[30]/div[3]/div/button[1]/span", RunTimeVars.PAGELOADWAIT);
            //element = browser.FindElement(By.XPath("/html/body/div[59]/div[3]/div/button[1]/span"));
            element = browser.FindElement(By.XPath("/html/body/div[30]/div[3]/div/button[1]/span"));
            //element = browser.FindElement(By.XPath("//span[text()='Save']"));
            //element = browser.FindElement(By.XPath("//div[contains(text(),'Save')]/span"));
            element.Click();

            *******************************************/

            //********************************************
            //Locate the Add Services Dialog
            //Based on #Services added the XPath changes
            // 
            //1. Locate the Add Services Dialog
            //2. Locate the Save and Cancel buttons
            //      relative to the Add Services Dialog
            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //IWebElement element1 = browser.FindElement(By.Id("availableSelected"));

            //IWebElement element1 = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "availableSelected", RunTimeVars.REPEAT_TIMES);

            //IWebElement element1 = browser.FindElement(By.Id("ProgProviderApplKey"));
            //Libary.HighLight(browser, element1);

            //Locate the Save button
            //IWebElement element2 = element1.FindElement(By.XPath("//div/button[1]"));
            //IWebElement element2 = element1.FindElement(By.XPath("//div/button[1]/span"));
            //IWebElement element2 = element1.FindElement(By.XPath("//button[contains(text(),'Save')]"));

            //IWebElement element2 = element1.FindElement(By.XPath("//div"));
            //IWebElement element2 = element1.FindElement(By.TagName("div"));

            //IWebElement element2 = element1.FindElement(By.XPath("//div[contains(@class,'ui-dialog-buttonset')][contains(text(),'Save')]"));
            //Libary.HighLight(browser, element2);

            //IWebElement element3 = element2.FindElement(By.XPath("//div"));
            //IWebElement element3 = element2.FindElement(By.TagName("div"));

            //IWebElement element3 = element2.FindElement(By.XPath("//div[contains(@class,'ui-dialog-buttonset')][contains(text(),'Save')]"));
            //Libary.HighLight(browser, element3);

            //IWebElement element2 = element1.FindElement(By.XPath("//div[2]/button[1]/span"));
            //var query = "div[3]/div/button[1]/span";
            //Libary.WaitForElementByXpath(browser, query, RunTimeVars.PAGELOADWAIT);
            //System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
            //IWebElement save = element1.FindElement(By.XPath(query));
            //Libary.HighLight(browser, save);
            //IWebElement save2 = element1.FindElement(By.XPath("//span[text()='Save']"));

            //Orginal XPath locator
            //Dialog Save
            //<span class="ui-button-text">Save</span>
            ///html/body/div[64]/div[3]/div/button[1]/span
            ////
            //Dialog Cancel
            //<span class="ui-button-text">Cancel</span>
            ///html/body/div[64]/div[3]/div/button[2]/span

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement dialogform2 = browser.FindElement(By.Id("ui-dialog-title-dialog-UpdateServicesView"));
            //Move up to (2)-parent dir
            IWebElement parent = dialogform2.FindElement(By.XPath("../.."));

            //This is the same element as //html/body/div[64]
            //IWebElement test1 = browser.FindElement(By.XPath("//html/body/div[64]"));

            IWebElement save = parent.FindElement(By.XPath("div[3]/div/button[1]/span"));
            //Libary.HighLight(browser, save);

            //IWebElement cancel = parent.FindElement(By.XPath("div[3]/div/button[2]/span"));
            //Libary.HighLight(browser, cancel);

            return save;
        }

        public IWebElement UpdateServiceCancel()
        {
            /************************************
            //Save the Services
            //Libary.WaitForElementByXpath(browser, "/html/body/div[59]/div[3]/div/button[1]/span", RunTimeVars.PAGELOADWAIT);
            Libary.WaitForElementByXpath(browser, "/html/body/div[30]/div[3]/div/button[1]/span", RunTimeVars.PAGELOADWAIT);
            //element = browser.FindElement(By.XPath("/html/body/div[59]/div[3]/div/button[1]/span"));
            element = browser.FindElement(By.XPath("/html/body/div[30]/div[3]/div/button[1]/span"));
            //element = browser.FindElement(By.XPath("//span[text()='Save']"));
            //element = browser.FindElement(By.XPath("//div[contains(text(),'Save')]/span"));
            element.Click();

            *******************************************/

            //********************************************
            //Locate the Add Services Dialog
            //Based on #Services added the XPath changes
            // 
            //1. Locate the Add Services Dialog
            //2. Locate the Save and Cancel buttons
            //      relative to the Add Services Dialog
            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //IWebElement element1 = browser.FindElement(By.Id("availableSelected"));
            //IWebElement element1 = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "availableSelected", RunTimeVars.REPEAT_TIMES);

            //IWebElement element1 = browser.FindElement(By.Id("ProgProviderApplKey"));
            //Libary.HighLight(browser, element1);

            //Locate the Save button
            //IWebElement element2 = element1.FindElement(By.XPath("//div/button[1]"));
            //IWebElement element2 = element1.FindElement(By.XPath("//div/button[1]/span"));
            //IWebElement element2 = element1.FindElement(By.XPath("//button[contains(text(),'Save')]"));

            //IWebElement element2 = element1.FindElement(By.XPath("//div"));
            //IWebElement element2 = element1.FindElement(By.TagName("div"));

            //IWebElement element2 = element1.FindElement(By.XPath("//div[contains(@class,'ui-dialog-buttonset')][contains(text(),'Save')]"));
            //Libary.HighLight(browser, element2);

            //IWebElement element3 = element2.FindElement(By.XPath("//div"));
            //IWebElement element3 = element2.FindElement(By.TagName("div"));

            //IWebElement element3 = element2.FindElement(By.XPath("//div[contains(@class,'ui-dialog-buttonset')][contains(text(),'Save')]"));
            //Libary.HighLight(browser, element3);

            //IWebElement element2 = element1.FindElement(By.XPath("//div[2]/button[1]/span"));

            //var query = "div[3]/div/button[2]/span";
            //Libary.WaitForElementByXpath(browser, query, RunTimeVars.PAGELOADWAIT);
            //System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
            //IWebElement cancel = element1.FindElement(By.XPath(query));
            //Libary.HighLight(browser, cancel);
            //IWebElement cancel2 = element1.FindElement(By.XPath("//span[text()='Cancel']"));

            //Orginal XPath locator
            //Dialog Save
            //<span class="ui-button-text">Save</span>
            ///html/body/div[64]/div[3]/div/button[1]/span
            ////
            //Dialog Cancel
            //<span class="ui-button-text">Cancel</span>
            ///html/body/div[64]/div[3]/div/button[2]/span

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement dialogform2 = browser.FindElement(By.Id("ui-dialog-title-dialog-UpdateServicesView"));
            //Move up to (2)-parent dir
            IWebElement parent = dialogform2.FindElement(By.XPath("../.."));

            //This is the same element as //html/body/div[64]
            //IWebElement test1 = browser.FindElement(By.XPath("//html/body/div[64]"));

            //IWebElement save = parent.FindElement(By.XPath("div[3]/div/button[1]/span"));
            //Libary.HighLight(browser, save);

            IWebElement cancel = parent.FindElement(By.XPath("div[3]/div/button[2]/span"));
            //Libary.HighLight(browser, cancel); 
      
            return cancel;
        }





    } //end public partial class Staff


} //end namespace AcceptanceTests.PageObjects
