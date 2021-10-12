using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;
using AcceptanceTests.Common.Library;



namespace AcceptanceTests.PageObjects
{
    public partial class ProgramSelectionPage
    {

        public void ProgramSelection(string program, bool waitForSearchPage = true)
        {
            //Check if program = blank or empty
            // or the program = NA
            if (string.IsNullOrEmpty(program)) return;
            if (program.ToUpper().Equals("NA")) return;
            if (program.ToUpper().Equals("NONE")) return;

            //Wait for PROGRAM AND ORGANIZATION SELECTION 
            if (IsProgramSelectionDisplayed(RunTimeVars.REPEAT_TIMES))
            {
                //If (multiple organizations are displayed
                if (this.IsMultipleOrganizationsDisplayed())
                {
                    this.SetProgramAndOrganization(program);

                    IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
                    browser.FindElement(By.Id("continue")).Click();
                }
            }

            //if(PROGRAM SELECTION Multiple Blocks page displayed)
            else if (IsAvailableProgramSelectionDisplayed())
            {
                this.SelectProgram(program);

            }

            if (waitForSearchPage)
            {
                //Wait for PROVIDER SEARCH PAGE
                TestRunnerInterface.Map.providerSearchPage.WaitForProviderSearch(RunTimeVars.REPEAT_TIMES);
            }
            
        }


        /// <summary>
        /// To speed up test execution by not having to wait
        /// for the web driver to timeout, when the page text 
        /// is not displayed, do (3)-page text checks
        /// Check if("PROGRAM AND ORGANIZATION SELECTION" = displayed)
        /// of if (Please select one of the available programs = displayed)
        ///  or if (PROVIDER SEARCH PAGE  = displayed)
        ///  
        ///Use implicit wait and initialize the timeout. When a quick response is required
        ///1. Reinitialize the wait timeout = 0-secs, 
        ///2. Wait for the page control operation to complete
        ///3. Reinitialize the wait timeout back = original timeout 
        //
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public bool IsProgramSelectionDisplayed(int timeout)
        {
            bool IsProgramSelection = false;
            bool IsAvailableProgramSelection = false;
            bool IsSearchPage = false;

            Libary.SetWebDiverWaitTime(0);
            var controlWaitTime = timeout;

            while (controlWaitTime > 0)
            {

                //Search for PROGRAM AND ORGANIZATION SELECTION Page
                IsProgramSelection = this.IsProgramOrganizationSelectionDisplayed();

                IsAvailableProgramSelection = this.IsAvailableProgramSelectionDisplayed();

                //Search for PROVIDER SEARCH PAGE
                IsSearchPage = TestRunnerInterface.Map.providerSearchPage.IsSeachPageDisplayed();

                if ((IsProgramSelection) || IsAvailableProgramSelection || (IsSearchPage))
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(1*1000); //Wait 1-sec
                    controlWaitTime--;
                    continue;
                }

            }

            Libary.ReSetWebDiverWaitTime();
            return IsProgramSelection;

        }

