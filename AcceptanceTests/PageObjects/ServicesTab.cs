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

namespace AcceptanceTests.PageObjects
{
    public partial class ServicesTab
    {

        /// <summary>
        /// Add Services Driver
        /// </summary>
        public void AddService()
        {

            //<select name="slServiceTypes" id="slServiceTypes" size="15" style="width: 100%;" onclick="toggle('slServiceTypes', $('#slServiceTypes :selected').val());">
            //          <option value="41">Adapted Physical Education Services</option>
            //          <option value="42">Aide Services</option>
            //          <option value="43">Attendant Services</option>
            //          <option value="44">Audiological Services</option>
            //          <option value="45">Behavioral Services</option>
            //          <option value="46">Counseling Services</option>
            //          <option value="47">Education Services</option>
            //          <option value="48">Interpreter Services</option>
            //          <option value="49">Intervention Services</option>
            //          <option value="50">Medical Services</option>
            //          <option value="51">Music Therapy Services</option>
            //          <option value="52">Occupational Therapy Services</option>
            //          <option value="53">Orientation and Mobility Services</option>
            //          <option value="54">Parent Counseling and Training Services</option>
            //          <option value="55">Physical Therapy Services</option>
            //          <option value="56">Psychological Services</option>
            //          <option value="57">Reader Services</option>
            //          <option value="58">Recreational Services</option>
            //          <option value="59">Rehabilitation Counseling Services</option>
            //          <option value="60">School Health Services</option>
            //          <option value="61">School Nurse Services</option>
            //          <option value="62">School Psychological Services</option>
            //          <option value="63">Social Work Services</option>
            //          <option value="64">Special Transportation</option>
            //          <option value="65">Speech And Language Services</option>
            //          <option value="66">Transitional Services</option>
            //</select>


            this.AddService("Adapted Physical Education Services");
            this.AddService("Aide Services");



        }

        public void AddService(string service)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Select the service
            //SelectElement select = new SelectElement(browser.FindElement(By.Id("slServiceTypes"))); //Locating select list

            IWebElement serviceTypes = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "slServiceTypes", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(serviceTypes);
            select.SelectByText(service.Trim()); //Select item from list having option text as "Item1"

            //click the transfer button
            browser.FindElement(By.Id("addButton")).Click();

        }

        public void RemoveService(string service)
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //Select the service
            //SelectElement select = new SelectElement(browser.FindElement(By.Id("slServicesProvided"))); //Locating select list


            IWebElement servicesProvided = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.ID, "slServicesProvided", RunTimeVars.REPEAT_TIMES);
            SelectElement select = new SelectElement(servicesProvided);
            select.SelectByText(service.Trim()); //Select item from list having option text as "Item1"

            //click the transfer button
            browser.FindElement(By.Id("removeButton")).Click();

        }


        public void AssertServicesTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Assert Page Status
                    IWebElement element = browser.FindElement(By.Id("tab-2"));

                    if (element.Displayed)
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
                throw new Exception("Services Tab Is Not Displayed");
            }

        }
   
    
    
    
    }


}
