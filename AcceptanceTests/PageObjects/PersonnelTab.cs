using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
//
using AcceptanceTests.Common.Library;
using AcceptanceTests.Common.Application;
using AcceptanceTests.Config;
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace AcceptanceTests.PageObjects
{
    public partial class PersonnelTab
    {

        /// <summary>
        /// Add Roel Driver
        /// Parse the CSV Personal Details into
        /// First name. Last name, DOB, Role
        /// </summary>
        /// <param name="personalDetails"></param>
        public void AddRole(string details)
        {

            //var fName = "stautnom096263";
            //var lName = "scholar";
            //var DOB = "12/31/2010";
            //var role = "Nominator-Autism";
            string[] results = details.Split(',');
    
            //Check if(PERSONNEL DETAILS AVAILABLE ROLES == Displayed)
            //  then AddPersonnel(string role)
            //else
            // AddRole(fName, lName, DOB, role);  
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            if (Libary.IsPageElementDisplayed(browser, RunTimeVars.ELEMENTSEARCH.ID, "availableRoles"))
            {
                this.AddPersonnel(results[3]);
            }
            else
            {
                this.AddRole(results[0], results[1], results[2], results[3]);
            }

        }
        
        /// <summary>
        /// Add the Personnel role
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="DOB"></param>
        public void AddRole(string fName
                                ,string lName
                                ,string DOB
                                ,string role)
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;


            //Add Personnel to display Search Dialog
            IWebElement addNewPersonnelDialog = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "addNewPersonnelDialog", RunTimeVars.REPEAT_TIMES);
            addNewPersonnelDialog.Click();

            //Search for person by name
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "searchFName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(fName);

            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "searchLName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(lName);

            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "searchDob", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(DOB + Keys.Enter);

            //Click Search button
            IWebElement search = this.AddPersonnelSearch();
            IWebElement cancel = this.AddPersonnelCancel();
            search.Click();


            //Select the role
            IWebElement roleTypes = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ddlAssignableRoles1439318", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(roleTypes);
            select.SelectByText(role); //Select item from list having option text as "Item1"

            //click the ADD button
            browser.FindElement(By.Id("1439318")).Click();

            this.AssertAddPersonnel(role, RunTimeVars.REPEAT_TIMES);


        }

        
        /// <summary>
        /// Add Personnel Driver
        /// </summary>
        public void AddPersonnel()
        {
            //<select id="availableRoles" 
            //multiple="multiple" name="availableRoles" style="height:100px; width:210px;">
            //<option value="471">Data Entry Finance-Autism</option>
            //<option value="470">Data Entry Progress Report-Autism</option>
            //<option value="460">Nominator-Autism</option>
            //<option value="462">Primary Contact-Autism</option>
            //</select>

            //*******************************************************************
            //*         *** Date 10/1/2015 work around ***
            //* Splitting the add/remove roles actions into separate methods
            //* and re-locating the web page elements
            //* Still causes the Run-Time Exception to be displayed
            //* Result Message:	OpenQA.Selenium.StaleElementReferenceException : 
            //* stale element reference: element is not attached to the page document
            //*
            //*Resolution
            //* Create a user defined wait for action complete method
            //* private void AssertAddPersonnel(string role, int retrys)
            //* This will Cycle and Wait until the web page elements are
            //* stable and visable
            //*******************************************************************

            this.AddPersonnel("Nominator-Autism");
   
      
        }

        public void AddPersonnel(string role)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Select the Personnel
            //Libary.WaitForElementByID(browser, "availableRoles", RunTimeVars.PAGELOADWAIT);
            //SelectElement select = new SelectElement (browser.FindElement(By.Id("availableRoles"))); //Locating select list

            IWebElement availableRoles = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "availableRoles", RunTimeVars.REPEAT_TIMES);

            SelectElement select = new SelectElement(availableRoles);
            select.SelectByText(role.Trim()); //Select item from list having option text as "Item1"

            //click the transfer button
            IWebElement element1 = browser.FindElement(By.Id("availableRoles"));
            IWebElement add = element1.FindElement(By.XPath("//input[@type='button' and @title='Add role(s)']"));

            //Libary.HighLight(browser, add);
            //add.Click();

            //The button is tied to Javascript onclick event
            //use Javascript to click the button
            //<input type="button" title="Add role(s)" onclick="associatePersonnelRoles(true);" value=">>">
            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("arguments[0].click();", add);


            this.AssertAddPersonnel(role, RunTimeVars.REPEAT_TIMES);


        }

        public void RemovePersonnel(string role)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Select the service
            //Libary.WaitForElementByID(browser, "assignedRoles", RunTimeVars.PAGELOADWAIT);
            //SelectElement select = new SelectElement(browser.FindElement(By.Id("assignedRoles"))); //Locating select list

            IWebElement assignedRoles = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "assignedRoles", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(assignedRoles);
            select.SelectByText(role.Trim()); //Select item from list having option text as "Item1"

            //click the transfer button
            IWebElement element1 = browser.FindElement(By.Id("assignedRoles"));
            IWebElement remove = element1.FindElement(By.XPath("//input[@type='button' and @title='Remove role(s)']"));

            //Libary.HighLight(browser, remove);
            //remove.Click();

            //The button is tied to Javascript onclick event
            //use Javascript to click the button
            //<input type="button" title="Remove role(s)" onclick="associatePersonnelRoles(false);" value="<<">
            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("arguments[0].click();", remove);

            this.AssertRemovePersonnel(role, RunTimeVars.REPEAT_TIMES);


        }

        /// <summary>
        /// Verify the assigned role is added to the Assigned Roles Side
        /// by selecting the added role
        /// </summary>
        /// <param name="role"></param>
        /// <param name="retrys"></param>
        public void AssertAddPersonnel(string role, int retrys)
        {

            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {

                try
                {
                    SelectElement select = new SelectElement(browser.FindElement(By.Id("assignedRoles"))); //Locating select list                 
                    select.SelectByText(role.Trim()); //Select item from list having option text as "Item1"
                    //Unselect all listbox items, in case
                    //the user calls Add Personnel method again
                    select.DeselectAll();
                    break;

                }
                catch
                {
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Role-" + role + "-Not Added To Assigned Roles");
            }

        }

        /// <summary>
        /// Verify the Assigned Roles side is added back to the Avaiable Roles Side
        /// by selecting the removed role
        /// </summary>
        /// <param name="role"></param>
        /// <param name="retrys"></param>
        public void AssertRemovePersonnel(string role, int retrys)
        {

            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {

                try
                {
                    SelectElement select = new SelectElement(browser.FindElement(By.Id("availableRoles"))); //Locating select list                 
                    select.SelectByText(role.Trim()); //Select item from list having option text as "Item1"
                    //Unselect all listbox items, in case
                    //the user calls Add Personnel method again
                    select.DeselectAll();
                    break;

                }
                catch
                {
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Role-" + role + "-Not Added To Available Roles");
            }

        }


        public void AssertPersonnelTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Assert Page Status
                    IWebElement element = browser.FindElement(By.Id("tab-1"));

                    if (element.Displayed)
                    {
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1*1000); //Wait 1-sec
                        controlWaitTime--;
                    }

                }
                catch
                {
                    System.Threading.Thread.Sleep(1*1000); //Wait 1-sec
                    controlWaitTime--;
                }
            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Personnel Tab Is Not Displayed");
            }

        }

        public IWebElement AddPersonnelSearch()
        {

            //*************************************************************
            // * Another one of those deeply nested Parent-Child Levels
            //1. Find the form by #ID
            //2. Find the Child Save and Cancel buttons
            //     nested below relative to the Parent form #ID
            //**************************************************************

            //Orginal page locators
            //<span class="ui-button-text">Search</span>
            ///html/body/div[54]/div[11]/div/button[1]/span

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement dialogform = browser.FindElement(By.Id("ui-dialog-title-dialog-form"));

            //Move up to (2)-parent dir
            IWebElement parent = dialogform.FindElement(By.XPath("../.."));

            //This is the same element as //html/body/div[54]
            //IWebElement test1 = browser.FindElement(By.XPath("//html/body/div[54]"));

            IWebElement search = parent.FindElement(By.XPath("div[11]/div/button[1]/span"));
            //Libary.HighLight(browser, save);

            //IWebElement cancel = parent.FindElement(By.XPath("div[11]/div/button[2]/span"));
            //Libary.HighLight(browser, cancel);

            return search;
        }

        public IWebElement AddPersonnelCancel()
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

            //Orginal page locators
            //<span class="ui-button-text">Cancel</span>
            ///html/body/div[54]/div[11]/div/button[2]/span

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement dialogform = browser.FindElement(By.Id("ui-dialog-title-dialog-form"));

            //Move up to (2)-parent dir
            IWebElement parent = dialogform.FindElement(By.XPath("../.."));

            //This is the same element as //html/body/div[54]
            //IWebElement test1 = browser.FindElement(By.XPath("//html/body/div[54]"));

            //IWebElement search = parent.FindElement(By.XPath("div[11]/div/button[1]/span"));
            //Libary.HighLight(browser, save);

            IWebElement cancel = parent.FindElement(By.XPath("div[11]/div/button[2]/span"));
            //Libary.HighLight(browser, cancel);


            return cancel;
        }




    } //end public partial class Personnel

} //end namespace AcceptanceTests.PageObjects