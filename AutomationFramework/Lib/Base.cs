using RelevantCodes.ExtentReports;
using System;
using OpenQA.Selenium;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework.Lib
{
    public class Base
    {
        // base class variables
        public static string projectPath = null;
        public static ExtentReports extentReports = null;
        public static IWebDriver webDriver = null;
        public static string url = "http://www.aspencapital.com";
        public static string dateTime = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);

        // base class constructor to intialize the project path and extent reports
        public Base()
        {
            // obtaining the current solution path/project path
            if (projectPath == null)
            {
                Uri uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
                string dllDir = Path.GetDirectoryName(uri.LocalPath);
                projectPath = dllDir.Remove(dllDir.Length - 9);
            }

            // initializing the extent reports object if not initialized
            if (extentReports == null)
            {
                // appending the html report file to current project path
                string reportPath = projectPath + "Reports\\ACARSReport_" +
                    Base.dateTime + ".html";

                // boolean value for replacing existing report
                extentReports = new ExtentReports(reportPath, true);

                // add QA system info to html report
                extentReports
                    .AddSystemInfo("Environment", "QA2")
                    .AddSystemInfo("Username", "QA Automated User");

                // loading the extentReports reports config.xml file from the project
                extentReports.LoadConfig(projectPath + "Extent-Config.xml");
            }
        }


        /// <name>
        ///     Method Name: getSeleniumDriver()
        /// </name>
        /// <summary>
        ///     Summary: Initializes the Selenium WebDriver if not initialized
        /// </summary>
        /// <parameters>
        ///   <para1>
        ///       url: The URL address of the specified page
        ///   </para1>
        /// </parameters>
        /// <returns>
        ///     IWebDriver webDriver: webDriver object to be used for Selenium tests
        /// </returns>
        public static IWebDriver getSeleniumDriver()
        {
            // only initializing the driver if not already initialized
            if (webDriver == null)
            {
                try
                {
                    webDriver = new ChromeDriver(Base.projectPath + "\\Drivers");
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
                    webDriver.Manage().Window.Maximize();
                    webDriver.Navigate().GoToUrl(Base.url);
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("Exception: {0}", ex.Message);
                }
            }
            return webDriver;
        }
    }
}


