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
using System.IO;

namespace AcceptanceTests.PageObjects
{
    public partial class NewProviderApplication
    {



  
        /// <summary>
        /// Finish New Application Driver
        /// Used passed in Application Data
        /// </summary>
        /// <param name="appData"></param>
        public void FinishApplication(ProviderApplicationData appData)
        {
            //**********************************
            //Define New Application Data
            //string personnelRole;   //PERSONNEL DETAILS CSV string
            //string services;        //Type of service
            //string staff;           //Staff Member CSV string

            //**********************************

            TestRunnerInterface.Map.providerSearchPage.PersonnelTab();             
            foreach (string personnelRole in appData.personnelRoleList)
            {
                TestRunnerInterface.Map.personnel.AddRole(personnelRole);
            }
            //this.RefreshApplication(RunTimeVars.Refresh.PageRefresh);
            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

            //Add Sevices
            TestRunnerInterface.Map.providerSearchPage.ServicesTab();
            foreach (string services in appData.servicesList)
            {
                TestRunnerInterface.Map.servicesTab.AddService(services);
            }
            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

            //Add Staff
            TestRunnerInterface.Map.providerSearchPage.StaffTab();
            foreach (string staff in appData.staffList)
            {
                TestRunnerInterface.Map.staffTab.AddStaff(staff);
            }

            foreach (string services in appData.servicesList)
            {
                TestRunnerInterface.Map.staffTab.AddService(services);
            }
            TestRunnerInterface.Map.staffTab.EditEmployment();
            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

            //Add Docs based on Program Type
            var program = TestRunnerInterface.Map.testContext.program;
            TestRunnerInterface.Map.providerSearchPage.DocsTab();
            this.TestAddDocs(program);
            //this.AddDocs(program);

            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

        }

  
        /// <summary>
        /// Finish New Application Driver
        /// Use hard coded Autism Data
        /// Call the FinishApplication() using the ProviderApplicationData test data
        /// </summary>
        public void FinishApplication()
        {
            this.LoadHardCodedApplicationData();
            this.FinishApplication(TestRunnerInterface.Map.providerApplicationData);

        }

        public void StartApplication()
        {
            //Click menu 
            TestRunnerInterface.Map.menu.NewProviderApplication();
 
            //click terms and conditions:
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //browser.FindElement(By.Id("agreeCheckBox")).Click();
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "agreeCheckBox", RunTimeVars.REPEAT_TIMES);
            element.Click();

            //Set organization
            SelectElement select = new SelectElement(browser.FindElement(By.Id("ddAssociatedOrgs"))); //Locating select list
            select.SelectByText("Create a New Org/Provider"); //Select item from list having option text as "Item1"

            //Start the Application
            browser.FindElement(By.XPath("//*[@id='startApp']/input")).Click();

            //Update New Student Name
            //Get the Last New Student# from filename - RunTimeData.xml
            //Increment to Next Student# 
            //Save the Next Student# back to the xml file
            //Append the Next Student# to the Student Name
            //

            //Get the Last New Student# from filename - RunTimeData.xml        
            //Get program type from Test Context
            string program = TestRunnerInterface.Map.testContext.program;
            int nextStudentNumber = this.CalculateNextProviderNumber(program);

            //Append the Next Student# to the Student Name
            var providerName = "Selenium Test -" + nextStudentNumber.ToString();
     
            //Fill the form Text Fields
            //Name
            //element = browser.FindElement(By.Id("txtName"));
            //Wait for the page element to be displayed
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(providerName);

            //Tax ID#
            element = browser.FindElement(By.Id("txtTaxId"));
            element.SendKeys("123456789");

            //Set County
            select = new SelectElement(browser.FindElement(By.Id("ddDesignatedCounty"))); //Locating select list
            select.SelectByText("Franklin");

            //PHYSICAL ADDRESS
            element = browser.FindElement(By.Id("txtPhysicalAddress"));
            element.SendKeys("123 Main St");

            //City
            element = browser.FindElement(By.Id("txtPhysicalCity"));
            element.SendKeys("Columbus");

            //Set State
            select = new SelectElement(browser.FindElement(By.Id("ddOedsStates"))); //Locating select list
            select.SelectByText("OH");

            //Zip Code
            element = browser.FindElement(By.Id("txtPhysicalZip"));
            element.SendKeys("43219");

            //Zip Code + 4
            element = browser.FindElement(By.Id("txtPhysicalZip4"));
            element.SendKeys("1234");

            //MAILING ADDRESS Same as Physical
            element = browser.FindElement(By.Id("cbSameAsPhysical"));
            element.Click();

            //Save the form
            element = browser.FindElement(By.XPath("//*[@id='saveForm']/div/div/input"));
            element.Click();

            //Over-Ride Dialog Displayed
            if (this.IsOverRideDisplayed(RunTimeVars.REPEAT_TIMES))
            {
                IWebElement cancelButton = browser.FindElement(By.XPath("//span[text()='Cancel']"));
                IWebElement overrideButton = browser.FindElement(By.XPath("//span[text()='Override']"));

                //cancelButton.Click();
                overrideButton.Click();

            }

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

            //Wait for General tab to be displayed
            TestRunnerInterface.Map.general.AssertGeneralTabDisplay(RunTimeVars.REPEAT_TIMES);
 
        }


