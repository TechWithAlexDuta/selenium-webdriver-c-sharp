using NUnit.Allure.Attributes;

namespace Utils.Reports.Allure;
//
// Summary:
//      Allure reporting
public class AllureReporting : IAllureReporting
{
    [AllureStep("{0}")]
    public void LogStep(string message)
    {
    }
}