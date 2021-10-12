using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Interface;
using OpenQA.Selenium;

namespace AcceptanceTests.PageObjects
{
    public partial class CommentsHistoryTab
    {


        public void AssertCommentsHistoryTabDisplay(int retrys)
        {
            var controlWaitTime = retrys;
            IWebDriver browser = TestRunnerInterface.Map.safePage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    //Assert Page Status
                    IWebElement element = browser.FindElement(By.Id("tab-0"));

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
                throw new Exception("Comments/History Tab Is Not Displayed");
            }

        }



    }

}
