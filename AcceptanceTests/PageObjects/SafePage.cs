using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Common.Application;
// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using AcceptanceTests.Config;
using AcceptanceTests.Common.Library;
using System.IO;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

namespace AcceptanceTests.PageObjects
{
    public partial class SafePage
    {
        //create a class var
        public IWebDriver browser = null;
        public string browserType = string.Empty;
        public bool browserClosed = false;
        public System.Drawing.Size DefaultBrowserSize;

        //Variables to set browser Height, Width
        private int browserHeight;
        private int browserHWidth;

        //private const string IE_DRIVER_PATH = @"C:\ODE-Projects\ODESeleniumFrameWorkProject\packages\Selenium.WebDriver.2.45.0\lib\net40";
        //private const string CHROME_DRIVER_PATH = @"C:\ODE-Projects\ODESeleniumFrameWorkProject\packages\WebDriver.ChromeDriver.26.14.313457.1\tools";

        /// <summary>
        /// Internet Explorer Problems
        /// One setting has to be changed in Internet Explorer 
        /// in order for Selenium WebDriver to work correctly. 
        /// Your security zones need to have protected mode either 
        /// enabled or disabled – it doesn’t matter which, as long 
        /// as it’s the same for each zone
        /// 
        /// To achieve this follow these steps:
        /// Open IE and go to Internet Options.
        /// Go to the ‘Security’ tab.
        /// Click on each of the zones, 
        /// i.e. ‘Internet’, ‘Local intranet’, 
        /// ‘Trusted sites’ and ‘Restricted sites’ 
        /// and ensure that the ‘Enable Protected Mode 
        /// (requires restarting Internet Explorer)’ check box 
        /// is checked.
        /// 
        /// Using WebDriver Implicit Wait Time
        /// </summary>
        /// <returns></returns>
        /// 
        ///Explicit Waits
        ///An explicit wait is code you define to wait for a certain condition
        ///to occur before proceeding further in the code. The worst case of this
        ///is Thread.sleep(), which sets the condition to an exact time period to wait. 
        ///There are some convenience methods provided that help you write code that will 
        ///wait only as long as required. WebDriverWait in combination with ExpectedCondition
        ///is one way this can be accomplished.
        ///
        ///Implicit Waits
        ///An implicit wait is to tell WebDriver to poll the DOM for a certain amount of time 
        ///when trying to find an element or elements if they are not immediately available.
        ///The default setting is 0. Once set, the implicit wait is set for the life of the WebDriver object instance.
        ///

