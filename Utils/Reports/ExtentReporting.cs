using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace Utils.Reports
{
    public sealed class ExtentReporting
    {
        private static ExtentReporting? instance = null;
        private static readonly object myLock = new object();

        private ExtentReports extentReports;
        private ExtentTest extentTest;

        private ExtentReporting() { }

        public static ExtentReporting Instance
        {
            get
            {
                lock (myLock)
                {
                    if (instance == null)
                    {
                        instance = new ExtentReporting();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Create ExtentReporting and attach ExtentHtmlReporter
        /// </summary>
        /// <returns></returns>
        private ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";

            if (extentReports == null)
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
        public void CreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);
        }

        /// <summary>
        /// update/flush the info to reporter
        /// </summary>
        public void EndReporting()
        {
            StartReporting().Flush();
        }

        /// <summary>
        /// Log info message in report
        /// </summary>
        /// <param name="info"></param>
        public void LogInfo(string info)
        {
            extentTest.Info(info);
        }

        /// <summary>
        /// Log pass message in report
        /// </summary>
        /// <param name="info"></param>
        public void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        /// <summary>
        /// Log fail message in report
        /// </summary>
        /// <param name="info"></param>
        public void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        /// <summary>
        /// Log screnshot in report
        /// </summary>
        /// <param name="info"></param>
        /// <param name="image"></param>
        public void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}
