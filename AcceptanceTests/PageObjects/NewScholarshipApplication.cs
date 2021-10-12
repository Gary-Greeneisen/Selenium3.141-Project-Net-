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
using AcceptanceTests.Common.Utilities;
using System.Xml;
using AcceptanceTests.Config;

namespace AcceptanceTests.PageObjects
{
    public partial class NewScholarshipApplication
    {

        /// <summary>
        /// Set Application = Review Completed
        /// Need to update the following
        /// 1. Student SSID
        /// 2. Active IEP
        /// </summary>
        public void SetReviewCompleted()
        {
            this.SetSSID();

            TestRunnerInterface.Map.studentSearchPage.IEPTab();
            TestRunnerInterface.Map.iepTab.AddNewIEP();

            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

        }

        public void SetSSID()
        {
            //Display Student Tab
            TestRunnerInterface.Map.studentSearchPage.StudentTab();
            TestRunnerInterface.Map.studentTab.WaitForStudentTabDisplay(RunTimeVars.REPEAT_TIMES);

            //Enter Student SSID
            var program = TestRunnerInterface.Map.testContext.program;

            TestRunnerInterface.Map.studentTab.UpdateSSID(program);
            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

        }



        /// <summary>
        /// Finish New Application Driver
        /// Use hard coded Autism Data
        /// </summary>
        public void FinishApplication(ScholarshipApplicationData appData)
        {

            //**********************************
            //Define New Application Data

            //**********************************

            //Add Primary Guardian  
            TestRunnerInterface.Map.providerSearchPage.ParentGuardianTab();

            var guardian = appData.newGuardian;
            //TestRunnerInterface.Map.parentGuardianTab.AddNewGuardian("Matthew,Woods,05/23/1973,Father");
            TestRunnerInterface.Map.parentGuardianTab.AddNewGuardian(guardian);

            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);

            //Add Application Data

            //Add IEP Information 

            //Add Uploaded Docs
            TestRunnerInterface.Map.providerSearchPage.DocsTab();
            this.TestAddDocs();
            //this.AddDocs();

            Libary.RefreshApplication(RunTimeVars.Refresh.PageRefresh);


        }

        /// <summary>
        /// Start New Application Driver
        /// Use hard coded Autism Data
        /// Call the StartApplication() using the ScholarshipApplicationData test data
        /// </summary>
        public void StartApplication()
        {
            var program = TestRunnerInterface.Map.testContext.program;

            this.LoadHardCodedApplicationData(program);
            this.StartApplication(TestRunnerInterface.Map.scholarshipApplicationData);
        }


        /// <summary>
        /// Start New Application Driver
        /// Use ScholarshipApplicationData data
        /// </summary>
        public void StartApplication(ScholarshipApplicationData appData)
        {

            //**********************************
            //Define New Application Data
            string firstName = appData.firstName;
            string lastName = appData.lastName;
            int currentAge = appData.currentAge;
            //**********************************

    
            //Update the student new SS# and SSID#
            //Update New Student Name
            //Get the Last New Student# from filename - RunTimeData.xml
            //Increment to Next Student# 
            //Save the Next Student# back to the xml file
            //Append the Next Student# to the Student Name
            //

            //Get the last SS# and SSID# from filename - RunTimeData.xml    
            //Get the Last New Student# from filename - RunTimeData.xml        
            //Get program type from Test Context
            //Update the Global ScholarshipApplicationData appData)
            string program = TestRunnerInterface.Map.testContext.program;


            /**********************************************************
            // Don't insert SSN# and SSID# here yet
            // Wait until the call to finish the application
            // in case the SSN# and SSID# are intended to be blank

            var ssn = this.CalculateNextSSNNumber(program);
            appData.SSN = ssn;

            Create an SSID# by replacing first 2-chars of SS#
            appData.SSID = this.CalculateSSID(ssn);
            *********************************************************/

            int nextStudentNumber = this.CalculateNextStudentNumber(program);

            //Append the Next Student# to the Student Name
            firstName += "-" + nextStudentNumber.ToString();
            lastName += "-" + nextStudentNumber.ToString();

            //Click menu 
            TestRunnerInterface.Map.menu.NewScholarshipApplication();

            //Set Application Peroid = 2nd Option
            //FY 2017
            //FY 2016
            TestRunnerInterface.Map.studentSearchPage.SetListBox("ddlApplicationPeriod", 1);

            //Search for Student and create new application
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Auto calculate DOB based on Age
            //Enter DOB
            //DOB must be => 3-years old and <= 22-years old
            //string DOB = Libary.CalculateDOBByYear(currentAge);

            //Hard Code the DOB
            //string DOB = "01/01/2000";

            //Use DOB from the Application Data
            string DOB = appData.DOB;

            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtDateofBirth", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(DOB + Keys.Return);

            //Enter Firstname
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtFirstName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(firstName);

            //Enter Lastname
            element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "txtLastName", RunTimeVars.REPEAT_TIMES);
            element.SendKeys(lastName);

