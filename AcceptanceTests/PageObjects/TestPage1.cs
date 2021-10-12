using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using AcceptanceTests.Common.Application;
using AcceptanceTests.Common.Library;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System.Xml;
using AcceptanceTests.Config;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.PageObjects
{
    public partial class TestPage1
    {
        public void TestMethod1()
        {


            //Provider Search and select record(1)
            TestRunnerInterface.Map.providerSearchPage.SetApplicationStatus("Started");
            TestRunnerInterface.Map.providerSearchPage.SetApplicationPeroid("All");
            TestRunnerInterface.Map.providerSearchPage.Search();
            TestRunnerInterface.Map.providerSearchPage.SelectRecord(1);
            TestRunnerInterface.Map.providerSearchPage.ServicesTab();

            this.AddService("Aide Services");
            //this.AddService("Adapted Physical Education Services");

        }

        public void TestMethod2()
        {


            TestRunnerInterface.Map.menu.AdminDesignatedSchool();



        }

        public void TestMethod3()
        {
      


         
        }


        public void AddService(string service)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Select the service
            //SelectElement select = new SelectElement(browser.FindElement(By.Id("slServiceTypes"))); //Locating select list

            IWebElement serviceTypes = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "slServiceTypes", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(serviceTypes);

            Libary.HighLight(browser, serviceTypes);

            select.SelectByText(service.Trim()); //Select item from list having option text as "Item1"

            //click the transfer button
            browser.FindElement(By.Id("addButton")).Click();

        }



    } //end public partial class TestPage1










} //end namespace AcceptanceTests.PageObjects

