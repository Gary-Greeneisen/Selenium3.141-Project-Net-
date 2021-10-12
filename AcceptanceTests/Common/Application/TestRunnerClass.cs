using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Config;
// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
//
using AcceptanceTests.PageObjects;

namespace AcceptanceTests.Common.Application
{
    public class TestRunnerClass
    {
        //Step-1
        //Define a unique UIMap/Page Object var = xxx that references each unique UI Map class
        //
        //Step-2 Initialize any vars
        //
        //Step-3
        //Create a reference to the UIMap(s)/Page Object(s)
        //
        //Step-4 - Use the UI Map/Page Object reference(s) to call the methods
        //launch the browser and login

        //Step-1
        //Define a unique UIMap/Page Object var = xxx that references each unique UI Map class

        //************************
        // Test Context Section
        //************************   
        public ProgramTestContext testContext = null;
        public ProviderApplicationData providerApplicationData = null;
        public ScholarshipApplicationData scholarshipApplicationData = null;


        //************************
        // Page Objects Section
        //************************   
        public AdminPrograms adminPrograms = null;
        public AdvancedStudentSearchPage advancedStudentSearchPage = null;
        public ApplicationTab applicationTab = null;
        public CommentsHistoryTab commentsHistory = null;
        public CreditHoursTab creditHoursTab = null;
        public DocsTab docsTab = null;
        public GeneralTab general = null;
        public HeaderPage headerPage = null;
        public IEPTab iepTab = null;
        public LoginPage loginPage = null;
        public Menu menu = null;
        public NewProviderApplication newProviderApplication = null;
        public NewScholarshipApplication newScholarshipApplication = null;
        public ParentGuardianTab parentGuardianTab = null;
        public ParentStudentTab parentStudentTab = null;
        public PersonnelTab personnel = null;
        public ProgramSelectionPage programSelectionPage = null;
        public ProviderSearchPage providerSearchPage = null;
        public RenewProviderApplication renewProviderApplication = null;
        public SafePage safePage = null;
        public ServicesTab servicesTab = null;
        public StaffTab staffTab = null;
        public StatusFlagsTab statusFlagsTab = null;
        public Student student = null;
        public StudentFinanceSearchPage studentFinanceSearchPage = null;
        public StudentSearchPage studentSearchPage = null;
        public StudentTab studentTab = null;
        public TestPage1 testPage1 = null;
        public TestPage2 testPage2 = null;
        public VerifyPageTabs verifyPageTabs = null;



        public TestRunnerClass()
        {
            //Step-2 Initialize the Run-Time vars from the Config File
            RunTimeVars.ReadAppConfig();


            //Step-3 Create a reference to the UIMap(s)/Page Object(s)
   
            //**************************
            // Test Context Section
            //************************   
            testContext = new ProgramTestContext();
            providerApplicationData = new ProviderApplicationData();
            scholarshipApplicationData = new ScholarshipApplicationData();

            //************************
            // Page Objects Section
            //************************
            adminPrograms = new AdminPrograms();
            advancedStudentSearchPage = new AdvancedStudentSearchPage();
            applicationTab = new ApplicationTab();
            commentsHistory = new CommentsHistoryTab();
            creditHoursTab = new CreditHoursTab();
            docsTab = new DocsTab();
            general = new GeneralTab();
            headerPage = new HeaderPage();
            iepTab = new IEPTab();
            loginPage = new LoginPage();
            menu = new Menu();
            newProviderApplication = new NewProviderApplication();
            newScholarshipApplication = new NewScholarshipApplication();
            parentGuardianTab = new ParentGuardianTab();
            parentStudentTab = new ParentStudentTab();
            personnel = new PersonnelTab();
            programSelectionPage = new ProgramSelectionPage();
            providerSearchPage = new ProviderSearchPage();
            renewProviderApplication = new RenewProviderApplication();
            safePage = new SafePage();
            servicesTab = new ServicesTab();
            staffTab = new StaffTab();
            statusFlagsTab = new StatusFlagsTab();
            student = new Student();
            studentFinanceSearchPage = new StudentFinanceSearchPage();
            studentSearchPage = new StudentSearchPage();
            studentTab = new StudentTab();
            testPage1 = new TestPage1();
            testPage2 = new TestPage2();
            verifyPageTabs = new VerifyPageTabs();



        } //end Constructor

        //************************************************************************
        // Define Test Methods
        //************************************************************************

        //Step-4 - Use the UI Map/Page Object reference(s) to call the methods
        //populate any class member vars
        //launch the browser and login


    } //end public class TestRunnerClass

} //end namespace AcceptanceTests.Common.Application