        //************************************************************
        // Modify the method to accept an optional parameter
        // passed in web page defaults = null
        // if (passed in web page = Null)
        //    then use the variable url = app.config web page value
        // if (passed in web page != Null)
        //    then ignore the variable url = app.config web page value
        //         and use the passed in web page string
        //************************************************************
        public IWebDriver LaunchBrowser(string webPage = null)
        {
            //Update class var
            browserClosed = false;

            var url = RunTimeVars.TargetURL;
            browserType = AppConfig.GetAppSettingsValue("BrowserType").ToUpper();

            //Browser Driver dir
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var driverDir = projectDir + @"\packages\";


            switch (browserType)
            {
                case "FIREFOX":
                    //browser = new FirefoxDriver();
                    //FirefoxBinary fireFoxBinary = new FirefoxBinary();
                    //FirefoxProfile fireFoxProfile = new FirefoxProfile();
                    //browser = new FirefoxDriver(fireFoxBinary, fireFoxProfile, System.TimeSpan.FromSeconds(RunTimeVars.PAGELOADWAIT));

                    //var driverService = FirefoxDriverService.CreateDefaultService(driverDir);
                    //driverService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    //driverService.HideCommandPromptWindow = true;
                    //driverService.SuppressInitialDiagnosticInformation = true;
                    //browser = new FirefoxDriver(driverService, new FirefoxOptions(), System.TimeSpan.FromSeconds(RunTimeVars.PAGELOADWAIT));

                    var driverService = FirefoxDriverService.CreateDefaultService(driverDir);
                    driverService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    driverService.HideCommandPromptWindow = true;
                    driverService.SuppressInitialDiagnosticInformation = true;
                    browser = new FirefoxDriver(driverService, new FirefoxOptions(), TimeSpan.FromSeconds(60));

                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 1440   Heigth = 780
                    //set browser Height, Width
                    browserHeight = 980;
                    browserHWidth = 1440;

                    break;

                case "CHROME":
                    //Date - 10/15/2015
                    //Added ChromeOptions to disable the "Disable developer mode extensions pop up"
                    //displayed during document file uploads
                    //
                    // Result - Fixed. The developer mode extensions pop up no longer displayed
                    //browser = new ChromeDriver(driverDir);  

                    //Add Chrome startup options
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-extensions");
                    chromeOptions.AddArguments("disable-infobars");
                    browser = new ChromeDriver(driverDir, chromeOptions, System.TimeSpan.FromSeconds(RunTimeVars.PAGELOADWAIT));


                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 945   Heigth = 1026
                    //set browser Height, Width
                    browserHeight = 1026;
                    browserHWidth = 1500;

                    break;

                case "IE":
                    /**********************************************************/
                    //Note:
                    //IE web Driver throws an exception
                    //Date - 5/8/2017
                    //After IE 11 is launched, any operation that tries to Read/Write/Click any page element
                    //throws the exception below
                    //OpenQA.Selenium.NoSuchWindowException was unhandled by user code
                    //Message = Unable to find element on closed window
                    /*********************************************************/

                    //Date - 9/14/2015
                    //Added  DesiredCapabilities as a workaround to access Menu submenu
                    //
                    // Result- No effect, still can't select submenus in IE
                    //DesiredCapabilities ieCapabilities = DesiredCapabilities.InternetExplorer();
                    //ieCapabilities.SetCapability("requireWindowFocus", true);      //default = false
                    //ieCapabilities.SetCapability("enablePersistentHover", false);  //default = true
                    ////browser = new InternetExplorerDriver(driverDir);

                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.BrowserAttachTimeout = System.TimeSpan.FromSeconds(60);
                    ieOptions.RequireWindowFocus = true;
                    ieOptions.EnablePersistentHover = true;
                    ieOptions.IgnoreZoomLevel = true;
                    //ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

                    browser = new InternetExplorerDriver(driverDir, ieOptions, System.TimeSpan.FromSeconds(60));

                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 600   Heigth = 1040
                    //set browser Height, Width
                    browserHeight = 960;
                    browserHWidth = 1609;

                    break;

                case "EDGE":
                    // location for MicrosoftWebDriver.exe

                    //********************************************
                    //Member name Value Description
                    //Default     0       Indicates the behavior is not set.
                    //Normal      1       Waits for pages to load and ready state to be 'complete'.
                    //Eager       2       Waits for pages to load and for ready state to be 'interactive' or 'complete'.
                    //None        3       Does not wait for pages to load, returning immediately.
                    //*********************************************
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

                    browser = new EdgeDriver(driverDir, edgeOptions);

                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 1236   Heigth = 856
                    //set browser Height, Width
                    browserHeight = 865;
                    browserHWidth = 1236;
                    break;

                default:
                    browser = new ChromeDriver(driverDir);
                    break;

            }

            if (browserType.Equals("EDGE"))
            {
                //Set page load timeout to x seconds
                //browser.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(RunTimeVars.PAGELOADWAIT));
                browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(RunTimeVars.PAGELOADWAIT);
            }
            else
            {
                // Initialize autocomplete to wait - Implicit Wait (x)-seconds
                //browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT));
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);

                //Set page load timeout to x seconds
                //The SetPageLoadTimeout() does not work
                //use the driver constructor to set the page load time  for all other web drivers
                //browser.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(RunTimeVars.PAGELOADWAIT));
            }

            //Set Default Browser Size
            //DefaultBrowserSize(Width, Height)
            //Width = 945   Heigth = 1026
            browser.Manage().Window.Size = new System.Drawing.Size(browserHWidth, browserHeight);
            //browser.Manage().Window.FullScreen();
            DefaultBrowserSize = browser.Manage().Window.Size;