            //Locate Search button
            //<input type="submit" value="Search" name="Search">
            //*[@id="myTable1"]/tbody/tr/td/table/tbody/tr[7]/td/input[1]
            //
            //<input type="reset" value="Reset" onclick="ClearSearch()">
            //*[@id="myTable1"]/tbody/tr/td/table/tbody/tr[7]/td/input[2]

            IWebElement myTable1 = browser.FindElement(By.Id("myTable1"));
            //IWebElement search = myTable1.FindElement(By.XPath("//tbody/tr/td/table/tbody/tr[7]/td/input[1]"));
            IWebElement search = myTable1.FindElement(By.XPath("//input[@type='submit' and @value='Search']"));
            //IWebElement reset = myTable1.FindElement(By.XPath("//tbody/tr/td/table/tbody/tr[7]/td/input[2]"));
            IWebElement reset = myTable1.FindElement(By.XPath("//input[@type='reset' and @value='Reset']"));

            //*************************************************************
            // Isuse - Unless the New Student Application is Maximized
            // the left most controls are hidden and can't be accessed
            //
            //Maximize the browser to set New Student Application
            //to the middle he screen
            // Then restore the browser back to orginal size
            //*************************************************************

            //Maxamize the browser
            System.Drawing.Size browserSize = Libary.BrowserMaximize(browser);

            search.Click();

            //Wait for Search Results
            TestRunnerInterface.Map.student.WaitForNewStudentSearch(RunTimeVars.REPEAT_TIMES);

