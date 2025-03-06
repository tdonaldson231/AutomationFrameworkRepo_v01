//using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using AutomationFramework.Lib;
using AutomationFramework.PageObjects.Website;

namespace AutomationFramework
{
    /// <summary>
    ///   class for UI test cases currently using selenium
    /// </summary>
    [TestFixture]
    public class WebSiteUI : Base
    {
        // class level variables
        private ExtentTest extentReportsTest;
        private HomePage homePage;
        private AboutPage aboutPage;

        /// <summary>
        ///   basic setup for selenium webdriver
        /// </summary>
        [OneTimeSetUpAttribute]
        public void BeforeClass()
        {
            // Navigate to home page
            webDriver = Base.getSeleniumDriver();
        }

        /// <summary>
        ///   setting up html reports for ui test case results
        /// </summary>
        [SetUp]
        public void BeforeTest()
        {
            extentReportsTest = extentReports.StartTest(TestContext.CurrentContext.Test.Name);
            homePage = new HomePage(webDriver, extentReportsTest,
                TestContext.CurrentContext.Test.Name);
            aboutPage = new AboutPage(webDriver, extentReportsTest, 
                TestContext.CurrentContext.Test.Name);
        }

        /// <name>
        ///     Test Case: WebSiteUISearchTextFromAboutPage
        /// </name>
        /// <summary>
        ///     Summary: To verify the user get directed to the About Us page when clicking
        ///              on the About Us link from the Home Page.
        /// </summary>
        /// <testid>
        ///     MRN-305: link to test case id here
        /// </testid>
        /// <bug>
        ///     JIRA-5038: An Error is displayed when attempting to access About Us
        /// </bug>
        /// <note>
        ///     Note: Throws an Assert if the user is not directed to the About Us page
        /// </note>
        [Test, Category("Regression"), Category("WebSiteUI")]
        public void WebSiteUISearchTextFromAboutPage()
        {
            // assigning categories for reports
            extentReportsTest.AssignCategory("Regression", "WebSiteUI");

            // going to the web page home page then clicking on the About Us link
            homePage.ClickAboutPageLink();
            // logging step if successful
            extentReportsTest.Log(LogStatus.Info,
                "MRN-305: Step 1", "Clicked on About Us link");

            // checking if the page header is present
            string expectedPageLabel = "We elevate the way the world";
            Assert.IsTrue(aboutPage.ValidatePageHeader(expectedPageLabel));
            extentReportsTest.Log(LogStatus.Info,
                "MRN-305: Step 2", "Verify user is directed to About Us page");
        }

        /// <summary>
        ///   generating report results for ui test cases
        /// </summary>
        [TearDown]
        public void AfterTest()
        {
            //Close the browser
            webDriver.Close();

            // writing the test case results for the report
            Common.generateReportResults(extentReportsTest);

            //flush() - to write or update test information to your report. 
            extentReports.Flush();
        }

        /// <summary>
        ///   ending webdriver session after test is completed
        /// </summary>
        [OneTimeTearDown]
        public void AfterClass()
        {
            webDriver.Quit();
        }
    }
}
