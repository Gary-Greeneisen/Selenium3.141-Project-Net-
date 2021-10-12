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
    public partial class StudentTab
    {

        /// <summary>
        /// Update SSID Driver
        /// </summary>
        public void UpdateSSID(string program)
        {
            //Update New SSID#
            //Get the Last New SSID# from filename - RunTimeData.xml
            //Increment to Next SSID# 
            //Save the Next SSID# back to the xml file
            //Update the Next SSID# to the Student
            //
            //string program = TestRunnerInterface.Map.testContext.program;
            //var ssn = TestRunnerInterface.Map.newScholarshipApplication.CalculateNextSSNNumber(program);
            //var ssid = TestRunnerInterface.Map.newScholarshipApplication.CalculateSSID(ssn);

            //Get the Last New (9)-char SSID# from filename - RunTimeData.xml
            var ssid = this.CalculateNextStudentSSID(program); 

            //Update the Next SSID# to the Student
            this.EditStudentInfomation();
            this.SetSSID(ssid);

            //Save the data
            this.UpdateStudentButton().Click();

        }

        /// <summary>
        /// Get the Last New Student SSID# based on the program type
        /// Last New Student SSID#  are unique acress all programs
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public string CalculateNextStudentSSID(string program)
        {

            bool error = false;
            string ssidKey = string.Empty;

            switch (program.ToUpper())
            {
                case "AUTISM":
                    ssidKey = "Autism Last SSID#";
                    break;

                case "JPSN":
                    ssidKey = "JPSN Last SSID#";
                    break;

                case "EDCHOICE":
                    ssidKey = "EdChoice Last SSID#";
                    break;


                default:
                    error = true;
                    break;
            }

            if (error)
            {
                throw new Exception("The Program Type = " + program + "Is Not Valid Name");
            }

            //Get the Last New (9)-char SSID# from filename - RunTimeData.xml
            var lastNewSSID = RunTimeData.GetKeyConfigSectionData(ssidKey);
            //get first (2)-char prefix
            var prefix = lastNewSSID.Substring(0, 2);
            var lastNumber = lastNewSSID.Substring(2, 7);

            var nextNumber = Int32.Parse(lastNumber);
            nextNumber++;

            //Format nextStudentSSID = (7)-digits
            var nextStudentSSID = prefix + nextNumber.ToString("0000000");
            //Save the Next SSID# back to the xml file
            RunTimeData.UpdateKeyConfigSectionData(ssidKey, nextStudentSSID);

            return lastNewSSID;

        }
		




        public void EditStudentInfomation()
        {
            //Edit Student Information
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "updateStudentInformation", RunTimeVars.REPEAT_TIMES);
            element.Click();

        }

        public void SetSSID(string ssid)
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtStdntSSID", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(ssid);

        }

        public IWebElement UpdateStudentButton()
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Update Student button
            //<button type="button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
            //role="button" aria-disabled="false"><span class="ui-button-text">Update Student</span></button>

            //Xpath
            //html/body/div[10]/div[11]/div/button[1]

            //Cancel button
            //<button type="button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
            //role="button" aria-disabled="false"><span class="ui-button-text">Cancel</span></button>


            IWebElement updateStudent = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "//span[@class='ui-button-text'] [text()='Update Student']", RunTimeVars.REPEAT_TIMES);
            //Libary.HighLight(browser, updateStudent);

            IWebElement cancel = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "//span[@class='ui-button-text'] [text()='Cancel']", RunTimeVars.REPEAT_TIMES);
            //Libary.HighLight(browser, cancel);

            return updateStudent;


        }


        public IWebElement CancelButton()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Orginal XPath locator
            //Update Student
            //<span class="ui-button-text">Update Student</span>
            ///html/body/div[9]/div[11]/div/button[1]/span

            //Cancel
            //<span class="ui-button-text">Cancel</span>
            ///html/body/div[9]/div[11]/div/button[2]/span
            ///
            IWebElement cancel = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "/html/body/div[9]/div[11]/div/button[2]/span", RunTimeVars.REPEAT_TIMES);
            //Libary.HighLight(browser, cancel);

            return cancel;


        }

        public void WaitForStudentTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Verify Student Information Edit
                    IWebElement studentEdit = browser.FindElement(By.Id("updateStudentInformation"));

                    //Verify SSID STATUS
                    var pageText = browser.FindElement(By.TagName("body")).Text;

                    if ( (studentEdit.Displayed && studentEdit.Enabled)
                        && (pageText.Contains("CURRENT SSID STATUS")) )
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
                throw new Exception("Student Tab Is Not Displayed");
            }

        }


    }



}
