using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using AcceptanceTests.Common.Application;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Config;
using AcceptanceTests.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace AcceptanceTests.PageObjects
{
    public partial class CreditHoursTab
    {

        public void WaitForCreditHoursTable(int repeat_time)
        {

            var controlWaitTime = repeat_time;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Determine Table #Rows and #Columns
                    IWebElement table = browser.FindElement(By.Id("tblCourseEnrlList"));

                    //Xpath for row(1) col(1) 1-based
                    //*[@id="tblCourseEnrlList"]/thead/tr/th[1]
                    		 
                    //Xpath for row(1) col(5)	1-based
                    //*[@id="tblCourseEnrlList"]/thead/tr/th[5]

                    //Read #Rows and #Columns
                    ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
                    ReadOnlyCollection<IWebElement> tableColumns = table.FindElements(By.TagName("th"));

                    //Determine #Rows and #Columns  0-based
                    var rowCount = tableRows.Count;
                    rowCount--;
                    var colCount = tableColumns.Count;

                    if( (rowCount < 0) || (colCount != 5) )
                    {
                        throw new Exception("Credit Hours Table #Rows Should Be Greater Than 0" +
                                            "And #Columns Should Be Equal To 5");
                                            
                    }

                    break;

                }
                catch
                {
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }
            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Credit Hours Table Not Displayed");
            }

            Libary.WaitForPageLoad(RunTimeVars.PAGELOADWAIT);

        }


    } //end public partial class CreditHoursTab





} //end namespace AcceptanceTests.PageObjects
