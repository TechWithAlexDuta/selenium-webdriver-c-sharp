using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace Utils.Reports.Extent;
//
// Summary:
//      Extent reports singleton + parallel reporting
public sealed class ExtentParallelReporting
{
    private static ExtentParallelReporting? instance = null;
    private static readonly object myLock = new object();
    private static readonly Dictionary<int, ExtentTest> extentMap = new Dictionary<int, ExtentTest>();

    private ExtentReports? extentReports;
    private ExtentTest? extentTest;

    private ExtentParallelReporting() { }

    public static ExtentParallelReporting Instance
    {
        get
        {
            lock (myLock)
            {
                if (instance == null)
                {
                    instance = new ExtentParallelReporting();
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
        lock (myLock)
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
    }

    /// <summary>
    /// Create a new Test in reporter
    /// </summary>
    /// <param name="testName"></param>
    public void CreateTest(string testName)
    {
        lock (myLock)
        {
            extentTest = StartReporting().CreateTest(testName);
            extentMap.Add(Environment.CurrentManagedThreadId, extentTest);
        }
    }

    private ExtentTest GetExtentTest()
    {
        lock (myLock)
        {
            return extentMap[Environment.CurrentManagedThreadId];
        }
    }

    /// <summary>
    /// update/flush the info to reporter
    /// </summary>
    public void EndReporting()
    {
        lock (myLock)
        {
            StartReporting().Flush();
            extentMap.Remove(Environment.CurrentManagedThreadId);
        }
    }

    /// <summary>
    /// Log info message in report
    /// </summary>
    /// <param name="info"></param>
    public void LogInfo(string info)
    {
        lock (myLock)
        {
            GetExtentTest().Info(info);
        }
    }

    /// <summary>
    /// Log pass message in report
    /// </summary>
    /// <param name="info"></param>
    public void LogPass(string info)
    {
        lock (myLock)
        {
            GetExtentTest().Pass(info);
        }
    }

    /// <summary>
    /// Log fail message in report
    /// </summary>
    /// <param name="info"></param>
    public void LogFail(string info)
    {
        lock (myLock)
        {
            GetExtentTest().Fail(info);
        }
    }

    /// <summary>
    /// Log screenshot in report
    /// </summary>
    /// <param name="info"></param>
    /// <param name="image"></param>
    public void LogScreenshot(string info, string? image)
    {
        lock (myLock)
        {
            if (string.IsNullOrEmpty(image))
            {
                extentTest?.Info("No screenshot available.");
                return;
            }

            GetExtentTest().Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}