        public Boolean IsOverRideDisplayed(int retrys)
        {
            var isDisplayed = false;
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    IWebElement element = browser.FindElement(By.Id("ui-dialog-title-dialogSystemMessage"));
                    if (element.Displayed)
                    {
                        isDisplayed = true;
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
                isDisplayed = false;
            }

            return isDisplayed;
        }


        /// <summary>
        /// Get the Last New Student# based on the program type
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public int CalculateNextProviderNumber(string program)
        {
            bool error = false;
            var programKey = string.Empty;

            switch (program.ToUpper())
            {
                case "AUTISM":
                    programKey = "Autism Provider Last New#";
                    break;

                case "JPSN":
                    programKey = "JPSN Provider Last New#";
                    break;

                default:
                    error = true;
                    break;

            }

            if (error)
            {
                throw new Exception("Program Type = " + program + "Not Implemented");
            }

            //Get the Last New Student# from filename - RunTimeData.xml
            var lastNewStudent = RunTimeData.GetKeyConfigSectionData(programKey);
            var nextStudentNumber = Int32.Parse(lastNewStudent);
            nextStudentNumber++;
            //Save the Next Student# back to the xml file
            RunTimeData.UpdateKeyConfigSectionData(programKey, nextStudentNumber.ToString());

            return nextStudentNumber;

        }



        /// <summary>
        /// Tests the add docs. based on Program Type
        /// </summary>
        /// <param name="program">The program.</param>
        public void TestAddDocs(string program = "NA")
        {
            //Reference the upload file in the project
            //var pathFileName = @"C:\Save\Upload File1.txt";
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            var pathFileName = fileDir + "Upload File1.txt";

            //this.AddInsuranceCopy();
            TestRunnerInterface.Map.docsTab.FileUpload("Insurance Copy", pathFileName, "Insurance Copy");

            //this.AddProofofAddress();
            TestRunnerInterface.Map.docsTab.FileUpload("Proof of Address", pathFileName, "Proof of Address");

            //this.AddTaxIDFormW9();
            TestRunnerInterface.Map.docsTab.FileUpload("Tax ID Form (W-9)", pathFileName, "Tax ID Form (W-9)");

            //this.AddFeesSchedule();
            TestRunnerInterface.Map.docsTab.FileUpload("Fees Schedule", pathFileName, "Fees Schedule");

            //this.AddPolicyManualElectronicCopy();
            TestRunnerInterface.Map.docsTab.FileUpload("Policy Manual (Electronic Copy)", pathFileName, "Policy Manual (Electronic Copy)");

            //this.AddOtherElectronicDocument();
            TestRunnerInterface.Map.docsTab.FileUpload("Other Electronic Document", pathFileName, "Other Electronic Document");

            //this.AddHealthAndSafety();
            TestRunnerInterface.Map.docsTab.FileUpload("Health and Safety", pathFileName, "Health and Safety");

            //Only add these 2-files for Program Type = Autism
            if (program.Equals("Autism", StringComparison.OrdinalIgnoreCase))
            {
                //this.AddCapitalAndCreditStatement();
                TestRunnerInterface.Map.docsTab.FileUpload("Capital and Credit Statement", pathFileName, "Capital and Credit Statement");

                //this.AddSuretyBond();
                TestRunnerInterface.Map.docsTab.FileUpload("Surety Bond", pathFileName, "Surety Bond");
            }

            TestRunnerInterface.Map.docsTab.ClickSaveAndRefresh();


        }

        /// <summary>
        /// Adds the docs. based on Program Type
        /// </summary>
        /// <param name="program">The program.</param>
        public void AddDocs(string program = "NA")
        {
            TestRunnerInterface.Map.docsTab.AddInsuranceCopy();
            TestRunnerInterface.Map.docsTab.AddProofofAddress();
            TestRunnerInterface.Map.docsTab.AddTaxIDFormW9();
            TestRunnerInterface.Map.docsTab.AddFeesSchedule();
            TestRunnerInterface.Map.docsTab.AddPolicyManualElectronicCopy();
            TestRunnerInterface.Map.docsTab.AddOtherElectronicDocument();
            TestRunnerInterface.Map.docsTab.AddHealthAndSafety();

            //Only add these 2-files for Program Type = Autism
            if (program.Equals("Autism", StringComparison.OrdinalIgnoreCase))
            {
                TestRunnerInterface.Map.docsTab.AddCapitalAndCreditStatement();
                TestRunnerInterface.Map.docsTab.AddSuretyBond();
            }



            TestRunnerInterface.Map.docsTab.ClickSaveAndRefresh();

        }

        public void LoadHardCodedApplicationData()
        {
            TestRunnerInterface.Map.providerApplicationData.hardCodedData = true;

            TestRunnerInterface.Map.providerApplicationData.personnelRoleList.Add("stautnom096263,scholar,12/31/2010,Nominator-Autism");
            TestRunnerInterface.Map.providerApplicationData.servicesList.Add("Adapted Physical Education Services");
            TestRunnerInterface.Map.providerApplicationData.servicesList.Add("Aide Services");
            TestRunnerInterface.Map.providerApplicationData.staffList.Add("Lynn,Cosmo,01/01/2001");
        }



     } //end public partial class NewProviderApplication


    /// <summary>
    /// class to hold New Provider Application daata
    /// </summary>
    public class ProviderApplicationData
    {
        public bool hardCodedData = true;
        public List<string> personnelRoleList = new List<string>();
        public List<string> servicesList = new List<string>();
        public List<string> staffList =  new List<string>();

    }

} //end namespace AcceptanceTests.PageObjects
