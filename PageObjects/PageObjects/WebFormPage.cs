using OpenQA.Selenium;

namespace PageObjects.PageObjects
{
    public class WebFormPage
    {
        #region locators
        IWebElement TextArea => driver.FindElement(By.Name("my-textarea"));
        IWebElement SubmitBtn => driver.FindElement(By.TagName("button"));
        #endregion locators

        IWebDriver driver;

        public WebFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region methods
        public WebFormPage WriteTextToTextArea(string text)
        {
            TextArea.SendKeys(text);

            return this;
        }

        public TargetPage SubmitForm()
        {
            SubmitBtn.Click();

            return new TargetPage(driver);
        }
        #endregion methods
    }
}
