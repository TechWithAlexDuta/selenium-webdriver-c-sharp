using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Reports
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        /// <summary>
        /// Create ExtentReporting and attach ExtentHtmlReporter
        /// </summary>
        /// <returns></returns>
        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";

            if(extentReports == null)
            {
                Directory.CreateDirectory(path);

                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);

                extentReports.AttachReporter(htmlReporter);
            }

            return extentReports;
        }

        /// <summary>
        /// Create a new Test in reporter
        /// </summary>
        /// <param name="testName"></param>
        public static void CreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);
        }

        /// <summary>
        /// update/flush the info to reporter
        /// </summary>
        public static void EndReporting()
        {
            StartReporting().Flush();   
        }

        /// <summary>
        /// Log info message in report
        /// </summary>
        /// <param name="info"></param>
        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }

        /// <summary>
        /// Log pass message in report
        /// </summary>
        /// <param name="info"></param>
        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        /// <summary>
        /// Log fail message in report
        /// </summary>
        /// <param name="info"></param>
        public static void LogFail(string info)
        {
            extentTest.Fail(info);  
        }

        /// <summary>
        /// Log screnshot in report
        /// </summary>
        /// <param name="info"></param>
        /// <param name="image"></param>
        public static void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());   
        }
    }
}
