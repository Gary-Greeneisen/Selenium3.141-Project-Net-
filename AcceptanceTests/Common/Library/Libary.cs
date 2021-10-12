using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//
using AcceptanceTests.Common.Application;
using AcceptanceTests.Config;
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace AcceptanceTests.Common.Library
{
    public static class Libary
    {


        public static void RefreshApplication(RunTimeVars.Refresh refreshType)
        {
            //********************************
            // Implement TestContext
            //********************************
            if (refreshType == RunTimeVars.Refresh.TestContext)
            {

                //Empty method call
                //Different projects wil have different TestContext
            }

            if (refreshType == RunTimeVars.Refresh.PageRefresh)
            {

                //*************************************************
                // Implement Page Refresh using web driver methods
                //
                // Note: 
                // This seems to only refresh current data
                // When creating an application, the personal Tab
                // does not display the correct personnel to add
                //************************************************
                IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;
                browser.Navigate().Refresh();

                WaitForPageLoad(RunTimeVars.REPEAT_TIMES);

            }

            if (refreshType == RunTimeVars.Refresh.F5Refresh)
            {
                //**********************************
                // Implement Page Refresh using F5
                //to update the cache
                //
                //Note:
                //Refresh using F5 the web driver still displays
                // the exception
                //Result Message:	OpenQA.Selenium.StaleElementReferenceException:
                //stale element reference: element is not attached to the page document
                //
                //**********************************

                IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;

                Actions actions = new Actions(browser);
                actions.KeyDown(Keys.Control).SendKeys(Keys.F5).Perform();

                WaitForPageLoad(RunTimeVars.REPEAT_TIMES);
            }

        }



        public static string GetProjectDir()
        {
            //***************************************************************************************
            // .Net 4.6 and NUnit 3.11.0 changed the way the project path is returned
            // projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // You now have to use 
            //TestContext.CurrentContext.TestDirectory;
            //***************************************************************************************
            var runDir = TestContext.CurrentContext.TestDirectory.ToString();
            var dir1 = Directory.GetParent(runDir).FullName.ToString();
            var dir2 = Directory.GetParent(dir1).FullName.ToString();
            var projectDir = Directory.GetParent(dir2).FullName.ToString();

            return projectDir;
        }

        /// <summary>
        /// Get Data File based on App.config environment
        /// </summary>
        /// <returns></returns>
        public static string GetDataFileDir()
        {
            //First get the current environment from the appSettings section
            var environment = AppConfig.GetAppSettingsValue("Environment");

            //Get project/file dir
            var projectDir = GetProjectDir();
            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\" + environment + "\\";

            return dataFileDir;

        }

        public static void SetBrowserSize (IWebDriver browser, System.Drawing.Size browserSize)
        {

            //Reset browser back to orginal size
            //browser.Manage().Window.Size = New System.Drawing.Size(1024, 768);
            browser.Manage().Window.Size = browserSize;
        }

        public static System.Drawing.Size BrowserMaximize(IWebDriver browser)
        {
            //Get current browser size
            System.Drawing.Size browserSize = Libary.GetCurrentBrowserSize(TestRunnerInterface.Map.loginPage.browser);
            //Maximize the browser
            browser.Manage().Window.Maximize();

            return browserSize;

        }

        /// <summary>
        /// Return current browser size
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static System.Drawing.Size GetCurrentBrowserSize(IWebDriver browser)
        {
            //Set current browser size
            return browser.Manage().Window.Size;

        }

        /// <summary>
        /// Get Default Browser Size
        /// </summary>
        /// <returns></returns>
        public static System.Drawing.Size GetDefaultBrowserSize()
        {
            return TestRunnerInterface.Map.loginPage.DefaultBrowserSize;
        }
        

         //***********************************************************************************************
        //  Implicit Wait Section
        //***********************************************************************************************

        //******************************* Begin Implicit Wait Wait Section *********************************************
        // ImplicitWait Wait and Find element
        //
        /// Is Page Element Displayed with a Timeout Parameter
        // I tried uisng Explict waits
        //WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
        //IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.ClassName(searchString)));
        //but there is no way to exclude nosuchelement exception
        //
        //so implement a user defined method that does 3-things
        // 1. reset the browser Implict wait time = 1-sec
        // 2. Search for the web element
        // 3. restore the browser Implict wait time = initial wait time
        public static bool ImplicitWaitIsPageElementDisplayed(IWebDriver browser,
                                                   RunTimeVars.ELEMENTSEARCH searchType,
                                                   string searchString,
                                                   int seconds)
        {
            var isFound = false;
            IWebElement element = null;

            //Divide the passed in time(seconds/2) to compensate for the 1-sec 
            // System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
            var controlWaitTime = seconds / 2;
            if (controlWaitTime == 0) controlWaitTime = 1;

            //Date - 12/21/18 Can't read current browser.ImplicitWait time, get not implemented
            //set the browser Implict wait time = 1-sec
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            while (controlWaitTime > 0)
            {
                try
                {
                    if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                    {
                        element = browser.FindElement(By.ClassName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                    {
                        element = browser.FindElement(By.CssSelector(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                    {
                        element = browser.FindElement(By.Id(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                    {
                        element = browser.FindElement(By.LinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                    {
                        element = browser.FindElement(By.PartialLinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                    {
                        element = browser.FindElement(By.Name(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                    {
                        element = browser.FindElement(By.TagName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                    {
                        element = browser.FindElement(By.XPath(searchString));
                    }

                    if (element.Displayed)
                    {
                        isFound = true;
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                isFound = false;
            }

            //restore the browser Implict wait time = initial wait time
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);

            return isFound;

        }

        // ImplicitWait Wait and Find element
        /// <summary>
        /// Wait until the page element is displayed
        /// Return the selected page element
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="retrys"></param>
        /// <returns>IWebElement element 
        ///       element = Displayed and Enabled
        /// </returns>
        public static IWebElement ImplicitWaitGetPageElement(IWebDriver browser,
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int seconds,
                                                    Boolean clickElement = false)
        {
            IWebElement element = null;

            //Divide the passed in time(seconds/2) to compensate for the 1-sec 
            // System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
            var controlWaitTime = seconds / 2;
            if (controlWaitTime == 0) controlWaitTime = 1;

            //Date - 12/21/18 Can't read current browser.ImplicitWait time, get not implemented
            //set the browser Implict wait time = 1-sec
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            while (controlWaitTime > 0)
            {
                try
                {
                    if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                    {
                        element = browser.FindElement(By.ClassName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                    {
                        element = browser.FindElement(By.CssSelector(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                    {
                        element = browser.FindElement(By.Id(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                    {
                        element = browser.FindElement(By.LinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                    {
                        element = browser.FindElement(By.PartialLinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                    {
                        element = browser.FindElement(By.Name(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                    {
                        element = browser.FindElement(By.TagName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                    {
                        element = browser.FindElement(By.XPath(searchString));
                    }


                    if (element.Displayed && element.Enabled)
                    {
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            // Check the passed in optional parameter Boolean clickElement
            // passed in Boolean clickElement = true
            if (element == null)
            {
                throw new Exception("Web Page Search-" + "('" + searchString + "')" + " Was Not Found");
            }
            else if (clickElement)
            {
                element.Click();
            }

            return element;


        }



        //******************************* End Implicit Wait Section ********************************************


        //***********************************************************************************************
        //  Explicit Wait Section
        //***********************************************************************************************


        //******************************* Begin Explicit Wait Section ********************************************

        // ExplicitWait Wait and Find element
        //  set the browser Implict wait time = Explict wait time * 2
        //to prevent browser nosuchelement exception being displayed before the Impliict wait time expires
        /// <summary>
        /// Is Page Element Displayed with a Timeout Parameter
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static bool ExplicitWaitIsPageElementDisplayed(IWebDriver browser, 
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int seconds)
        {

            //Date - 12/21/18 Can't read current browser.ImplicitWait time, get not implemented
            //set the browser Implict wait time = Explict wait time * 2
            //to prevent Explict waits nosuchelement exception being displayed before the Impliict wait time expires
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds *2);

            //Explict waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));

            var isFound = false;
            IWebElement element = null;

            try
            {
                if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.ClassName(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.Id(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.LinkText(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.PartialLinkText(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.Name(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.TagName(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.XPath(searchString)));
                }

                //include this in the try section
                if (element.Displayed)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }
            }
            catch
            {
                isFound = false;
            }

            //restore the browser Implict wait time = initial wait time
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);

            return isFound;

        }

        /// <summary>
        /// Wait until the page element is displayed
        /// Return the selected page element
        /// 
        /// set the browser Implict wait time = Explict wait time * 2
        ///to prevent browser nosuchelement exception being displayed before the Impliict wait time expires
        ///        
        // Modify the method to accept an optional parameter
        // passed in Boolean clickElement = false
        // if (passed in method Boolean clickElement = true
        ///     then if(element is found) thne click the element
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="seconds"></param>
        /// <returns>IWebElement element 
        ///       element = Displayed and Enabled
        /// </returns>
        public static IWebElement ExplicitWaitGetPageElement(IWebDriver browser,
                                                 RunTimeVars.ELEMENTSEARCH searchType,
                                                 string searchString,
                                                 int seconds,
                                                 Boolean clickElement = false)
        {

            //Date - 12/21/18 Can't read current browser.ImplicitWait time, get not implemented
            //set the browser Implict wait time = Explict wait time * 2
            //to prevent Explict waits nosuchelement exception being displayed before the Impliict wait time expires
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds * 2);

            //Explict waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));

            IWebElement element = null;

            try
            {
                if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.ClassName(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.Id(searchString)));
  
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.LinkText(searchString)));

                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.PartialLinkText(searchString)));

                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.Name(searchString)));

                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                {
                    element = wait.Until<IWebElement>(d => d.FindElement(By.TagName(searchString)));

                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                {
                   element = wait.Until<IWebElement>(d => d.FindElement(By.XPath(searchString)));
  
                }

                //include this in the try section
                //if (the element not Displayed And not Enabled)
                // then return element = null
                if (!(element.Displayed && element.Enabled))
                {
                    element = null;
                }

            }
            catch
            {
                element = null;
            }

            // Check the passed in optional parameter Boolean clickElement
            // passed in Boolean clickElement = true
            if(element == null)
            {
                throw new Exception("Web Page Search-" + "('" + searchString + "')" + " Was Not Found");
            }
            else if (clickElement)
            {
                element.Click();
            }



            return element;

        }


        //******************************* End Explicit Wait Section ********************************************


        //***********************************************************************************************
        //  Fluent Wait Section
        //***********************************************************************************************

        //******************************* Begin Fluent Wait Section ********************************************

        // Fluent Wait Example
        //From web site - https://gist.github.com/up1/d925783ea8e5f706f3bb58c3ce1ef7eb
        public static void fluentWaitExample(IWebDriver browser, By locator, int seconds)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(browser);
            fluentWait.Timeout = TimeSpan.FromSeconds(seconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(locator));

        }

        // FluenttWait Wait and Find element
        // This method behavior is exactly the same as the Explicit Wait Method
        /// set the browser Implict wait time = Explict wait time * 2
        ///to prevent browser nosuchelement exception being displayed before the Impliict wait time expires
        /// <summary>
        /// Is Page Element Displayed with a Timeout Parameter
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static bool FluenttWaitIsPageElementDisplayed(IWebDriver browser,
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int seconds)
        {

            //Date - 12/21/18 Can't read current browser.ImplicitWait time, get not implemented
            //set the browser Implict wait time = Explict wait time * 2
            //to prevent Explict waits nosuchelement exception being displayed before the Impliict wait time expires
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds * 2);

            //Fluent wait initialize
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(browser);
            fluentWait.Timeout = TimeSpan.FromSeconds(seconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            var isFound = false;
            IWebElement element = null;

            try
            {
                if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                {
                    element = fluentWait.Until(x => x.FindElement(By.ClassName(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                {
                    element = fluentWait.Until(x => x.FindElement(By.CssSelector(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                {
                     element = fluentWait.Until(x => x.FindElement(By.Id(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                {
                    element = fluentWait.Until(x => x.FindElement(By.LinkText(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                {
                    element = fluentWait.Until(x => x.FindElement(By.PartialLinkText(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                {
                    element = fluentWait.Until(x => x.FindElement(By.Name(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                {
                    element = fluentWait.Until(x => x.FindElement(By.TagName(searchString)));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                {
                    element = fluentWait.Until(x => x.FindElement(By.XPath(searchString)));
                }

                //include this in the try section
                if (element.Displayed)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }
            }
            catch
            {
                isFound = false;
            }

            //restore the browser Implict wait time = initial wait time
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);

            return isFound;

        }


        //******************************* End Fluent Wait Section ********************************************

  


        /// <summary>
        /// Is Page Element Displayed with NO Timeout Parameter
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static bool IsPageElementDisplayed(IWebDriver browser,
                                               RunTimeVars.ELEMENTSEARCH searchType,
                                               string searchString)
        {
            var isFound = false;
            IWebElement element = null;

            try
            {
                if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                {
                    element = browser.FindElement(By.ClassName(searchString));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                {
                    element = browser.FindElement(By.CssSelector(searchString));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                {
                    element = browser.FindElement(By.Id(searchString));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                {
                    element = browser.FindElement(By.LinkText(searchString));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                {
                    element = browser.FindElement(By.PartialLinkText(searchString));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                {
                    element = browser.FindElement(By.Name(searchString));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                {
                    element = browser.FindElement(By.TagName(searchString));
                }

                if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                {
                    element = browser.FindElement(By.XPath(searchString));
                }

                if (element.Displayed)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }
            }
            catch
            {
                isFound = false;
            }


            return isFound;

        }


        /// <summary>
        /// Is Page Element Displayed with a Timeout Parameter
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="retrys"></param>
        /// <returns></returns>
        public static bool IsPageElementDisplayed(IWebDriver browser,
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int retrys)
        {
            var isFound = false;
            var controlWaitTime = retrys;
            IWebElement element = null;

            while (controlWaitTime > 0)
            {
                try
                {
                    if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                    {
                        element = browser.FindElement(By.ClassName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                    {
                        element = browser.FindElement(By.CssSelector(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                    {
                        element = browser.FindElement(By.Id(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                    {
                        element = browser.FindElement(By.LinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                    {
                        element = browser.FindElement(By.PartialLinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                    {
                        element = browser.FindElement(By.Name(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                    {
                        element = browser.FindElement(By.TagName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                    {
                        element = browser.FindElement(By.XPath(searchString));
                    }

                    if (element.Displayed)
                    {
                        isFound = true;
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                isFound = false;
            }

            return isFound;

        }


        /// <summary>
        /// Wait until the page element is displayed
        /// Resutn the selected page element
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="retrys"></param>
        /// <returns>IWebElement element 
        ///       element = Displayed and Enabled
        /// </returns>
        public static IWebElement GetPageElement(IWebDriver browser,
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int retrys)
        {
            var controlWaitTime = retrys;
            IWebElement element = null;

            while (controlWaitTime > 0)
            {
                try
                {
                    if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                    {
                        element = browser.FindElement(By.ClassName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                    {
                        element = browser.FindElement(By.CssSelector(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                    {
                        element = browser.FindElement(By.Id(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                    {
                        element = browser.FindElement(By.LinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                    {
                        element = browser.FindElement(By.PartialLinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                    {
                        element = browser.FindElement(By.Name(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                    {
                        element = browser.FindElement(By.TagName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                    {
                        element = browser.FindElement(By.XPath(searchString));
                    }


                    if (element.Displayed && element.Enabled)
                    {
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Web Page Search-" + element + " Was Not Found");
            }

            return element;

        }



        public static void ClickElement(IWebDriver browser, IWebElement element, bool actionClass, int retrys)
      {

          Actions action = new Actions(browser);
          var controlWaitTime = retrys;

          while (controlWaitTime > 0)
          {
              try
              {
                  if (actionClass)
                  {
                      action.MoveToElement(element).Click().Build().Perform();
                  }
                  else
                  {
                      element.Click();
                  }


              }
              catch
              {
                  //if (page element is not avaiable yet)
                  System.Threading.Thread.Sleep(5 * 1000); //Wait 1-sec
                  controlWaitTime--;
              }

          }

          //Check if(Element.Click <= controlWaitTime)
          if (controlWaitTime <= 0)
          {
              throw new Exception("Page element-" + element + " Was Not Clickable");
          }

      }

 
      public static void WaitForPageText(IWebDriver browser, string text, int repeat_times)
      {

          var controlWaitTime = repeat_times;

          while (controlWaitTime > 0)
          {
              try
              {
                  //get page text
                  var pageText = browser.FindElement(By.TagName("body")).Text;

                  if (pageText.Contains(text))
                  {
                      break;
                  }

                  System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                  controlWaitTime--;

                }
              catch
              {
                  System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                  controlWaitTime--;
                  continue;
              }

          }

          //Check if(Page displayed <= controlWaitTime)
          if (controlWaitTime <= 0)
          {
              throw new Exception("Page Text..." + text + "...Not Found...repeat_time = " + repeat_times);
          }

      }

        public static bool IsPageTextDIsplayed(string text, int repeat_times)
        {

            bool pageTextDisplayed = false;
            var controlWaitTime = repeat_times;

            IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;


            while (controlWaitTime > 0)
            {
                try
                {
                    //get page text
                    var pageText = browser.FindElement(By.TagName("body")).Text;

                    if (pageText.Contains(text))
                    {
                        pageTextDisplayed = true;
                        break;
                    }
                    //else..
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }
                catch
                {
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                    continue;
                }

            }

            return pageTextDisplayed;
        }



        /// <summary>
        /// Wait until document.readyState = complete
        /// </summary>
        /// <param name="retrys"></param>
        public static void WaitForPageLoad(int retrys)
        {

            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    var documentState = ((IJavaScriptExecutor)browser).ExecuteScript("return document.readyState").ToString();

                    if (documentState.Equals("complete"))
                    {
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("...Page Failed To Load in (" + retrys + ") retrys...");
            }

        }


        public static Boolean SwitchWindow(string title)
        {

            var windowFound = false;
            IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;

            var currentWindow = browser.CurrentWindowHandle;
            var availableWindows = new List<string>(browser.WindowHandles);

            foreach (string window in availableWindows)
            {
                if (window != currentWindow)
                {
                    browser.SwitchTo().Window(window);
                    //if (string.Equals(title, browser.Title, StringComparison.OrdinalIgnoreCase))
                    //if (browser.Title.Contains(title))
                    var windowTitle = browser.Title;
                    if (browser.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        windowFound = true;
                        break;
                    }
                    else
                    {
                        browser.SwitchTo().Window(currentWindow);
                        windowFound = false;
                    }
                }
            }

            return windowFound;

        }


        public static void JavaScriptNewWindow()
        {
            var url = "https://www.google.com";

            IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;

            //To open the window:

            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("window.open()");

            //Then to switch windows, use the window handles:

            List<string> handles = browser.WindowHandles.ToList<string>();
            browser.SwitchTo().Window(handles.Last());


            browser.Navigate().GoToUrl(url);

        }

        public static void SetWebDiverWaitTime(int seconds)
        {
            //Implicit waits
            IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void ReSetWebDiverWaitTime()
        {
            //Implicit waits
            IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);
        }


        public static void WaitForElementByID(IWebDriver browser, string IDName, int seconds)
        {
            //Implicit waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id(IDName)));
        }

        public static void WaitForElementByXpath(IWebDriver browser, string xpath, int seconds)
        {
            //Implicit waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.XPath(xpath)));
        }

        public static void WaitForElementByName(IWebDriver browser, string name, int seconds)
        {
            //Implicit waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Name(name)));
        }

        public static void ClickHiddenElement(IWebDriver browser, IWebElement element)
        {
            IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)browser;
            jsDriver.ExecuteScript("arguments[0].click();", element);
        }
		  

        public static void HighLight(IWebDriver browser, IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)browser;
            //var element = //element to be found
            //string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 4px; border-style: solid; border-color: blue"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        } 

        public static string FormatSSN(string strSSN)
        {
            return strSSN.Insert(5, "-").Insert(3, "-");
        }


        public static string FormatDate(string strDate)
        {

            DateTime dt = Convert.ToDateTime(strDate);
            string result = dt.ToString("MM/dd/yyyy");

            return result;
        }

        public static int CalculateAge(string strDate)
        {
            int age = 0;

            DateTime dateOfBirth = Convert.ToDateTime(strDate);
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        public static string CalculateDOBByYear(int age)
        {
      
            //DateTime oneYearAgoToday = DateTime.Now.AddYears(-1);
            DateTime dateTimeDOB = DateTime.Now.AddYears(age * -1);
            string DOB = dateTimeDOB.ToString("MM/dd/yyyy");

            return DOB;
        }

        public static string CalculateDOBByMonth(int months)
        {

            //DateTime oneYearAgoToday = DateTime.Now.AddYears(-1);
            DateTime dateTimeDOB = DateTime.Now.AddMonths(months * -1);
            string DOB = dateTimeDOB.ToString("MM/dd/yyyy");

            return DOB;
        }


        /// <summary>
        /// Parse the Value:TagInstancestring pairs
        /// String Format = [Value:TagInstance pairs]
        /// [2:12;1:13;3:14;4:15]
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static string[] ValueTagInstance(string tags)
        {
            //strip off the beginning '[' and the end ']'
            int strLength = tags.Length;
            string newString = tags.Substring(1, strLength - 2);

            //split the string for check-boxes Value:TagInstance
            string[] values = newString.Split(';');

            return values;


        }

        public static string[] SplitString(string[] strString, int number, char delimiter)
        {
            //split the string for Value1:Value2
            string result = strString[number];
            string[] values = result.Split(delimiter);

            return values;

        }

        public static string[] GetRowCol(string tags)
        {

            //strip off the beginning '[' and the end ']'
            int strLength = tags.Length;
            string newString = tags.Substring(1, strLength - 2);

            string[] values = newString.Split(':');

            return values;
        }

        public static string FormatDir(string dir, string filename)
        {
            string strFormat;

            if (dir.EndsWith("\\"))
            {
                strFormat = dir + filename;
            }
            else
            {
                strFormat = dir + "\\" + filename;
            }

            return strFormat;
        }


    } //end public static class Libary


} // end namespace ODEFrameWorkCodedUIProject.Common.Library