            //********  Modified to use optioanl parameters **************
            // if(optional parameter = null)
            //   then use the app.config value
            // else
            //  Use the passed in web page url
            if (webPage == null)
            {
                browser.Navigate().GoToUrl(url);
            }
            else
            {
                browser.Navigate().GoToUrl(webPage);
            }

            return browser;
        }

        //launch the browser and login
        private void AppLogin(string role)
        {

            this.LaunchBrowser();


            //Login with Username/Pwd
            var result = AppConfig.GetAppSectionValue(role);
            string[] userPwd = result.Split(',');

            this.Login(userPwd[0], userPwd[1]);
        }

        public void GivenaUserRole(string role)
        {

            this.AppLogin(role);
        }

        public void Login(string userName, string passWord)
        {
            // Find the text input element by its name
            IWebElement username = browser.FindElement(By.Id("UserName"));
            Libary.HighLight(browser, username);
            username.SendKeys(userName);

            IWebElement password = browser.FindElement(By.Id("Password"));
            Libary.HighLight(browser, password);

            //IE browser password need encrypted 
            // password.SendKeys(passWord);

            //Workaround use Java Script to enter password
            //((IJavaScriptExecutor)browser).ExecuteScript("document.getElementById('Password').value = '12@safe'");
            var encryptedPassword = "document.getElementById('Password').value = '" + passWord + "'";
            ((IJavaScriptExecutor)browser).ExecuteScript(encryptedPassword);

            IWebElement signin = browser.FindElement(By.Id("btnSignIn"));
            Libary.HighLight(browser, signin);
            signin.Click();

        }

        /// <summary>
        /// Using Implicit Wait Time
        /// </summary>
        /// <param name="seconds"></param>
        public void WaitForPageLoad(int seconds)
        {

            /*************************************
             * Switch from WebDriver Explicit Wait to Implicit Wait
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            //Get the Browser Window Title
            var browserWindowText = browser.Title;

            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Change Name")));
            //wait.Until((d) => { return d.Title.ToLower().StartsWith("books"); });
            ****************************************/

            IWebElement changeName = browser.FindElement(By.LinkText("Change Name"));
            Libary.HighLight(browser, changeName);
        }

