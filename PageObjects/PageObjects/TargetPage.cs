using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.PageObjects
{
    public class TargetPage
    {
        IWebElement Message => driver.FindElement(By.Id("message"));

        IWebDriver driver;

        public TargetPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetMessage()
        {
            return Message.Text;    
        }
    }
}
