using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestsAllureReports.Common;

namespace TestsAllureReports.Tests;

//
// Summary:
//      Sample Selenium tests: positive and negative scenarios
// Run:
//      dotnet test .\bin\Debug\net8.0\TestsAllureReports.dll
// Open report
//      allure serve <path>\allure-results
[AllureNUnit]
internal class AllureReportTests : TestBase
{
    [Test]
    [AllureDescription("Write text and submit form")]
    [AllureIssue("Issue-1")]
    [AllureTms("TMS-1")]
    public void AllureReportTest()
    {
        AllureReport?.LogStep("submit form test");

        var text = Guid.NewGuid().ToString();
        var expectedMessage = "Received!";

        var message =
             WebForm?
             .WriteTextToTextArea(text)
             .SubmitForm()
             .GetMessage();

        Assert.That(message, Is.EqualTo(expectedMessage));
    }

    [Test]
    [AllureDescription("Write text and submit form - negative test")]
    [AllureIssue("Issue-2")]
    [AllureTms("TMS-2")]
    public void AllureReportNegativeTest()
    {
        AllureReport?.LogStep("submit form test - negative test");

        var text = Guid.NewGuid().ToString();
        var expectedMessage = "Received! - expect to fail";

        var message =
             WebForm?
             .WriteTextToTextArea(text)
             .SubmitForm()
             .GetMessage();

        Assert.That(message, Is.EqualTo(expectedMessage));
    }
}