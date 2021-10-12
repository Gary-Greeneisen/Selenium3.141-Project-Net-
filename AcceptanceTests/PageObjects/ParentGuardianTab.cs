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
using System.Collections.ObjectModel;


namespace AcceptanceTests.PageObjects
{
    public partial class ParentGuardianTab
    {


        /// <summary>
        /// Add New Guardian Driver
        /// Parse the Staff CSV string by
        /// First name, last name, DOB
        /// </summary>
        /// <param name="staff"></param>
        public void AddNewGuardian(string guardian)
        {

            //this.AddNewGuardian("Matthew,Woods,05/23/1973,Father");
            string[] results = guardian.Split(',');
            this.AddNewGuardian(results[0], results[1], results[2], results[3]);
             
            //Wait for page to laod
            this.AssertGuardianDisplayed(RunTimeVars.REPEAT_TIMES);
        }


        public void AddNewGuardian(string firstName
                                    , string lastName
                                    , string DOB
                                    , string relationship)
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //click the Add New Guardian button
            IWebElement newGuardianButton = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "addNewGuardian", RunTimeVars.REPEAT_TIMES);
            newGuardianButton.Click();

            //1-Search Results
            //Name: Matthew Woods
            //Date Of Birth: 05/23/1973 

            //1-Search Results
            //Name: WENDY WILLIAMS
            //Date Of Birth: 12/06/1962 

            //First Name
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtFirstName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(firstName);

            //Last Name
            element = browser.FindElement(By.Id("txtLastName"));
            element.SendKeys(lastName);

            //DOB
            element = browser.FindElement(By.Id("txtDateofBirth"));
            element.SendKeys(DOB + Keys.Enter);

            //Click Search Button
            //Orginal deep nested Parnet-Child trees
            //IWebElement search = browser.FindElement(By.XPath("/html/body/div[56]/div[11]/div/button[1]/span"));
            IWebElement search = this.Search();
            IWebElement cancel = this.Reset();

            search.Click();

            //Select Guardian Search Results
            this.GuardianReview(relationship);


        }

        /// <summary>
        /// At the Guardian Review page
        /// Update and Assign A Guardian
        /// </summary>
        public void GuardianReview(string relationship)
        {
            //Slect First Name
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.LinkText, "Select", RunTimeVars.REPEAT_TIMES);
            element.Click();

            //Set Middle Name
            // if(Middle Name == blank)
            //Set Guardian does not have Middle Name = Checked
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtGuardianMiddleName", RunTimeVars.REPEAT_TIMES);
            var text = element.Text;
            if(string.IsNullOrEmpty(text))
            {      
                element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "chbGuardianNoMiddleName", RunTimeVars.REPEAT_TIMES);
                if (!element.Selected)
                {
                    element.Click();
                }
            }

            //Set Last four digits of SSN#
            // if(Last four digits of SSN# == blank)
            //Set Never issued an SSN = Checked
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtGuardianLast4SSN", RunTimeVars.REPEAT_TIMES);
            text = element.Text;
            if(string.IsNullOrEmpty(text))
            {
                element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "chbGuardianNoSsn", RunTimeVars.REPEAT_TIMES);
                if (!element.Selected)
                {
                    element.Click();
                }
            }

            //Set Relationship
            SelectElement select = new SelectElement(browser.FindElement(By.Id("ddlRelationship"))); //Locating select list
            select.SelectByText(relationship);

            //Locate the Assign Guardian button
            //<span class="ui-button-text">Assign Guardian</span>
            //html/body/div[14]/div[11]/div/button[1]/span
            //
            //Locate the dialog at //html/body/div[14]
            IWebElement dialog = browser.FindElement(By.Id("dialog-GuardianPreview"));

            //Locate the page element at //html/body/div[14]
            //this should be the same location as the IWebElement dialog 
            IWebElement test = browser.FindElement(By.XPath("//html/body/div[14]"));

            IWebElement assignGuardian = dialog.FindElement(By.XPath("//span[text()='Assign Guardian']"));
            assignGuardian.Click();


        }



        public IWebElement Search()
        {

            //Orginal XPath locator
            //Search
            //<input type="button" value="Search" onclick="validateSearchForm()">
            //*[@id="myTable"]/table/tbody/tr[3]/td/input[1]

            //Reset
            //<input type="button" value="Reset" onclick="this.form.reset()">
            //*[@id="myTable"]/table/tbody/tr[3]/td/input[2]

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement myTable = browser.FindElement(By.Id("myTable"));
            IWebElement search = myTable.FindElement(By.XPath("//input[@type='button' and @value='Search']"));

            return search;

        }

        public IWebElement Reset()
        {

            //Orginal XPath locator
            //Search
            //<input type="button" value="Search" onclick="validateSearchForm()">
            //*[@id="myTable"]/table/tbody/tr[3]/td/input[1]

            //Reset
            //<input type="button" value="Reset" onclick="this.form.reset()">
            //*[@id="myTable"]/table/tbody/tr[3]/td/input[2]

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find dialog form parent element
            IWebElement myTable = browser.FindElement(By.Id("myTable"));
            IWebElement reset = myTable.FindElement(By.XPath("//input[@type='button' and @value='Reset']"));
            return reset;

        }

        /// <summary>
        /// Wait for the page elements to be displayed
        /// Edit Primary Guardian (Displayed & Enabled)
        /// Edit Current Home Physical Address (Displayed & Enabled)
        /// Edit Current Home Mailing Address (Displayed & Enabled)
        /// </summary>
        /// <param name="retrys"></param>
        public void AssertGuardianDisplayed(int retrys)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            var controlWaitTime = retrys;
  
            while (controlWaitTime > 0)
            {
                try
                {
                    IWebElement divGuardianDetails = browser.FindElement(By.Id("divGuardianDetails"));
                    IWebElement editPrimaryGuardian =  divGuardianDetails.FindElement(By.XPath("//img[@alt = 'update primary']"));
                    IWebElement homeAddress = divGuardianDetails.FindElement(By.XPath("//img[@alt = 'update primary address']"));
                    IWebElement mailingAddress = divGuardianDetails.FindElement(By.XPath("//img[@alt = 'update primary mailing address']"));

                    if ((editPrimaryGuardian.Displayed && editPrimaryGuardian.Enabled)
                        && (homeAddress.Displayed && homeAddress.Enabled)
                        && (mailingAddress.Displayed && mailingAddress.Enabled))
                    {
                        break;
                    }

                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                 }

                catch
                {
                      System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                      controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Parent/Guardian Page Not Displayed with Retrys = " + retrys);
            }

      }















    } //end public partial class ParentGuardianTab



} //end namespace AcceptanceTests.PageObjects
