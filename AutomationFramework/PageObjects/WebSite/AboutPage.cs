using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using AutomationFramework.Lib;

namespace AutomationFramework.PageObjects.Website
{
    class AboutPage : Base
    {
        // class level variables
        public ExtentTest extentReportsTest;

        public AboutPage(IWebDriver webDriver, ExtentTest extentReportsTest, 
            string testCaseName)
        {
            PageFactory.InitElements(webDriver, this);
            this.extentReportsTest = extentReportsTest;
        }
     
        [FindsBy(How = How.Id, Using = "header")]
        public IWebElement AboutPageLabel { get; set; }
        public bool ValidatePageHeader(string expectedHeader)
        {
            try
            {
                Assert.IsTrue(this.AboutPageLabel.Text.Contains(expectedHeader),
                "The Web Page does not contains the specified label");
            }
            catch (Exception ex)
            {
                extentReportsTest.Log(LogStatus.Error, 
                    extentReportsTest.AddScreenCapture(Common.getScreenCapture(
                            projectPath, "ValidatePageHeader")), 
                    "Exception: " + ex.Message);
                return false;
            }
            return true;
        }

        [TearDown]
        public void AfterTest()
        {
            extentReports.EndTest(extentReportsTest);
        }

    }
}

