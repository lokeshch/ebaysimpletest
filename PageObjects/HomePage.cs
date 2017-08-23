using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ConsoleApp1.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='gh-ug']/a[contains(text(),'Sign in')]")]
        public IWebElement MyAccount { get; set; }
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void ClickOnMyAccount()
        {
            MyAccount.Click();
        }
    }
}

