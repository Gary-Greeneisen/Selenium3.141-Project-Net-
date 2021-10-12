using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add Selenium files
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AcceptanceTests.Features.NUnit_Tests;
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Library;


namespace AcceptanceTests.Features.NUnit_Tests
{
    class NUnitTest
    {

        [SetUp]
        public void Initialize()
        {

        }

        [Test]
        public void TestDrivers()
        {
            TestChromeDriverClass TestChrome = new TestChromeDriverClass();
            TestChrome.TestChromeDriver();

            TestFireFoxDriverClass TestFireFox = new TestFireFoxDriverClass();
            TestFireFox.TestFireFoxDriver();

            TestEdgeDriverClass TestEdge = new TestEdgeDriverClass();
            TestEdge.TestEdgeDriver();

            //TestIEDriverClass TestIE = new TestIEDriverClass();
            //TestIE.TestIEDriver();

        }

        [Test]
        public void UnitTest2()
        {

        }


        [TearDown]
        public void EndTest()
        {
     
        }

    }


}
