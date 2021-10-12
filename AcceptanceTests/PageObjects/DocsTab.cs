using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using AcceptanceTests.Common.Application;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Config;
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace AcceptanceTests.PageObjects
{
    public partial class DocsTab
    {


        public void ScannedApplicationForm()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("ScannedApplicationForm");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Scanned Application Form", pathFileName, "Scanned Application Form");

        }

        public void  ServiceorGoalsModificationForm()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("ServiceorGoalsModificationForm");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Service or Goals Modification Form", pathFileName, "Service or Goals Modification Form");

        }

        public void AcceptanceForm()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("AcceptanceForm");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Acceptance Form", pathFileName, "Acceptance Form");

        }

        public void IEPElectronicCopy()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("IEP(Electronic copy)");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("IEP (Electronic copy)", pathFileName, "IEP (Electronic copy)");

        }

        public void ProofofCustody()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("ProofofCustody");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Proof of Custody", pathFileName, "Proof of Custody");

        }

        public void ETRElectronicCopy()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("ETR(Electronic copy)");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("ETR", pathFileName, "ETR  (Electronic copy)", true);
        }

        public void BirthCertificate()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("BirthCertificate");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Birth Certificate", pathFileName, "Birth Certificate");

        }

        public void OtherElectronicDocument()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("OtherElectronicDocument");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Other Electronic Document", pathFileName, "Other Electronic Document");

        }

        public void ReconsiderationRequestForm()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("ReconsiderationRequestForm");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Reconsideration Request Form", pathFileName, "Reconsideration Request Form");

        }


        public void AddInsuranceCopy()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("InsuranceCopy");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Insurance Copy", pathFileName, "Insurance Copy");

        }

        public void AddProofofAddress()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("ProofofAddress");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Proof of Address", pathFileName, "Proof of Address");

        }

        public void AddTaxIDFormW9()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("TaxIDFormW-9");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Tax ID Form (W-9)", pathFileName, "Tax ID Form (W-9)");

        }


        public void AddFeesSchedule()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("FeesSchedule");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Fees Schedule", pathFileName, "Fees Schedule");

        }

        public void AddPolicyManualElectronicCopy()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("PolicyManual");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Policy Manual (Electronic Copy)", pathFileName, "Policy Manual (Electronic Copy)");

        }

        public void AddOtherElectronicDocument()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("OtherElectronicDocument");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Other Electronic Document", pathFileName, "Other Electronic Document");

        }

        public void AddHealthAndSafety()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("HealthandSafety");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Health and Safety", pathFileName, "Health and Safety");

        }

        public void AddCapitalAndCreditStatement()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("CapitalAndCreditStatement");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Capital and Credit Statement", pathFileName, "Capital and Credit Statement");

        }

        public void AddSuretyBond()
        {
            var fileDir = AppConfig.GetAppSectionValue("DocsUploadDir");
            var fileName = AppConfig.GetAppSectionValue("SuretyBond");
            var pathFileName = Libary.FormatDir(fileDir, fileName);

            this.FileUpload("Surety Bond", pathFileName, "Surety Bond");

        }


        /// <summary>
        /// Switch browser window to the File UPload Dialog
        /// Populate the data items, uplaod the file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="document"></param>
        public void FileUpload(string linkText, string fileName, string document, bool partialText = false)
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Click the link
            //browser.FindElement(By.LinkText(linkText)).Click();
      
            //*********************************
            // Issue - Opens a new tab
            //Just clicking the link opens the file upload dialog
            // into a new tab on the existing browser
            // This is due to Chrome startup options = open a new tab
            // Can't find the startup options to use existing window ???
            //
            IWebElement element = null;
            
            if (partialText)
            {
                element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.PartialLinkText, linkText, RunTimeVars.REPEAT_TIMES);
            }
            else
            {
                element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.LinkText, linkText, RunTimeVars.REPEAT_TIMES);
            }
            
            element.Click();
            
            //****************************************
            // Try Opening in a seperate dialog
            // Fix-#1 - CLick the file upload link
            // by using Control, Left Click
            //
            //Result - Same behavior
            //
            //Actions actions = new Actions(browser);
            //actions.KeyDown(Keys.Shift).Click(element).Perform();
            //actions.MoveToElement(element).KeyDown(Keys.Shift).Click(element).Perform();
            //actions.MoveToElement(element).DoubleClick().Perform();

            //****************************************
            // Try Set focus to new tab
            // Fix-#2 - Set focus to new tab
            //string url = browser.Url;
            //browser.Navigate().GoToUrl(url);
            //
            // Resolution - 10/17/15
            //The actual issue was the upload window is displayed
            //then the window controls are loaded later
            //had to modify the wait for Upload Dialog window (this.WaitForUploadDialog)
            // to wait for all dialog controls to be displayed
            //

            this.WaitForUploadDialog(browser, RunTimeVars.FILEUPLOADDISPLAY);

            //*********************************************************
            //* Save the current browser window
            //* Search for all open multiple windows
            //* Switch the current browser to the File Upload Dialog
            //* Populate File Upload data items
            //* Switch back to the parent current window
            //**********************************************************
            var currentWindow = browser.CurrentWindowHandle;
            var availableWindows = new List<string>(browser.WindowHandles);
            //Switch browser to File Uplaod Dialog
            //browser.SwitchTo().Window(availableWindows[1]);
            browser.SwitchTo().Window(availableWindows.Last());

            //Enter Upload data
            IWebElement fileLocation = browser.FindElement(By.Id("FileBlob"));
            IWebElement documentName = browser.FindElement(By.Id("DocumentName"));
            fileLocation.SendKeys(fileName);
            documentName.SendKeys(document);

            IWebElement submit = browser.FindElement(By.Id("Submit"));
            submit.Click();

            //Wait for Upload Complete
            this.WaitForUploadComplete(browser, RunTimeVars.FILEUPLOADCOMPLETE);
            browser.Close();


            //Switch browser back to parent window
            browser.SwitchTo().Window(currentWindow);
        }

        private void WaitForUploadComplete(IWebDriver browser, int retrys)
        {
            //*********** comment out **********
            //Switch from WebDriver Explicit Wait to Implicit Wait

            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //IWebElement element = browser.FindElement(By.Id("Search"));
            //Libary.HighLight(browser, element);

            var controlWaitTime = retrys;

            while (controlWaitTime > 0)
            {

                try
                {
                    var pageText = browser.FindElement(By.TagName("body")).Text;
                    if (pageText.IndexOf("The file has been uploaded", StringComparison.OrdinalIgnoreCase) > 0)
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
                throw new Exception("File Upload Complete Not Displayed");
            }

        }

        /// <summary>
        /// Wait until the File Dialog Upload is displayed
        /// Check for File Location textbox, Filename textbox and Upload button
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="retrys"></param>
        private void WaitForUploadDialog(IWebDriver browser, int retrys)
        {

            //*********************************************************
            //* Search for all open multiple windows
            //* Wait until the File Dialog Upload is displayed
            //**********************************************************

            var controlWaitTime = retrys;
            ReadOnlyCollection<string> availableWindows;

            //Save the parent browser
            var currentWindow = browser.CurrentWindowHandle;

            while (controlWaitTime > 0)
            {

                try
                {
                    availableWindows = browser.WindowHandles;
                    if (availableWindows.Count > 1)
                    {
                        //Switch to the new window
                        browser.SwitchTo().Window(availableWindows.Last());

                        //Wait File Location textbox
                        IWebElement fileLocation = browser.FindElement(By.Id("FileBlob"));
                         
                        //Wait for Filename textbox
                        IWebElement documentName = browser.FindElement(By.Id("DocumentName"));
                        
                        //Wait for Upload button
                        IWebElement submit = browser.FindElement(By.Id("Submit"));

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
                throw new Exception("File Upload Dialog Not Displayed");
            }


            //Switch browser back to parent window
            browser.SwitchTo().Window(currentWindow);

        }

        private void Refresh()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find the parent table element
            //Then find child element element
            //Libary.WaitForElementByID(browser, "tblDocumentsOnFile", RunTimeVars.PAGELOADWAIT);
            //IWebElement element1 = browser.FindElement(By.Id("tblDocumentsOnFile"));
    
            IWebElement element1 = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "tblDocumentsOnFile", RunTimeVars.REPEAT_TIMES);
            IWebElement refresh = element1.FindElement(By.XPath("//input[@type='submit' and @value='Refresh']"));

            Libary.HighLight(browser, refresh);
   
            //refresh.Click();
            // Move cursor to the Main Menu Element
            //Actions action = new Actions(browser);
            //action.MoveToElement(refresh).ClickAndHold().Build().Perform();

            //The button is tied to Javascript onclick event
            //use Javascript to click the button
            //<input type="submit" value="Refresh" onclick="OnRefreshClick();">
            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("arguments[0].click();", refresh);

        }



        private void Save()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
 
            //Find the parent table element
            //Then find child element element  
            //Libary.WaitForElementByID(browser, "tblDocumentsOnFile", RunTimeVars.PAGELOADWAIT);
            //IWebElement element1 = browser.FindElement(By.Id("tblDocumentsOnFile"));

            IWebElement element1 = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "tblDocumentsOnFile", RunTimeVars.REPEAT_TIMES);
            IWebElement save = element1.FindElement(By.XPath("//input[@type='submit' and @value='Save']"));

            Libary.HighLight(browser, save);

            //save.Click();

            // Move cursor to the Main Menu Element
            //Actions action = new Actions(browser);
            //action.MoveToElement(save).ClickAndHold().Build().Perform();

            //The button is tied to Javascript onclick event
            //use Javascript to click the button
            //<input type="submit" value="Save" onclick="OnSaveClick();">

            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("arguments[0].click();", save);

        }

        /// <summary>
        /// Determine if(Save and Refresh butttons are displayed)
        /// </summary>
        public void ClickSaveAndRefresh()
        {

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Find the parent table element
            //Then find all child elements relative to the parent table element
            //Find the parent table element
            //IWebElement element1 = browser.FindElement(By.Id("tblDocumentsOnFile"));

            IWebElement table = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "tblDocumentsOnFile", RunTimeVars.REPEAT_TIMES);
            //Then find all child elements relative to the parent table element
            //ReadOnlyCollection<IWebElement> childs = element1.FindElements(By.XPath(".//*"));

            //ReadOnlyCollection<IWebElement> buttons = table.FindElements(By.XPath("tbody/tr[4]/td/input"));
            ReadOnlyCollection<IWebElement> buttons = table.FindElements(By.XPath("//input[@type='submit']"));

            if (buttons.Count == 1)
            {
                //Only Refresh button displayed
                this.Refresh();
          
            }

            else
            {
                //Both Refresh and Save buttons displayed
                //10/1/15 - I had to split these 2-calls apart
                //when you click the refresh button, the web page
                //refreshes and the browser DOM loses reference
                //to the page element and displays the error
                //Message=stale element reference: element is not attached to the page document
                //
                this.Refresh();
                this.Save();

            }

        }

        public void WaitForDocsTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            while (controlWaitTime > 0)
            {
                try
                {
                    //Check for Refresh button
                    IWebElement element1 = browser.FindElement(By.Id("tblDocumentsOnFile"));
                    IWebElement refresh = element1.FindElement(By.XPath("//input[@type='submit' and @value='Refresh']"));

                    //get page text
                    var pageText = browser.FindElement(By.TagName("body")).Text;

                    if ((refresh.Displayed && refresh.Enabled)
                        && (pageText.Contains("DOCUMENTS ON FILE")))
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
                throw new Exception("Docs Tab Is Not Displayed");
            }

        }

        public void AssertDocsTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            while (controlWaitTime > 0)
            {
                try
                {
                    //Check for Refresh button
                    IWebElement element1 = browser.FindElement(By.Id("tblDocumentsOnFile"));
                    IWebElement refresh = element1.FindElement(By.XPath("//input[@type='submit' and @value='Refresh']"));
                    
                    //get page text
                    var pageText = browser.FindElement(By.TagName("body")).Text;

                    if ( (refresh.Displayed && refresh.Enabled)
                        && (pageText.Contains("DOCUMENTS ON FILE")) )
      
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
                throw new Exception("Docs Tab Is Not Displayed");
            }

        }

    } //end public partial class Docs

} //end namespace AcceptanceTests.PageObjects
