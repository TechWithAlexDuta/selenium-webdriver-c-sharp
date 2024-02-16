using NUnit.Allure.Attributes;

namespace Utils.Reports.Allure
{
    public class AllureReporting : IAllureReporting
    {
        [AllureStep("{0}")]
        public void LogStep(string message)
        {
        }
    }
}