            //Click Here to create new application
            IWebElement dialog = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "dialog-SearchResults", RunTimeVars.REPEAT_TIMES);
            IWebElement here = dialog.FindElement(By.LinkText("HERE"));

            here.Click();

            //Create new Student Application
            TestRunnerInterface.Map.student.NewStudentApplication(appData);

            //Wait for Student Tab to be displayed
            TestRunnerInterface.Map.studentTab.WaitForStudentTabDisplay(RunTimeVars.REPEAT_TIMES);

            //Reset browser back to orginal size
            Libary.SetBrowserSize(browser, browserSize);

        }

        /// <summary>
        /// Get the Last New Student# based on the program type
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public int CalculateNextStudentNumber(string program)
        {
            bool error = false;
            var programKey = string.Empty;

            switch (program.ToUpper())
            {
                case "AUTISM":
                    programKey = "Autism Scholarship Last New Student#";
                break;

                case "JPSN":
                    programKey = "JPSN Scholarship Last New Student#";
                break;

                case "EDCHOICE":
                    programKey = "EdChoice Scholarship Last New Student#";
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

            return Int32.Parse(lastNewStudent); 

        }

        /// <summary>
        /// Get the Last New Student SSN# based on the program type
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public string CalculateNextSSNNumber(string program)
        {
            bool error = false;
            var programKey = string.Empty;

            switch (program.ToUpper())
            {
                case "AUTISM":
                    programKey = "Autism Last SS#";
                    break;

                case "JPSN":
                    programKey = "JPSN Last SS#";
                    break;

                case "EDCHOICE":
                    programKey = "EdChoice Last SS#";
                    break;

                default:
                    error = true;
                    break;

            }

            if (error)
            {
                throw new Exception("Program Type = " + program + "Not Implemented");
            }

            //Get the Last New Student SSN# from filename - RunTimeData.xml
            var lastStudentSSN = RunTimeData.GetKeyConfigSectionData(programKey);
            var nextStudentSSN = Int32.Parse(lastStudentSSN);
            nextStudentSSN++;

            string ssnNumber = nextStudentSSN.ToString();
            //Save the Next Student SS# back to the xml file
            RunTimeData.UpdateKeyConfigSectionData(programKey, ssnNumber);

            return lastStudentSSN;

        }

        public string CalculateSSID(string ssn)
        {

            //Create an SSID# by replacing first 2-chars of SS#
            //based on environment
            //First get the current environment from the appSettings section
            var environment = AppConfig.GetAppSettingsValue("Environment");
            var partialSSN = ssn.Substring(2, 7);    //last 7-digits
            string ssid;

            if (environment.Equals("Local",StringComparison.OrdinalIgnoreCase))
            {
                ssid = "LO" + partialSSN;

            }
            else if (environment.Equals("Dev", StringComparison.OrdinalIgnoreCase))
            {
                ssid = "DV" + partialSSN;
            }
            else if (environment.Equals("QA", StringComparison.OrdinalIgnoreCase))
            {
                ssid = "PD" + partialSSN;
            }
            else
            {
                //Do nothing
                ssid = ssn;
            }

            return (ssid);

        }



        /// <summary>
        /// Test method to upload files
        /// </summary>
        public void TestAddDocs()
        {
            //Reference the upload file in the project
            //var pathFileName = @"C:\Save\Upload File1.txt";
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            var pathFileName = fileDir + "Upload File1.txt";

            var program = TestRunnerInterface.Map.testContext.program;

            bool error = false;

            switch (program.ToUpper())
            {
                case "AUTISM":
                case "JPSN":
                    TestRunnerInterface.Map.docsTab.FileUpload("Scanned Application Form", pathFileName, "Scanned Application Form");
                    TestRunnerInterface.Map.docsTab.FileUpload("Service or Goals Modification Form", pathFileName, "Service or Goals Modification Form");
                    TestRunnerInterface.Map.docsTab.FileUpload("Acceptance Form", pathFileName, "Acceptance Form");
                    TestRunnerInterface.Map.docsTab.FileUpload("IEP (Electronic copy)", pathFileName, "IEP (Electronic copy)");
                    TestRunnerInterface.Map.docsTab.FileUpload("Proof of Custody", pathFileName, "Proof of Custody");
                    TestRunnerInterface.Map.docsTab.FileUpload("ETR", pathFileName, "ETR  (Electronic copy)", true);
                    TestRunnerInterface.Map.docsTab.FileUpload("Birth Certificate", pathFileName, "Birth Certificate");
                    TestRunnerInterface.Map.docsTab.FileUpload("Other Electronic Document", pathFileName, "Other Electronic Document");
                    TestRunnerInterface.Map.docsTab.FileUpload("Reconsideration Request Form", pathFileName, "Reconsideration Request Form");

                    break;

                case "EDCHOICE":
                    TestRunnerInterface.Map.docsTab.FileUpload("Scanned Application Form", pathFileName, "Scanned Application Form");
                    TestRunnerInterface.Map.docsTab.FileUpload("Proof of Address", pathFileName, "Proof of Address");
                    TestRunnerInterface.Map.docsTab.FileUpload("Birth Certificate", pathFileName, "Birth Certificate");

                    break;

                default:
                    error = true;
                    break;  

            }

            if (error)
            {
                throw new Exception("The Program Type = " + program + "Is Not Valid Name");
            }

            TestRunnerInterface.Map.docsTab.ClickSaveAndRefresh();
            TestRunnerInterface.Map.docsTab.WaitForDocsTabDisplay(RunTimeVars.REPEAT_TIMES);


        }

        /// <summary>
        /// Add Docs Driver
        /// </summary>
        public void AddDocs()
        {

            var program = TestRunnerInterface.Map.testContext.program;

            bool error = false;

            switch (program.ToUpper())
            {
                case "AUTISM":
                case "JPSN":
                    TestRunnerInterface.Map.docsTab.ScannedApplicationForm();
                    TestRunnerInterface.Map.docsTab.ServiceorGoalsModificationForm();
                    TestRunnerInterface.Map.docsTab.AcceptanceForm();
                    TestRunnerInterface.Map.docsTab.IEPElectronicCopy();
                    TestRunnerInterface.Map.docsTab.ProofofCustody();
                    TestRunnerInterface.Map.docsTab.ETRElectronicCopy();
                    TestRunnerInterface.Map.docsTab.BirthCertificate();
                    TestRunnerInterface.Map.docsTab.OtherElectronicDocument();
                    TestRunnerInterface.Map.docsTab.ReconsiderationRequestForm();
                    break;

                case "EDCHOICE":
                    TestRunnerInterface.Map.docsTab.ScannedApplicationForm();
                    TestRunnerInterface.Map.docsTab.AddProofofAddress();
                    TestRunnerInterface.Map.docsTab.BirthCertificate();
                    break;


                default:
                    error = true;
                    break;

            }


            if (error)
            {
                throw new Exception("The Program Type = " + program + "Is Not Valid Name");
            }


            TestRunnerInterface.Map.docsTab.ClickSaveAndRefresh();
            TestRunnerInterface.Map.docsTab.WaitForDocsTabDisplay(RunTimeVars.REPEAT_TIMES);


        }

        public void LoadHardCodedApplicationData(string program)
        {
            TestRunnerInterface.Map.scholarshipApplicationData.hardCodedData = true;

            bool error = false;

            switch (program.ToUpper())
            {
                case "AUTISM":

                    TestRunnerInterface.Map.scholarshipApplicationData.firstName = "Selenium Test";
                    TestRunnerInterface.Map.scholarshipApplicationData.lastName = "Selenium Test";
                    TestRunnerInterface.Map.scholarshipApplicationData.currentAge = 20;
                    TestRunnerInterface.Map.scholarshipApplicationData.DOB = "01/01/2000";

                    //NewStudentApplication Data
                    TestRunnerInterface.Map.scholarshipApplicationData.middleName = "Middle Name";
                    TestRunnerInterface.Map.scholarshipApplicationData.maidenName = "ODE Maiden Name";
                    TestRunnerInterface.Map.scholarshipApplicationData.gender = "Male";
                    TestRunnerInterface.Map.scholarshipApplicationData.ethnicity = "Hispanic";
                    TestRunnerInterface.Map.scholarshipApplicationData.language = "English";
                    TestRunnerInterface.Map.scholarshipApplicationData.SSN = "1234";
                    TestRunnerInterface.Map.scholarshipApplicationData.birthCity = "Columbus";
                    TestRunnerInterface.Map.scholarshipApplicationData.birthState = "Ohio";
                    TestRunnerInterface.Map.scholarshipApplicationData.county = "Allen";
                    TestRunnerInterface.Map.scholarshipApplicationData.residence = "045765, Bath";
                    //TestRunnerInterface.Map.scholarshipApplicationData.initialProvider = "096263, Alexandria Montessori";
                    TestRunnerInterface.Map.scholarshipApplicationData.initialProvider = "009897, AAA Sporting Goods";
                    TestRunnerInterface.Map.scholarshipApplicationData.studentETR = true;
                    TestRunnerInterface.Map.scholarshipApplicationData.studentETRCounty = "Allen";
                    TestRunnerInterface.Map.scholarshipApplicationData.studentETRSchoolDistrict = "045757, Allen East";
                    TestRunnerInterface.Map.scholarshipApplicationData.studentEducated = "Other School";
                    TestRunnerInterface.Map.scholarshipApplicationData.publicSchoolCounty = "Franklin";
                    TestRunnerInterface.Map.scholarshipApplicationData.publicSchoolDistrict = "047027, Dublin";
                    TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPCounty = "Ashland";
                    TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPSchoolName = "068338, Ashland Christian";
                    TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPCounty = "Non-Charted Non Public";
                    TestRunnerInterface.Map.scholarshipApplicationData.OtherSchoolName = "Other School Name";
                    TestRunnerInterface.Map.scholarshipApplicationData.previousGradeLevel = "6th Grade";
                    TestRunnerInterface.Map.scholarshipApplicationData.currentGradeLevel = "10th Grade";
                    //FinishApplication
                    TestRunnerInterface.Map.scholarshipApplicationData.newGuardian = "Matthew,Woods,05/23/1973,Father";

                    break;

                case "JPSN":
                    TestRunnerInterface.Map.scholarshipApplicationData.firstName = "Selenium Test";
                    TestRunnerInterface.Map.scholarshipApplicationData.lastName = "Selenium Test";
                    TestRunnerInterface.Map.scholarshipApplicationData.currentAge = 20;
                    TestRunnerInterface.Map.scholarshipApplicationData.DOB = "01/01/2000";
                 
                    //NewStudentApplication Data
                    TestRunnerInterface.Map.scholarshipApplicationData.middleName = "Middle Name";
                    TestRunnerInterface.Map.scholarshipApplicationData.maidenName = "ODE Maiden Name";
                    TestRunnerInterface.Map.scholarshipApplicationData.gender = "Male";
                    TestRunnerInterface.Map.scholarshipApplicationData.ethnicity = "Hispanic";
                    TestRunnerInterface.Map.scholarshipApplicationData.language = "English";
                    TestRunnerInterface.Map.scholarshipApplicationData.SSN = "1234";
                    TestRunnerInterface.Map.scholarshipApplicationData.birthCity = "Columbus";
                    TestRunnerInterface.Map.scholarshipApplicationData.birthState = "Ohio";
                    TestRunnerInterface.Map.scholarshipApplicationData.county = "Allen";
                    TestRunnerInterface.Map.scholarshipApplicationData.residence = "045765, Bath";
                    TestRunnerInterface.Map.scholarshipApplicationData.initialProvider = "056051, St Ignatius";
                    TestRunnerInterface.Map.scholarshipApplicationData.studentETR = true;
                    TestRunnerInterface.Map.scholarshipApplicationData.studentETRCounty = "Allen";
                    TestRunnerInterface.Map.scholarshipApplicationData.studentETRSchoolDistrict = "045757, Allen East";
                    TestRunnerInterface.Map.scholarshipApplicationData.studentEducated = "Other School";
                    TestRunnerInterface.Map.scholarshipApplicationData.publicSchoolCounty = "Franklin";
                    TestRunnerInterface.Map.scholarshipApplicationData.publicSchoolDistrict = "047027, Dublin";
                    TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPCounty = "Ashland";
                    TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPSchoolName = "068338, Ashland Christian";
                    TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPCounty = "Non-Charted Non Public";
                    TestRunnerInterface.Map.scholarshipApplicationData.OtherSchoolName = "Other School Name";
                    TestRunnerInterface.Map.scholarshipApplicationData.previousGradeLevel = "6th Grade";
                    TestRunnerInterface.Map.scholarshipApplicationData.currentGradeLevel = "10th Grade";
                    //FinishApplication
                    TestRunnerInterface.Map.scholarshipApplicationData.newGuardian = "Matthew,Woods,05/23/1973,Father";

                    break;


                case "EDCHOICE":
                    TestRunnerInterface.Map.scholarshipApplicationData.firstName = "Student";
                    TestRunnerInterface.Map.scholarshipApplicationData.lastName = "Student";
                    TestRunnerInterface.Map.scholarshipApplicationData.currentAge = 16;
                    TestRunnerInterface.Map.scholarshipApplicationData.DOB = "01/01/2000";

                    //NewStudentApplication Data
                    TestRunnerInterface.Map.scholarshipApplicationData.middleName = "Middle Name";
                    TestRunnerInterface.Map.scholarshipApplicationData.maidenName = "ODE";
                    TestRunnerInterface.Map.scholarshipApplicationData.gender = "Male";
                    TestRunnerInterface.Map.scholarshipApplicationData.ethnicity = "Hispanic";
                    TestRunnerInterface.Map.scholarshipApplicationData.language = "English";
                    TestRunnerInterface.Map.scholarshipApplicationData.SSN = "1234";
                    TestRunnerInterface.Map.scholarshipApplicationData.birthCity = "Columbus";
                    TestRunnerInterface.Map.scholarshipApplicationData.birthState = "Ohio";
                    TestRunnerInterface.Map.scholarshipApplicationData.county = "Allen";
                    //TestRunnerInterface.Map.scholarshipApplicationData.residence = "044222, Lima";
                    TestRunnerInterface.Map.scholarshipApplicationData.residence = "044222, Lima City School District";
                    TestRunnerInterface.Map.scholarshipApplicationData.assignedBulding = "005660, Lima North Middle School";
                    //TestRunnerInterface.Map.scholarshipApplicationData.initialProvider = "123125, Academy For Young Children Tlc";
                    TestRunnerInterface.Map.scholarshipApplicationData.initialProvider = "068403, Youngstown Christian";

                    TestRunnerInterface.Map.scholarshipApplicationData.isKindergartener = false;
                    TestRunnerInterface.Map.scholarshipApplicationData.previousGradeLevel = "2nd Grade";
                    TestRunnerInterface.Map.scholarshipApplicationData.currentGradeLevel = "3rd Grade";

                    TestRunnerInterface.Map.scholarshipApplicationData.currentlyAttendingSchool = "020677";


                    //FinishApplication
                    TestRunnerInterface.Map.scholarshipApplicationData.newGuardian = "Matthew,Woods,05/23/1973,Father";

                    break;




                default:
                    error = true;
                    break;


            }


            if (error)
            {
                throw new Exception("The Program Type = " + program + "Is Not Valid Name");
            }

        }
        public void LoadXMLApplicationData(string filename)
        {

            XmlDataFiles xmlFile = new XmlDataFiles();
            XmlNode root = xmlFile.rootNode(filename, "/Student");

            //Load Application Data
            TestRunnerInterface.Map.scholarshipApplicationData.hardCodedData = false;
       
            //Read the file data into program variables
            TestRunnerInterface.Map.scholarshipApplicationData.firstName = root.SelectSingleNode("firstname").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.lastName = root.SelectSingleNode("lastname").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.currentAge = Int32.Parse(root.SelectSingleNode("age").InnerText.Trim());
            TestRunnerInterface.Map.scholarshipApplicationData.DOB = root.SelectSingleNode("DOB").InnerText.Trim();

            TestRunnerInterface.Map.scholarshipApplicationData.middleName = root.SelectSingleNode("middleName").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.maidenName = root.SelectSingleNode("maidenName").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.gender     = root.SelectSingleNode("gender").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.ethnicity  = root.SelectSingleNode("ethnicity").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.language   = root.SelectSingleNode("language").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.SSN        = root.SelectSingleNode("SSN").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.birthCity = root.SelectSingleNode("birthCity").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.birthState = root.SelectSingleNode("birthState").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.county = root.SelectSingleNode("county").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.residence = root.SelectSingleNode("residence").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.initialProvider = root.SelectSingleNode("initialProvider").InnerText.Trim();

            var etr = root.SelectSingleNode("studentETR").InnerText.Trim();
            if(etr.Equals("true")) TestRunnerInterface.Map.scholarshipApplicationData.studentETR = true;
            if (etr.Equals("false")) TestRunnerInterface.Map.scholarshipApplicationData.studentETR = false;

            TestRunnerInterface.Map.scholarshipApplicationData.studentETRCounty = root.SelectSingleNode("studentETRCounty").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.studentETRSchoolDistrict = root.SelectSingleNode("studentETRSchoolDistrict").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.studentEducated = root.SelectSingleNode("studentEducated").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.publicSchoolCounty = root.SelectSingleNode("publicSchoolCounty").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.publicSchoolDistrict = root.SelectSingleNode("publicSchoolDistrict").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPCounty = root.SelectSingleNode("ChartedNPCounty").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.ChartedNPSchoolName = root.SelectSingleNode("ChartedNPSchoolName").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.NonChartedNPCounty = root.SelectSingleNode("NonChartedNPCounty").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.OtherSchoolName = root.SelectSingleNode("OtherSchoolName").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.previousGradeLevel = root.SelectSingleNode("previousGradeLevel").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.currentGradeLevel = root.SelectSingleNode("currentGradeLevel").InnerText.Trim();
            TestRunnerInterface.Map.scholarshipApplicationData.newGuardian = root.SelectSingleNode("newGuardian").InnerText.Trim();

        }






    } //end  public partial class NewScholarshipApplication

    /// <summary>
    /// class to hold New Scholarship  Application daata
    /// </summary>
    public class ScholarshipApplicationData
    {
        public bool hardCodedData = true;

        public string firstName;
        public string lastName;
        public int currentAge;
        public string DOB;

        //SS# and SSID#
        public string SSN;
        public string SSID;

        //NewStudentApplication Data
        public string middleName;
        public string maidenName;
        public string gender;
        public string ethnicity;
        public string language;
        public string birthCity;
        public string birthState;
        public string county;
        public string residence;
        public string initialProvider;
        public string assignedBulding;
        public bool studentETR;
        public string studentETRCounty;
        public string studentETRSchoolDistrict;
        public string studentEducated;
        public string publicSchoolCounty;
        public string publicSchoolDistrict;
        public string ChartedNPCounty;
        public string ChartedNPSchoolName;
        public string NonChartedNPCounty;
        public string OtherSchoolName;
        public string previousGradeLevel;
        public string currentGradeLevel;
        public bool isKindergartener;
        public string currentlyAttendingSchool;


        //FinishApplication
        public string newGuardian;



    }

} //end namespace AcceptanceTests.PageObjects
