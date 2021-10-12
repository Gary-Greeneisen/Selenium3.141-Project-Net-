using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;

// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class GoogleSearchSteps
    {

        //create a class var
        public IWebDriver browser = null;

        //Set the browser
        //public string browserType = "Firefox";
        public string browserType = "Chrome";
        //public string browserType = "IE";
        //public string browserType = "Edge";

        //variables for current project dir
        public string runDir, dir1, dir2, dir3, driverDir;

        //define error conditions
        string errorString;
        bool isError = false;

        [Given(@"I Open a browser to ""(.*)""")]
        public void GivenIOpenABrowserTo(string page)
        {
            //***************************************************************************************
            // .Net 4.6 and NUnit 3.11.0 changed the way the project path is returned
            // projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // You now have to use 
            //TestContext.CurrentContext.TestDirectory;
            //***************************************************************************************
            //Get the project runtime dir
            runDir = TestContext.CurrentContext.TestDirectory.ToString();
            dir1 = Directory.GetParent(runDir).FullName.ToString();
            dir2 = Directory.GetParent(dir1).FullName.ToString();
            dir3 = Directory.GetParent(dir2).FullName.ToString();
            driverDir = dir3 + @"\packages\";


            //ScenarioContext.Current.Pending();
            switch (browserType.ToUpper())
            {
                case "FIREFOX":

                    // Implement FireFox using geckdriver file
                    //***************************************************************************************
                    // .Net 4.6 and NUnit 3.11.0 changed the way the project path is returned
                    // projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                    // You now have to use 
                    //TestContext.CurrentContext.TestDirectory;
                    //***************************************************************************************
                    //var parent = TestContext.CurrentContext.TestDirectory;
                    //string projectDir = parent.Substring(0,parent.Length - 10);
                    //var driverDir = projectDir + @"\packages\";

                    //Add framework packages dir to app.config
                    //var driverDir = @"C:\Test\Selenium3.141 Framework(Net)\packages\";

                    // location of the geckdriver.exe file
                    var driverService = FirefoxDriverService.CreateDefaultService(driverDir);

                    driverService.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    driverService.HideCommandPromptWindow = true;
                    driverService.SuppressInitialDiagnosticInformation = true;
                    browser = new FirefoxDriver(driverService, new FirefoxOptions(), TimeSpan.FromSeconds(60));

                    var url = "http://" + page;
                    browser.Navigate().GoToUrl(url);

                    break;

                case "CHROME":

                    //***************************************************************************************
                    // .Net 4.6 and NUnit 3.11.0 changed the way the project path is returned
                    // projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                    // You now have to use 
                    //TestContext.CurrentContext.TestDirectory;
                    //***************************************************************************************
                    //var parent = TestContext.CurrentContext.TestDirectory;
                    //string projectDir = parent.Substring(0,parent.Length - 10);
                    //var driverDir = projectDir + @"\packages\";

                    //Add framework packages dir to app.config
                    //var driverDir = @"C:\Test\Selenium3.141 Framework(Net)\packages\";
                    browser = new ChromeDriver(driverDir);

                    url = "http://" + page;
                    browser.Navigate().GoToUrl(url);


                    break;

                case "IE":

                    isError = true;
                    errorString = "IE Driver not Implemented";

                    break;

                case "EDGE":

                    //***************************************************************************************
                    // .Net 4.6 and NUnit 3.11.0 changed the way the project path is returned
                    // projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                    // You now have to use 
                    //TestContext.CurrentContext.TestDirectory;
                    //***************************************************************************************
                    //var parent = TestContext.CurrentContext.TestDirectory;
                    //string projectDir = parent.Substring(0,parent.Length - 10);
                    //var driverDir = projectDir + @"\packages\";

                    //Add framework packages dir to app.config
                    //var driverDir = @"C:\Test\Selenium3.141 Framework(Net)\packages\";

                    //********************************************
                    //Member name Value Description
                    //Default     0       Indicates the behavior is not set.
                    //Normal      1       Waits for pages to load and ready state to be 'complete'.
                    //Eager       2       Waits for pages to load and for ready state to be 'interactive' or 'complete'.
                    //None        3       Does not wait for pages to load, returning immediately.
                    //*********************************************
                    browser = new EdgeDriver(driverDir);

                    url = "http://" + page;
                    browser.Navigate().GoToUrl(url);

                    break;

            }

            if (isError)
            {
                throw new Exception(errorString);
            }

        }

        [Given(@"I search for ""(.*)""")]
        public void GivenISearchFor(string searchItem)
        {
            //ScenarioContext.Current.Pending();
            // Find the text input element by its name
            IWebElement search = browser.FindElement(By.Name("q"));
            search.SendKeys(searchItem);
            search.SendKeys(Keys.Return);

            // Wait for the page to load, timeout after 20 seconds
            WebDriverWait wait = new WebDriverWait(browser,
                    TimeSpan.FromSeconds(20));
            //Get the Browser Window Title
            var browserWindowText = browser.Title;
            wait.Until((d) => { return d.Title.ToLower().StartsWith(searchItem.ToLower() ); });

            //Search for Amazon link
            //This works in Chome, but not in Firefox
            //browser.FindElement(By.PartialLinkText("Amazon"));

            //Add Wait for Amazon link to be displayed
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.PartialLinkText("Amazon")));

        }

        [When(@"I click on the first link")]
        public void WhenIClickOnTheFirstLink()
        {
            //ScenarioContext.Current.Pending();
            // Wait for the page to load, timeout after 10 seconds
            //wait.Until(browser.FindElement(By.LinkText("Amazon.com: Books")));

            //Wait for Amazon link to be displayed
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.PartialLinkText("Amazon")));

            browser.FindElement(By.PartialLinkText("Amazon")).Click();

        }

        [Then(@"the number of page images are (.*)")]
        public void ThenTheNumberOfPageImagesAre(int count)
        {
            //ScenarioContext.Current.Pending();
            var listImages = browser.FindElements(By.TagName("img"));
            //for Firefox
            //browser.Close() did not close the browser
            //browser.Quit() works using Firefox
            // so use both of them
            browser.Close();
            browser.Quit();



            //Check the #Page Images and Count
            if (listImages.Count != count)
            {
                throw new Exception("The Expected #Images = " + count
                                    + " The Actual #Images = " + listImages.Count);

            }

        }
    }
}
