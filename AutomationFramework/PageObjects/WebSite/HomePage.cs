using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;

namespace AutomationFramework.PageObjects.Website
{
    class HomePage : Lib.Base
    {
        // class level variables
        ExtentTest extentReportsTest;

        public HomePage(IWebDriver webDriver, ExtentTest extentReportsTest,
            string testCaseName)
        {
            PageFactory.InitElements(webDriver, this);
            this.extentReportsTest = extentReportsTest;
        }

        //[FindsBy(How = How.Id, Using = "comp-ihjax7ir3label")]
        //[FindsBy(How = How.XPath, Using = "//span[@class='MV3Tnb' and text()='About']")]
        [FindsBy(How = How.XPath, Using = "//a[text()='About']")]
        public IWebElement AboutPageLink { get; set; }

        public void ClickAboutPageLink()
        {
            try
            {
                AboutPageLink.Click();
            }
            catch (Exception ex)
            {
                extentReportsTest.Log(LogStatus.Error, "Exception: {0}", Details: ex.Message);
                extentReportsTest.AddScreenCapture(projectPath);
            }
        }

        [TearDown]
        public void AfterTest()
        {
            extentReports.EndTest(extentReportsTest);
        }
    }
}

