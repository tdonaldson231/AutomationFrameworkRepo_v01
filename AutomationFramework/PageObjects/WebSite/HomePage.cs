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
       
        [FindsBy(How = How.CssSelector, Using = "#nav > li.about-us > a")]
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