        /// <summary>
        /// Using Implicit Wait Time
        /// </summary>
        /// <param name="seconds"></param>
        public void WaitForSafeHomePage(int repeat_times)
        {
            /*********** comment out **********
             * Switch from WebDriver Explicit Wait to Implicit Wait
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            //Get the Browser Window Title
            var browserWindowText = browser.Title;

            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Change Name")));
            //wait.Until((d) => { return d.Title.ToLower().StartsWith("books"); });

            IWebElement changeName = browser.FindElement(By.LinkText("Change Name"));
            Libary.HighLight(browser, changeName);
             *********** comment out **********/

            var controlWaitTime = repeat_times;
            while (controlWaitTime > 0)
            {
                try
                {
                    IWebElement changeName = browser.FindElement(By.LinkText("Change Name"));
                    Libary.HighLight(browser, changeName);
                    break;
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
                throw new Exception("Safe Home Page Not Displayed...");
            }

        }


        public void WaitProductHomePage(string text, int repeat_times)
        {

            /************ comment out **********
            try
            {
 
                //def elem = driver.findElement(By.xpath("//*[contains(.,'search_text')]"));
                //Create the XPath definition
                var searchText = "//*[contains(.," + "'" + text + "')]";
                var element = browser.FindElement(By.XPath(searchText));
                //Read the page text
                var pageText = element.Text;
            }
            catch
            {
                throw new Exception("Page Text..." + text + "...Not Found...");
 
            }
            ************ comment out **********/
            var controlWaitTime = repeat_times;

            while (controlWaitTime > 0)
            {

                //get page text
                var searchText = this.AllPageText();

                if (!String.IsNullOrEmpty(searchText))
                {
                    if (searchText.Contains(text))
                    {
                        break;
                    }
                }

                System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                controlWaitTime--;

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Product Home Page Text..." + text + "...Not Found...");
            }

        }


        public void ClickLink(string link)
        {

            //browser.FindElement(By.LinkText(link)).Click();

            try
            {
                browser.FindElement(By.LinkText(link)).Click();
            }
            catch
            {
                System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
            }



        }

        public void BrowserClose()
        {
            //Update class var
            browserClosed = true;

            browser.Close();
            browser.Quit();
        }

        /// <summary>
        /// Check which Sign Out button text is displayed
        /// Text = Sign Out or Text = [Sign Out]
        /// 
        /// </summary>
        public void SignOut()
        {
            //browser.FindElement(By.LinkText("[Sign Out]")).Click();

            //Set Driver wait time = 0
            Libary.SetWebDiverWaitTime(0);
            IWebElement signOut1 = null;
            IWebElement signOut2 = null;
            IWebElement signOut3 = null;

            try
            {
                //Signout for program = FSL
                signOut1 = browser.FindElement(By.Id("ctl00_SafeAccountLink"));
            }
            catch
            {
                //Empty catch
            }

            try
            {
                //Signout for SAFE Home page
                signOut2 = browser.FindElement(By.LinkText("[Sign Out]"));
            }
            catch
            {
                //Empty catch
            }

            try
            {
                //Signout for product application page
                signOut3 = browser.FindElement(By.LinkText("Sign Out"));
            }
            catch
            {
                //Empty catch
            }


            if ((signOut1 == null)
                && (signOut2 == null)
                && (signOut3 == null))
            {
                throw new Exception("SignOut Link Not Found");
            }

            //
            //Workaround for the Google browser run-Time Exception
            //Result Message: System.InvalidOperationException : unknown error: Element is not clickable at point (982, 12). 
            //Other element would receive the click: <div class="ui-widget-overlay ui-front"></div>
            //Googled the error for fix
            //

            Actions actions = new Actions(browser);

            if (signOut1 != null)
            {
                //signOut1.Click();
                actions.MoveToElement(signOut1).Click().Perform();
            }
            if (signOut2 != null)
            {
                //signOut2.Click();
                actions.MoveToElement(signOut2).Click().Perform();
            }
            if (signOut3 != null)
            {
                //signOut3.Click();
                actions.MoveToElement(signOut3).Click().Perform();
            }


            //Reset Driver Wait Time
            Libary.ReSetWebDiverWaitTime();

        }

        /// <summary>
        /// Check if(Safe Home Page "Change Name" = displayed)
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSafeHomePageDisplayed()
        {

            bool IsFound = false;

            try
            {
                IWebElement changeName = browser.FindElement(By.LinkText("Change Name"));
                IsFound = true;
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }


        /// <summary>
        /// Check if (Change Pasword Text = displayed)
        /// </summary>
        /// <returns></returns>
        public bool IsChangePasswordDisplayed()
        {

            bool IsFound = false;

            try
            {
                IWebElement element = browser.FindElement(By.XPath(".//label[text()='Confirm new password:']"));
                IsFound = true;
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }

        /// <summary>
        /// Check if(Safe Home Page "Change Name" = displayed)
        ///  or if (Chnage Pasword Text = displayed)
        ///  
        ///Use implicit wait and initialize the timeout. When a quick response is required
        ///1. Reinitialize the wait timeout = 0-secs, 
        ///2. Wait for the page control operation to complete
        ///3. Reinitialize the wait timeout back = original timeout 
        //
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public bool IsChangePasswordDisplayed(int repeat_time)
        {
            bool IsFound = false;
            bool IsChangePwd = false;
            bool IsSafeHomePage = false;

            Libary.SetWebDiverWaitTime(0);
            var controlWaitTime = repeat_time;

            while (controlWaitTime > 0)
            {

                //Search for Change Password
                IsChangePwd = this.IsChangePasswordDisplayed();

                //Search for SafeHomePage
                IsSafeHomePage = this.IsSafeHomePageDisplayed();

                if ((IsChangePwd) || (IsSafeHomePage))
                {
                    IsFound = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000); //Wait 1-sec
                    controlWaitTime--;
                    continue;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                IsFound = false;
            }

            Libary.ReSetWebDiverWaitTime();
            return (IsFound) ? IsChangePwd : false;

        }

        public void ChangePasswordCancel()
        {
            //IWebElement element = browser.FindElement(By.CssSelector("[src* = '/portal/Content/Images/change.gif'] img[alt='Cancel']"));
            IWebElement element = browser.FindElement(By.CssSelector("img[alt='Cancel']"));
            element.Click();
        }

        /// <summary>
        /// Read all page text
        /// Using WebDriver Implicit Wait Time
        /// </summary>
        /// <returns></returns>
        public string AllPageText()
        {
            string pageText = string.Empty;

            try
            {
                pageText = browser.FindElement(By.TagName("body")).Text;
            }
            catch
            {
                //if(exception) return empty string
            }

            return pageText;
        }

        public void ChangePassword(string role)
        {
            /************ comment out ******************
            browser.FindElement(By.LinkText("Change Password")).Click();
            
            // Storing parent window reference into a String Variable 
            var parentWindow = browser.CurrentWindowHandle;
                        
            this.UpdatePassword(role);

            //Switch to the Conformation Dialog
            PopupWindowFinder childWindow = new PopupWindowFinder(browser,TimeSpan.FromSeconds(10),TimeSpan.FromSeconds(1));
            string newHandle = childWindow.Click(browser.FindElement(By.LinkText("Success!")));
            browser.SwitchTo().Window(newHandle);

            IWebElement close = browser.FindElement(By.XPath("//span[contains(text(),'Close')]"));
            Libary.HighLight(browser, close);

            //Switch back to parent window
            browser.SwitchTo().Window(parentWindow);
            ************ comment out *************/

            //*********************************
            //This must be a javascript popup dialog
            //and not seperate windows dialog popup
            //The PopupWindowFinder call above returned null for childWindow
            //*********************************

            browser.FindElement(By.LinkText("Change Password")).Click();
            this.UpdatePassword(role);


        }

        /// <summary>
        /// The change password page is already displayed
        /// </summary>
        /// <param name="role"></param>
        public void UpdatePassword(string role)
        {

            //Get current password based on User Role
            var result = AppConfig.GetAppSectionValue(role);
            string[] userPwd = result.Split(',');
            var oldPassWord = userPwd[1];

            //Get new password
            var newPassWord = AppConfig.GetAppSectionValue("NewPassword");

            //IE browser password need encrypted 
            // password.SendKeys(passWord);

            IWebElement OldPassword = browser.FindElement(By.Id("OldPassword"));
            //Workaround use Java Script to enter old password
            //((IJavaScriptExecutor)browser).ExecuteScript("document.getElementById('OldPassword').value = '12@safe'");
            var encryptedPassword = "document.getElementById('OldPassword').value = '" + oldPassWord + "'";
            ((IJavaScriptExecutor)browser).ExecuteScript(encryptedPassword);

            IWebElement NewPassword = browser.FindElement(By.Id("NewPassword"));
            //Workaround use Java Script to enter old password
            //((IJavaScriptExecutor)browser).ExecuteScript("document.getElementById('newPassword').value = '12@safe'");
            encryptedPassword = "document.getElementById('NewPassword').value = '" + newPassWord + "'";
            ((IJavaScriptExecutor)browser).ExecuteScript(encryptedPassword);

            IWebElement ConfirmPassword = browser.FindElement(By.Id("ConfirmPassword"));
            //Workaround use Java Script to enter old password
            //((IJavaScriptExecutor)browser).ExecuteScript("document.getElementById('confirmPassword').value = '12@safe'");
            encryptedPassword = "document.getElementById('ConfirmPassword').value = '" + newPassWord + "'";
            ((IJavaScriptExecutor)browser).ExecuteScript(encryptedPassword);

            //IWebElement element = browser.FindElement(By.CssSelector("img[alt='Save']"));
            IWebElement changeButton = browser.FindElement(By.XPath("//input[@src ='/portal/Content/Images/change.gif']"));

            Libary.HighLight(browser, changeButton);
            changeButton.Click();

            //Switch to the Conformation Dialog
            IWebElement closeButton = browser.FindElement(By.XPath("//span[contains(.,'Close')]"));
            Libary.HighLight(browser, closeButton);

            closeButton.Click();

        }


    } //end public partial class SafePage

} //end namespace AcceptanceTests.PageObjects

