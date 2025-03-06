using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.IO;

namespace AutomationFramework.Lib
{
    /// <summary>
    ///   common used by all test cases
    /// </summary>
    public class Common : Base
    {
        /// <name>
        ///     Method Name: getScreenCapture()
        /// </name>
        /// <summary>
        ///     Summary: Takes a screen capture of the currect page using the selenium 
        ///         screen capture method when accessed to be used for the reports
        /// </summary>
        /// <parameters>
        ///   <para1>
        ///       string projectPath: The project page for the screen capture location
        ///   </para1>
        ///   <para2>
        ///       string screenCaptureName: The name to be used for the screen capture
        ///   </para2>
        /// </parameters>
        /// <returns>
        ///     string screenCapture: the path and name of the screen capture to be used
        ///         for the extent reports
        /// </returns>
        public static string getScreenCapture(string projectPath, 
            string screenCaptureName)
        {
            // screen capture name and location
            string screenCapture = null;
            string screenCaptureDir = projectPath + "\\ScreenCaptures\\";
            IWebDriver webDriver = Base.webDriver;

            // using the selenium screen capture method to take a screen capture when called
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)webDriver;
                Screenshot screenshot = ts.GetScreenshot();
                // create the screen capture directory if it does not exist
                if (!Directory.Exists(screenCaptureDir))
                    Directory.CreateDirectory(screenCaptureDir);
                screenCapture = screenCaptureDir + screenCaptureName + ".jpeg";
                screenshot.SaveAsFile(screenCapture, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Exception: {0}", ex.Message);
            }
            return screenCapture;
        }

        /// <name>
        ///     Method Name: generateReportResults()
        /// </name>
        /// <summary>
        ///     Summary: A method to generated the extent report results based on the
        ///          test case results 
        /// </summary>
        /// <parameters>
        ///   <para1>
        ///       ExtentTest extentReportsTest: The ExtentTest object necessary for 
        ///           logging the results to the specified test case
        ///   </para1>
        /// </parameters>
        /// <returns>
        /// </returns>
        /// <note>
        ///     Note: This method was developed to be used after every test case
        ///         has been executed and to be called from the tearDown method
        /// </note>
        public static void generateReportResults(ExtentTest extentReportsTest)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;

            }
            extentReports.EndTest(extentReportsTest);
            extentReportsTest.Log(logstatus, "Test Case Results: {0}" +
                stacktrace, stacktrace);
        }
    }
}
