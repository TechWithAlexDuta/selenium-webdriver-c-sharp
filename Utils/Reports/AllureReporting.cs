using NUnit.Allure.Attributes;

namespace Utils.Reports
{
    public class AllureReporting
    {
        [AllureStep("{0}")]
        public void LogStep(string message)
        {
        }
    }
}
