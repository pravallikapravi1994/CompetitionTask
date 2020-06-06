using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

using System;
using static MarsFramework.Global.GlobalDefinitions;
using System.Text;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenShotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLPath = MarsResource.ReportXMLPath;
        public static string Credpath = MarsResource.Credentialspath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion


        [OneTimeSetUp]
        public void Setup()
        {
            #region Initialise Reports
            extent = new ExtentReports();




            var htmlReporter = new ExtentHtmlReporter(ReportPath);
            extent.AttachReporter(htmlReporter);
            //using report design
            htmlReporter.LoadConfig(ReportXMLPath);
            //Adding system details
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", "Pravallika");
            #endregion
        }

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            GlobalDefinitions.driver = new ChromeDriver();

            TurnOnWait();
            GlobalDefinitions.driver.Manage().Window.Maximize();
            TurnOnWait();
            GlobalDefinitions.driver.Navigate().GoToUrl(Baseurl);

           // SignIn signin = new SignIn();
            //signin.LoginSteps();
        


            if (MarsResource.IsLogin == "true")
           {
                SignIn loginobj = new SignIn();
               loginobj.LoginSteps();
            }
            else
            {
               SignUp obj = new SignUp();
                obj.register();
            }

        }


        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    //Getting failed test screenshot for report
                    String screenShotPath = Capture(driver, ReportPath);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(ScreenShotPath));
                    MediaEntityBuilder.CreateScreenCaptureFromPath(ReportPath);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    DateTime time1 = DateTime.Now;
                    //Getting pass test screenshot
                    String screenShotPath1 = Capture(driver, ReportPath);
                    test.Log(Status.Pass, "Pass");
                    test.Log(Status.Pass, "Snapshot below: " + test.AddScreenCaptureFromPath(ScreenShotPath));
                    MediaEntityBuilder.CreateScreenCaptureFromPath(ReportPath);
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            driver.Quit();
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }
        public static string Capture(IWebDriver driver, String fileName)
        {



            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            //Screenshot saving location
            screenshot.SaveAsFile(ScreenShotPath, ScreenshotImageFormat.Png);
            return ReportPath;
        }
        #endregion

        [OneTimeTearDown]
        public void Teardown()
        {
            extent.Flush();
            driver.Quit();
        }


        public void AddShareSkill()
        {
            ShareSkill s = new ShareSkill();
            s.EnterShareSkill();

        }
    }
}