using NUnit.Framework;
using RelevantCodes.ExtentReports;
using RestSharp;
using AutomationFramework.Lib;

namespace AutomationFramework
{
    /// <summary>
    ///   class used by api test cases
    /// </summary>
    [TestFixture]
    public class WebSiteAPI : Base
    {
        // class level variables
        private ExtentTest extentReportsTest;

        /// <summary>
        ///   necessary setup be for test execution
        /// </summary>
        [SetUp]
        public void BeforeTest()
        {
            extentReportsTest = extentReports.StartTest(TestContext.CurrentContext.Test.Name);
        }

        /// <name>
        ///     Test Case: WebSiteAPIGetBackendStatus
        /// </name>
        /// <summary>
        ///     Summary: To verify backend service responds with an status code 200/OK
        ///         when performing a Get.
        /// </summary>
        /// <testid>
        ///     MRN-303: link to test case id here
        /// </testid>
        /// <bug>
        ///     JIRA-5004: An Error is displayed when attempting API Get
        /// </bug>
        /// <note>
        ///     Note: Throws an Assert if the returned status codes does not equal OK
        /// </note>
        [Test]
        [Category("Regression"), Category("WebSiteAPI")]
        public void WebSiteAPIGetBackendStatus()
        {
            // assigning categories for reports
            extentReportsTest.AssignCategory("Regression", "WebSiteAPI");

            // test case variables
            string apiUrl = "https://httpbin.org/get";
            var client = new RestClient(apiUrl);

            // logging step for get command
            extentReportsTest.Log(LogStatus.Info, "MRN-303: API Get", "API Get to obtain Status");
            
            // executed an API get to the specified URL can getting status code
            RestResponse response = client.Get(new RestRequest());
            System.Net.HttpStatusCode statusCode = response.StatusCode;

            // logging step for get command
            extentReportsTest.Log(LogStatus.Info, "MRN-303: API Status Code", "API Status Recieved");
            
            // verifying status code is 200 (OK = the request was received )
            StringAssert.AreEqualIgnoringCase("OK", statusCode.ToString());
        }

        /// <summary>
        ///   This case is checking the error handling method.
        /// </summary>
        [Test]
        [Category("Regression"), Category("WebSiteAPI")]
        public void WebSiteAPIPostDataBackendService()
        {
            // assigning categories for reports
            extentReportsTest.AssignCategory("Regression", "WebSiteAPI");

            // test case variables
            string apiUrl = "https://reqres.in/api/users/2";
            var client = new RestClient(apiUrl);

            // logging step for get command
            extentReportsTest.Log(LogStatus.Info, "MRN-304: API Post", "API POST to obtain Status");
            
            // executed an API get to the specified URL can getting status code
            RestResponse response = client.Post(new RestRequest());
            System.Net.HttpStatusCode statusCode = response.StatusCode;

            // logging step for get command
            extentReportsTest.Log(LogStatus.Info, "MRN-304: API Status Code", "API Status Recieved");

            // verifying status code is 200 (OK = the request was received )
            StringAssert.AreEqualIgnoringCase("OK", statusCode.ToString());
            //StringAssert.AreEqualIgnoringCase("Created", statusCode.ToString());
        }

        /// <summary>
        ///   test down used to generate report results
        /// </summary>
        [TearDown]
        public void AfterTest()
        {
            // writing the test case results for the report
            Common.generateReportResults(extentReportsTest);

            //flush() - to write or update test information to your report. 
            extentReports.Flush();
        }
    }
}
