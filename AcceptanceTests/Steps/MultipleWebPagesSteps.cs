using System;
using TechTalk.SpecFlow;

//
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Library;
using OpenQA.Selenium;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class MultipleWebPagesSteps
    {

        //Create class var to track run-time errors
        string errorString;
        Boolean error = false;

        [Given(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string WebPage)
        {
            //Call LoginPage.LaunchBrowser() method
            TestRunnerInterface.Map.safePage.LaunchBrowser(WebPage);


        }

        [Given(@"I verify page ""(.*)""")]
        public void GivenIVerifyPage(string text)
        {
            //Wait for the page to load
            Libary.WaitForPageLoad(10);

            //get page text
            OpenQA.Selenium.IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            var pageText = browser.FindElement(By.TagName("body")).Text;

            if (!pageText.Contains(text))
            {
                error = true;
                errorString = ("Page Test(" + text + ") not found");
            }

        }

        [Then(@"I Close The Web Page")]
        public void ThenICloseTheWebPage()
        {
            TestRunnerInterface.Map.safePage.BrowserClose();

            //Check for run-time errors
            if(error)
            {
                throw new Exception(errorString);
            }

        }


    }
}
