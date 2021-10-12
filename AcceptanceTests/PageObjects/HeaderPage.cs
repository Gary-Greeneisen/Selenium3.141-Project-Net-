using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Common.Application;

namespace AcceptanceTests.PageObjects
{
    public partial class HeaderPage
    {
        public void SignOut()
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;
            browser.FindElement(By.LinkText("[Sign Out]")).Click();

        }


        public void BackToSearchResults(string link )
        {
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            //IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.LinkText, "Back to Basic Search results", RunTimeVars.REPEAT_TIMES);
            IWebElement element = Libary.GetPageElement(browser, RunTimeVars.ELEMENTSEARCH.LinkText, link, RunTimeVars.REPEAT_TIMES);

            element.Click();

        }







    } //End public partial class HeaderPage



} //end namespace AcceptanceTests.PageObjects
