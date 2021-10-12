using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//add Selenium files
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using AcceptanceTests.Common.Library;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.Features.NUnit_Tests
{
    class TestFireFoxDriverClass
    {
        [Test]
        public void TestFireFoxDriver()
        {
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
            //var driverDir = @"C:\Test\Selenium3.141-Framework(Net)\packages\";

            var runDir = Libary.GetProjectDir();
            var driverDir = runDir + @"\packages\";

            // location of the geck0driver.exe file
            var driverService = FirefoxDriverService.CreateDefaultService(driverDir);

            //location of installed firefox.exe
            driverService.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driverService.HideCommandPromptWindow = true;
            driverService.SuppressInitialDiagnosticInformation = true;
            IWebDriver browser = new FirefoxDriver(driverService, new FirefoxOptions(), TimeSpan.FromSeconds(60));

            browser.Url = "http://www.google.com";

            //Find the Search text box UI Element
            IWebElement element = browser.FindElement(By.Name("q"));

            //Search
            element.SendKeys("books");

            // this sends an Enter to the element
            element.SendKeys(Keys.Enter);


            //Wait for page to load
            //System.Threading.Thread.Sleep(5 * 1000); //Wait 5-sec
            new WebDriverWait(browser, TimeSpan.FromSeconds(5)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            //******************************************************************************
            //For what ever reason the document.readyState = "complete"
            //and yet the next statement element = browser.FindElement(By.Id("main"));
            //throws an exception, because the Id = main is not displayed
            //Lets wait using page element is displayed using driver.FindElement
            //******************************************************************************

            //Example wait for page element is displayed using driver.FindElement
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.FindElement(By.Id("main")));

            //Test if main page displayed
            element = browser.FindElement(By.Id("main"));

            browser.Close();

        }
    }

}
