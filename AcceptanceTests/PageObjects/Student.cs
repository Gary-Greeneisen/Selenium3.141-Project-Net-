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
    public partial class Student
    {


        /// <summary>
        /// Based on the program type create Autism, JPSN
        ///  EdChoice, Cleveland Student Application
        /// </summary>
        /// <param name="appData">The application data.</param>
        public void NewStudentApplication(ScholarshipApplicationData appData)
        {
            var program = TestRunnerInterface.Map.testContext.program;

            bool error = false;
            var programKey = string.Empty;

            switch (program.ToUpper())
            {
                case "AUTISM":
                case "JPSN":
                    this.NewAutismJPSNStudentApplication(appData);
                    break;

                case "EDCHOICE":
                case "CLEVELAND":
                    this.NewEdChoiceClevelandStudentApplication(appData);
                    break;

                default:
                    error = true;
                    break;

            }

            if (error)
            {
                throw new Exception("Program Type = " + program + "Not Implemented");
            }


        }

        /// <summary>
        /// Start New Autism, JPSN Student Application Driver
        /// Use ScholarshipApplicationData data
        /// </summary>
        public void NewAutismJPSNStudentApplication(ScholarshipApplicationData appData)
        {
            //Wait for New Student Application screen
            this.WaitForNewStudentApplication(RunTimeVars.REPEAT_TIMES);

            //***************************************
            //Define New Application Data
            //Student Information
            string middleName = appData.middleName;
            string maidenName = appData.maidenName;
            string gender = appData.gender;
            string ethnicity = appData.ethnicity;
            string language = appData.language;
            string SSN = appData.SSN;
            string birthCity = appData.birthCity;
            string birthState = appData.birthState;

            //Application Information 
            //string appPeroid = "Autism FY 2016";      
            string county = appData.county;
            string residence = appData.residence;           


            //string residenceBeginDate = "01/01/2015";
            string initialProvider = appData.initialProvider;       

            //Student has a current ETR
            bool studentETR = appData.studentETR;
            string studentETRCounty = appData.studentETRCounty;
            string studentETRSchoolDistrict = appData.studentETRSchoolDistrict;      

            //Where will the student be educated?
            //string studentEducated = "Home School";
            //string studentEducated = "Public School";
            //string studentEducated = "Chartered Non Pub";
            //string studentEducated = "Non-Chartered Nonpub";
            string studentEducated = appData.studentEducated;

            string publicSchoolCounty = appData.publicSchoolCounty;
            string publicSchoolDistrict = appData.publicSchoolDistrict;
            string ChartedNPCounty = appData.ChartedNPCounty;
            string ChartedNPSchoolName = appData.ChartedNPSchoolName;
            string NonChartedNPCounty = appData.ChartedNPCounty;
            string OtherSchoolName = appData.OtherSchoolName;


            string previousGradeLevel = appData.previousGradeLevel;
            string currentGradeLevel = appData.currentGradeLevel;
            //*******************************************


            //***********************
            //Student Information 
            //***********************
            //Middle Name
            this.SetTextBox("txtStdntMiddleName", middleName);

            //Mothers Maiden Name
            this.SetTextBox("txtStdntMothersLastName", maidenName);

            //Gender
            this.SetListBox("ddlGender", gender);

            //Ethinicity(race)
            this.SetListBox("ddlRace", ethnicity);

            //Native language
            this.SetListBox("ddlNativeLanguage", language);

            //Don't use full SSN now, in case SSID is intentional to be blank
            //SSN
            //this.SetTextBox("txtStdntSSN4", SSN);
            //var ss = appData.SSN;
            //var partialSSN = ss.Substring(5, 4);      //just need the last4-digits
            this.SetTextBox("txtStdntSSN4", SSN);

            //Birth Place city	
            this.SetTextBox("txtStdntBirthCity", birthCity);

            //Birth Place State 
            this.SetListBox("ddlState", birthState);

            //Don't update SSID in case SSID is intentional to be blank
            //SSID
            //var ssid = appData.SSID;
            //this.SetTextBox("txtStdntSSID", ssid);

            //**************************
            //Application Information 
            //**************************
            //Application Period
            //Accept default value

            //County
            this.SetListBox("ddCounty", county);

            //Legal District of Residence
            this.SetListBox("ddlegaldist", residence);

            /**********************************************
            //Residency Begin Date
            this.SetTextBox("residencyBeginDate", residenceBeginDate);
      
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            IWebElement element = browser.FindElement(By.Id("residencyBeginDate"));
            this.SetTextBox("residencyBeginDate", residenceBeginDate);
            element.SendKeys(Keys.Enter);
            ******************************************************/
            //Date - 10/24/2015 Workaround
            //the Date Picker control is Read Only
            //Use JavascriptExecutor to remove the Read Only Attribute
            //Then update the Date
            //
            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //((IJavaScriptExecutor)browser).ExecuteScript("document.getElementById('residencyBeginDate').removeAttribute('readonly',0);");
            //IWebElement element = browser.FindElement(By.Id("residencyBeginDate"));
            //element.Clear();
            //string DOB = Libary.CalculateDOBByYear(currentAge);
            //element.SendKeys(DOB + Keys.Enter);

            //Initial Provider
            this.SetListBox("ddlPrimaryProvider", initialProvider);

            //Student has a current ETR?
            //Set the radio button to defined state
            IWebElement element = null;

            if (studentETR)
            {
                element = this.StudentETR_RadioButton(true);
                element.Click();

                //Student ETR County
                this.SetListBox("ddEtrCounty", studentETRCounty);

                //Student ETR School District
                this.SetListBox("ddlEtrdist", studentETRSchoolDistrict);

            }
            else
            {
                element = this.StudentETR_RadioButton(false);
                element.Click();
            }

            //Where will the student be educated
            this.SetListBox("ddlSchoolLocType", studentEducated);

            //if (studentEducated.Equals("Home School"))
            //This is already set above, so do nothing

            if (studentEducated.Equals("Public School"))
            {
                this.SetListBox("ddPublicSchlSearchCounty", publicSchoolCounty);
                this.SetListBox("ddPublicSchlSearchlegaldist", publicSchoolDistrict);

            }
            if (studentEducated.Equals("Chartered Non Pub"))
            {
                this.SetListBox("ddCharterNonPubSchlSearchCounty", ChartedNPCounty);
                this.SetListBox("ddCharterNonPubSchlSearchlegaldist", ChartedNPSchoolName);

            }
            if (studentEducated.Equals("Non-Chartered Nonpub"))
            {
                this.SetTextBox("txtOtherSchlName", NonChartedNPCounty);

            }
            if (studentEducated.Equals("Other School"))
            {
                this.SetTextBox("txtOtherSchlName", OtherSchoolName);

            }


            //Previous School Year Grade Level
            this.SetListBox("ddlPrevGrade", previousGradeLevel);

            //Current School Year Grade Level
            this.SetListBox("ddlcurgrade", currentGradeLevel);


            //Locate the page buttons
            IWebElement newStudent = this.CreateNewStudentAppButton();
            newStudent.Click();


        }

        /// <summary>
        /// Start New EdChoice, ClevelandStudent Application Driver
        /// Use ScholarshipApplicationData data
        /// </summary>
        public void NewEdChoiceClevelandStudentApplication(ScholarshipApplicationData appData)
        {
            //Wait for New Student Application screen
            this.WaitForNewStudentApplication(RunTimeVars.REPEAT_TIMES);

            //***************************************
            //Define New Application Data
            //Student Information
            string middleName = appData.middleName;
            string maidenName = appData.maidenName;
            string gender = appData.gender;
            string ethnicity = appData.ethnicity;
            string language = appData.language;
            string SSN = appData.SSN;
            string birthCity = appData.birthCity;
            string birthState = appData.birthState;

            //Application Information 
            //string appPeroid = "Autism FY 2016";      
            string county = appData.county;
            string residence = appData.residence;


            //string residenceBeginDate = "01/01/2015";
            string initialProvider = appData.initialProvider;
            string assignedBulding = appData.assignedBulding;

            //Student has a current ETR
            bool studentETR = appData.studentETR;
            string studentETRCounty = appData.studentETRCounty;
            string studentETRSchoolDistrict = appData.studentETRSchoolDistrict;

            //Where will the student be educated?
            //string studentEducated = "Home School";
            //string studentEducated = "Public School";
            //string studentEducated = "Chartered Non Pub";
            //string studentEducated = "Non-Chartered Nonpub";
            string studentEducated = appData.studentEducated;

            string publicSchoolCounty = appData.publicSchoolCounty;
            string publicSchoolDistrict = appData.publicSchoolDistrict;
            string ChartedNPCounty = appData.ChartedNPCounty;
            string ChartedNPSchoolName = appData.ChartedNPSchoolName;
            string NonChartedNPCounty = appData.ChartedNPCounty;
            string OtherSchoolName = appData.OtherSchoolName;

            bool isKindergartener = appData.isKindergartener;
            string previousGradeLevel = appData.previousGradeLevel;
            string currentGradeLevel = appData.currentGradeLevel;

            string currentlyAttendingSchool = appData.currentlyAttendingSchool;


            //***********************
            //Student Information 
            //***********************
            //Middle Name
            this.SetTextBox("txtStdntMiddleName", middleName);

            //Mothers Maiden Name
            this.SetTextBox("txtStdntMothersLastName", maidenName);

            //Gender
            this.SetListBox("ddlGender", gender);

            //Ethinicity(race)
            this.SetListBox("ddlRace", ethnicity);

            //Native language
            this.SetListBox("ddlNativeLanguage", language);

            //Don't use full SSN now, in case SSID is intentional to be blank
            //SSN
            //this.SetTextBox("txtStdntSSN4", SSN);
            //var ss = appData.SSN;
            //var partialSSN = ss.Substring(5, 4);      //just need the last4-digits
            this.SetTextBox("txtStdntSSN4", SSN);


            //Birth Place city	
            this.SetTextBox("txtStdntBirthCity", birthCity);

            //Birth Place State 
            this.SetListBox("ddlState", birthState);

            //Don't update SSID in case SSID is intentional to be blank
            //SSID
            //var ssid = appData.SSID;
            //this.SetTextBox("txtStdntSSID", ssid);

            //**************************
            //Application Information 
            //**************************
            //Application Period
            //Accept default value

            //County
            this.SetListBox("ddCounty", county);

            //Legal District of Residence
            this.SetListBox("ddlegaldist", residence);

            //Assigned Building
            this.SetListBox("ddlDesBldng", assignedBulding);


            /**********************************************
            //Residency Begin Date
            this.SetTextBox("residencyBeginDate", residenceBeginDate);
      
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            IWebElement element = browser.FindElement(By.Id("residencyBeginDate"));
            this.SetTextBox("residencyBeginDate", residenceBeginDate);
            element.SendKeys(Keys.Enter);
            ******************************************************/
            //Date - 10/24/2015 Workaround
            //the Date Picker control is Read Only
            //Use JavascriptExecutor to remove the Read Only Attribute
            //Then update the Date
            //
            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //((IJavaScriptExecutor)browser).ExecuteScript("document.getElementById('residencyBeginDate').removeAttribute('readonly',0);");
            //IWebElement element = browser.FindElement(By.Id("residencyBeginDate"));
            //element.Clear();
            //string DOB = Libary.CalculateDOBByYear(currentAge);
            //element.SendKeys(DOB + Keys.Enter);

            //Initial Provider
            this.SetListBox("ddlPrimaryProvider", initialProvider);

            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
      
            if (isKindergartener)
            {
                var xpath = "//input[@type='radio'] [@value = 'Yes']";
                IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, xpath, RunTimeVars.REPEAT_TIMES);
                element.Click();

            }
            else
            {
                //Student is an incoming kindergartener? = No
                //Select Program Criteria first, because this updates modifies 
                //Previous School Year Grade Level

                //Select Program Criteria = Student is currently attending a designated public school in their resident district
                //var selection = "//input[@id='radProgCriteria]" + "[@value = '1302']";
                IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "//*[@id='radProgCriteria']", RunTimeVars.REPEAT_TIMES);
                element.Click();
                element.SendKeys(Keys.ArrowDown);

                //THis is set automatically
                //string xpath = "//*[@id='dialog-StudentApp']/fieldset/table/tbody/tr/td[1]/table/tbody/tr[7]/td[2]/input[2]";
                //var xpath = "//input[@type='radio'] [@value = 'No']";
                //element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, xpath, RunTimeVars.REPEAT_TIMES);
                //element.Click();

                //Student has a current ETR?
                //Set the radio button to defined state
                //IWebElement element = null;


                //Previous School Year Grade Level
                this.SetListBox("ddlPrevGrade", previousGradeLevel);

                //Current School Year Grade Level
                this.SetListBox("ddlcurgrade", currentGradeLevel);
            }

            //Currently Attending School automaticly pre-populated
            //this.SetListBox("txtCurrentAttendingSchool", currentlyAttendingSchool);

            //Locate the page buttons
            IWebElement newStudent = this.CreateNewStudentAppButton();
            newStudent.Click();


        }



        /// <summary>
        /// Start New Student Application Driver
        /// Use hard coded Data
        /// </summary>
        public void NewStudentApplication()
        {
            //Wait for New Student Application screen
            this.WaitForNewStudentApplication(RunTimeVars.REPEAT_TIMES);

            //***************************************
            //Define New Application Data
            //Student Information
            string middleName = "Middle Name";
            string maidenName = "Maiden Name";
            string gender = "Male";
            string ethnicity = "Hispanic";
            string language = "English";
            string SSN = "1234";
            string birthCity = "Columbus";
            string birthState = "Ohio";

            //Application Information 
            //string appPeroid = "Autism FY 2016";      //select option(0)
            string county = "Allen";
            string residence = "045765, Bath";          //Select Option# - "045765, Bath"    
            
            
            //string residenceBeginDate = "01/01/2015";
            string initialProvider = "096263, Alexandria Montessori";     //Select Option# - "096263, Alexandria Montessori";  

            //Student has a current ETR
            bool studentETR = true;
            string studentETRCounty = "Allen";
            string studentETRSchoolDIstricy = "045757, Allen East";       //Select "045757, Allen East"

            //Where will the student be educated?
            //string studentEducated = "Home School";
            //string studentEducated = "Public School";
            //string studentEducated = "Chartered Non Pub";
            //string studentEducated = "Non-Chartered Nonpub";
            string studentEducated = "Other School";

            string publicSchoolCounty = "Franklin";
            string publicSchoolDistrict = "047027, Dublin";
            string ChartedNPCounty = "Ashland";
            string ChartedNPSchoolName = "068338, Ashland Christian";
            string NonChartedNPCounty = "Non-Charted Non Public";
            string OtherSchoolName = "Other School Name";


            string previousGradeLevel = "6th Grade";
            string currentGradeLevel = "10th Grade";
            //*******************************************

  
            //***********************
            //Student Information 
            //***********************
            //Middle Name
            this.SetTextBox("txtStdntMiddleName", middleName);

            //Mothers Maiden Name
            this.SetTextBox("txtStdntMothersLastName", maidenName);

            //Gender
            this.SetListBox("ddlGender", gender);
                    
            //Ethinicity(race)
            this.SetListBox("ddlRace", ethnicity);

            //Native language
            this.SetListBox("ddlNativeLanguage", language);

            //SSN
            this.SetTextBox("txtStdntSSN4", SSN);

            //Birth Place city	
            this.SetTextBox("txtStdntBirthCity", birthCity);

            //Birth Place State 
            this.SetListBox("ddlState", birthState);

            //**************************
            //Application Information 
            //**************************
            //Application Period
            //Accept default value

            //County
            this.SetListBox("ddCounty", county);

            //Legal District of Residence
            this.SetListBox("ddlegaldist", residence);
  
            /**********************************************
            //Residency Begin Date
            this.SetTextBox("residencyBeginDate", residenceBeginDate);
      
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            IWebElement element = browser.FindElement(By.Id("residencyBeginDate"));
            this.SetTextBox("residencyBeginDate", residenceBeginDate);
            element.SendKeys(Keys.Enter);
            ******************************************************/
            //Date - 10/24/2015 Workaround
            //the Date Picker control is Read Only
            //Use JavascriptExecutor to remove the Read Only Attribute
            //Then update the Date
            //
            //IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            //((IJavaScriptExecutor)browser).ExecuteScript("document.getElementById('residencyBeginDate').removeAttribute('readonly',0);");
            //IWebElement element = browser.FindElement(By.Id("residencyBeginDate"));
            //element.Clear();
            //string DOB = Libary.CalculateDOBByYear(currentAge);
            //element.SendKeys(DOB + Keys.Enter);

            //Initial Provider
            this.SetListBox("ddlPrimaryProvider", initialProvider);

            //Student has a current ETR?
            //Set the radio button to defined state
            IWebElement element = null;

            if (studentETR)
            {
                element = this.StudentETR_RadioButton(true);
                element.Click();

                //Student ETR County
                this.SetListBox("ddEtrCounty", studentETRCounty);

                //Student ETR School District
                this.SetListBox("ddlEtrdist", studentETRSchoolDIstricy);

            }
            else
            {
                element = this.StudentETR_RadioButton(false);
                element.Click();
            }

            //Where will the student be educated
            this.SetListBox("ddlSchoolLocType", studentEducated);

            //if (studentEducated.Equals("Home School"))
            //This is already set above, so do nothing

            if (studentEducated.Equals("Public School"))
            {
                this.SetListBox("ddPublicSchlSearchCounty", publicSchoolCounty);
                this.SetListBox("ddPublicSchlSearchlegaldist", publicSchoolDistrict);

            }
            if (studentEducated.Equals("Chartered Non Pub"))
            {
                this.SetListBox("ddCharterNonPubSchlSearchCounty", ChartedNPCounty);
                this.SetListBox("ddCharterNonPubSchlSearchlegaldist", ChartedNPSchoolName);

            }
            if (studentEducated.Equals("Non-Chartered Nonpub"))
            {
                this.SetTextBox("txtOtherSchlName", NonChartedNPCounty);

            }
            if (studentEducated.Equals("Other School"))
            {
                this.SetTextBox("txtOtherSchlName", OtherSchoolName);

            }


            //Previous School Year Grade Level
            this.SetListBox("ddlPrevGrade", previousGradeLevel);

            //Current School Year Grade Level
            this.SetListBox("ddlcurgrade", currentGradeLevel);



            //Locate the page buttons
            IWebElement newStudent = this.CreateNewStudentAppButton();
            newStudent.Click();


        }

        /// <summary>
        /// Wait until the new student application screen
        /// Create New Student Application button and
        /// Cancel button are displayed
        /// </summary>
        /// <param name="retrys"></param>
        public void WaitForNewStudentApplication(int retrys)
        {

            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            var controlWaitTime = retrys;
 
            while (controlWaitTime > 0)
            {

                try
                {
                    //Wait for the text link to be displayed
                    IWebElement newStudentButton = this.CreateNewStudentAppButton();
                    IWebElement newStudentCancelButton = this.CancelNewStudentAppButton();

                    if ((newStudentButton != null)
                        && (newStudentCancelButton != null))
                    {
                        break;
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
                throw new Exception("New Student Application Page Not Displayed with retrys = " + retrys.ToString());
            }

        }

        /// <summary>
        /// Wait for the text link to be displayed
        /// </summary>
        /// <param name="retrys"></param>
        public void WaitForNewStudentSearch(int retrys)
        {

            Libary.WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {

                try
                {
                    //Wait for the text link to be displayed
                    browser.FindElement(By.LinkText("HERE"));
                    break;

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
                throw new Exception("Student Search Page Not Displayed with retrys = " + retrys.ToString());
            }

        }


        public IWebElement StudentETR_RadioButton(bool state)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //<input type="radio" name="radioBtn" value="Yes">
            //*[@id="dialog-StudentApp"]/fieldset/table/tbody/tr/td[1]/table/tbody/tr[6]/td[2]/input[1]
            //
            //<input type="radio" name="radioBtn" value="No">
            //*[@id="dialog-StudentApp"]/fieldset/table/tbody/tr/td[1]/table/tbody/tr[6]/td[2]/input[2]

            //IWebElement dialog = browser.FindElement(By.Id("dialog-StudentApp"));
            IWebElement dialog = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "dialog-StudentApp", RunTimeVars.REPEAT_TIMES);
            IWebElement radioButton;

            if (state)
            {
                //radioButton = dialog.FindElement(By.XPath("//input[@type='radio' and @value='Yes']"));
                radioButton = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "//input[@type='radio' and @value='Yes']", RunTimeVars.REPEAT_TIMES);
            }
            else
            {
                //radioButton = dialog.FindElement(By.XPath("//input[@type='radio' and @value='No']"));
                radioButton = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.XPATH, "//input[@type='radio' and @value='No']", RunTimeVars.REPEAT_TIMES);

            }

            return radioButton;

        }

        
        public IWebElement CreateNewStudentAppButton()
        {
            IWebElement newStudent = null;

            try
            {
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

                //id="dialog-NewStudent" = //html/body/div[13]
                IWebElement dialogNewStudent = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "dialog-NewStudent", RunTimeVars.REPEAT_TIMES);
                //Move up to (1)-parent dir
                IWebElement parent = dialogNewStudent.FindElement(By.XPath(".."));

                //this element is the same location as id="dialog-NewStudent"
                IWebElement element = browser.FindElement(By.XPath("//html/body/div[13]"));

                //<span class="ui-button-text">Create New Student Application</span>
                //html/body/div[13]/div[11]/div/button[1]/span

                newStudent = parent.FindElement(By.XPath("div[11]/div/button[1]/span"));
            }
            catch
            {
                //Do nothing, just catch the exception
            }

            return newStudent;
        }

        public IWebElement CancelNewStudentAppButton()
        {
            IWebElement cancel = null;

            try
            {
                IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

                //id="dialog-NewStudent" = //html/body/div[13]
                IWebElement dialogNewStudent = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "dialog-NewStudent", RunTimeVars.REPEAT_TIMES);
                //Move up to (1)-parent dir
                IWebElement parent = dialogNewStudent.FindElement(By.XPath(".."));

                //this element is the same location as id="dialog-NewStudent"
                IWebElement element = browser.FindElement(By.XPath("//html/body/div[13]"));

                //<span class="ui-button-text">Cancel</span>
                //html/body/div[13]/div[11]/div/button[2]/span

                cancel = parent.FindElement(By.XPath("div[11]/div/button[2]/span"));
            }
            catch
            {
                //Do nothing, just catch the exception
            }

            return cancel;


        }

        public void SetTextBox(string id, string value)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            IWebElement element = browser.FindElement(By.Id(id));
            element.SendKeys(value);

        }
        
        public void SetListBox(string id, string value)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            SelectElement select = new SelectElement(browser.FindElement(By.Id(id))); //Locating select list
            select.SelectByText(value);

        }

        public void SetListBox(string id, string format, int option)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //string format = "000000";   //format = 6-digits

            SelectElement select = new SelectElement(browser.FindElement(By.Id(id))); //Locating select list
            string test = option.ToString(format);          
            select.SelectByValue(option.ToString(format));

        }

        public void SetListBox(string id, int index)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            SelectElement select = new SelectElement(browser.FindElement(By.Id(id))); //Locating select list
            select.SelectByIndex(index);

        }


    } //end public partial class Student




} //end namespace AcceptanceTests.PageObjects