        public bool IsProgramOrganizationSelectionDisplayed()
        {
            bool isFound = false;

            try
            {
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
                var pageText = browser.FindElement(By.TagName("body")).Text;

                if (pageText.IndexOf("PROGRAM AND ORGANIZATION SELECTION", StringComparison.OrdinalIgnoreCase) > 0)
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

        public bool IsAvailableProgramSelectionDisplayed()
        {
            bool isFound = false;

            try
            {
                Libary.SetWebDiverWaitTime(0);
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
                var pageText = browser.FindElement(By.TagName("body")).Text;

                if (pageText.IndexOf("Please select one of the available programs", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    isFound = true;
                }
            }
            catch
            {
                isFound = false;
            }

            Libary.ReSetWebDiverWaitTime();

            return isFound;
        }


        public bool IsMultipleOrganizationsDisplayed()
        {
            bool isFound = false;

            try
            {
                Libary.SetWebDiverWaitTime(0);
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
                var pageText = browser.FindElement(By.TagName("body")).Text;

                if (pageText.IndexOf("You are currently associated with more than one organization", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    isFound = true;
                }
            }
            catch
            {
                isFound = false;
            }

            Libary.ReSetWebDiverWaitTime();

            return isFound;
        }

        /// <summary>
        /// Set ORGANIZATION and PROGRAM
        /// </summary>
        public void SetProgramAndOrganization(string program)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //If (multiple organizations are displayed
            //Set ORGANIZATION: 
            //IWebElement org = browser.FindElement(By.Id("ddlOrgs"));
            IWebElement org = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ddlOrgs", RunTimeVars.REPEAT_TIMES);
            SelectElement orgElement = new SelectElement(org);
            
            //Date - 10/14/2015
            //Attempt #1 - don't modify the the current organization
            //Accept the default, Only change the program
            //orgElement.DeselectByIndex(0);

            //orgElement.SelectByIndex(1);
            //System.Threading.Thread.Sleep(1 * 1000);
            //orgElement.SelectByIndex(0);

            //Set Program
            //IWebElement programType = browser.FindElement(By.Id("ddlProgs"));
            IWebElement programType = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "ddlProgs", RunTimeVars.REPEAT_TIMES);
            SelectElement programElement = new SelectElement(programType);
            //orgElement.DeselectByIndex(0);
            //System.Threading.Thread.Sleep(1 * 1000);

            //programElement.SelectByIndex(1);
            //programElement.SelectByIndex(0);

            bool error = false;
            var programString = string.Empty;

            switch (program.ToUpper())
            {
                case "AUTISM":
                      programString = "Autism Scholarship (Autism)";
                      break;

                case "CLEVELAND":
                    programString = "Cleveland Scholarship (Cleveland)";
                    break;

                case "EDCHOICE":
                    programString = "Educational Choice Scholarship (EdChoice)";
                    break;

                case "EDCHOICE-EXP":
                     programString = "Educational Choice Scholarship Expansion (EdChoice-Exp)";
                     break;

                case "JPSN":
                    programString = "Jon Peterson Special Needs Scholarship (JPSN)";
                    break;

                default:
                    error = true;
                    break;

            }

            if (error)
            {
                throw new Exception("The Program Type = " + program + "Is Not Valid Name");
            }

            programElement.SelectByText(programString);
            //programElement.SelectByValue("13");

        }


        /// <summary>
        /// Select a specific Scholarship program
        /// </summary>
        /// <param name="program"></param>
        public void SelectProgram(string program)
        {
            bool error = false;
            var searchString = string.Empty;

            switch (program.ToUpper())
            {
                case "AUTISM":
                    //searchString = "//input[@type='submit' and @value='Autism Scholarship (Autism)']";
                    searchString = "//input[contains(@value,'(Autism)')]";
                    break;

                case "CLEVELAND":
                    //searchString = "//input[@type='submit' and @value='Cleveland Scholarship (Cleveland)']";
                    searchString = "//input[contains(@value,'(Cleveland)')]";
                    break;

                case "EDCHOICE":
                    //searchString = "//input[@type='submit' and @value='Educational Choice Scholarship  (EdChoice)']";
                    searchString = "//input[contains(@value,'(EdChoice)')]";
                    break;

                case "EDCHOICE-EXP":
                    //searchString = "//input[@type='submit' and @value='Educational Choice Scholarship Expansion (EdChoice-Exp']";
                    searchString = "//input[contains(@value,'(EdChoice-Exp)')]";
                    break;

                case "JPSN":
                    //searchString = "//input[@type='submit' and @value='Jon Peterson Special Needs Scholarship (JPSN)']";
                    searchString = "//input[contains(@value,'(JPSN)')]";
                    break;

                case "HOME SCHOOL":
                    //searchString = "//input[@type='submit' and @value="College Credit Plus - Home School";
                    searchString = "//input[contains(@value,'Home School')]";
                    break;

                case "NONPUBLIC":
                    //searchString = "//input[@type='submit' and @value="College Credit Plus - Nonpublic";
                    searchString = "//input[contains(@value,'Nonpublic')]";
                    break;




                default:
                    error = true;
                    break;

            }

            if (error)
            {
                throw new Exception("The Program Type = " + program + "Is Not Valid Name");
            }

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Orginal Xpath search
            //IWebElement element  = browser.FindElement(By.XPath("//input[@type='submit' and @value='Autism Scholarship (Autism)']"));
            IWebElement element = browser.FindElement(By.XPath(searchString));
            element.Click();
        }


    } //end public partial class ProgramSelectionPage

} //end namespace AcceptanceTests.PageObjects
