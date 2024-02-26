using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestsExtentReportsParallelExecution.Common;

//
// Summary:
//      Factory class for WebDriver
internal class WebDriverFactory
{

    private static ThreadLocal<IWebDriver?> webDriverThreadLocal = new ThreadLocal<IWebDriver?>();
    private static readonly object myLock = new object();

    public static IWebDriver GetDriver()
    {
        lock (myLock)
        {
            IWebDriver? driver = webDriverThreadLocal.Value;

            if (driver == null)
            {
                driver = new ChromeDriver();

                webDriverThreadLocal.Value = driver;
            }
            return driver;
        }
    }

    public static void QuitDriver()
    {
        lock (myLock)
        {
            IWebDriver? driver = webDriverThreadLocal.Value;

            if (driver != null)
            {
                driver.Quit();
                webDriverThreadLocal.Value = null;
            }
        }
    }
}