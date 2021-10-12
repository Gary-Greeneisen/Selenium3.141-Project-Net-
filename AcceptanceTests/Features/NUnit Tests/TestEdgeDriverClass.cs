using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//add Selenium files
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
//using OpenQA.Selenium.Edge;
using Microsoft.Edge.SeleniumTools;
using NUnit.Framework;
using AcceptanceTests.Common.Library;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.Features.NUnit_Tests
{
    class TestEdgeDriverClass
    {
        [Test]
        public void TestEdgeDriver()
        {

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

            //********************************************************************************************
            //Member name Value Description
            //Default     0       Indicates the behavior is not set.
            //Normal      1       Waits for pages to load and ready state to be 'complete'.
            //Eager       2       Waits for pages to load and for ready state to be 'interactive' or 'complete'.
            //None        3       Does not wait for pages to load, returning immediately.
            //********************************************************************************************

            var options = new EdgeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.UseChromium = true;
            //options.BinaryLocation = driverDir;

            //location of Edge driver
            //IWebDriver browser = new EdgeDriver(driverDir);  
            IWebDriver browser = new EdgeDriver(driverDir,options);
            //IWebDriver browser = new EdgeDriver(options);
                            
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));

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

            //Test if main page displayed
            element = browser.FindElement(By.Id("main"));


            browser.Close();

        }

    }


}
