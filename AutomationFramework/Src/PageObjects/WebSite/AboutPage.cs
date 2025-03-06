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

        //[FindsBy(How = How.XPath, Using = "//span[@class='wixui-rich-text__text' and text()='CONTACT']")]
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'We elevate the way the world')]")]
        public IWebElement PageHeaderLabel { get; set; }

        public bool ValidatePageHeader(string expectedHeader)
        {
            try
            {
                Assert.IsTrue(this.PageHeaderLabel.Text.Contains(expectedHeader),
                "The Web Page does not contain the specified label");
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

