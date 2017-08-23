using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ConsoleApp1.TestDataAccess;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Email or username' and @type='text' ]")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[starts-with(@class, 'fld') and @Placeholder='Password']")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "sgnBt")]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.Id, Using = "errf")]
        public IWebElement errrr { get; set; }
        [FindsBy(How = How.XPath, Using = "//title")]
        public IWebElement txt { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginToApplication(string Username, String password)
        {

            UserName.SendKeys(Username);
            Password.SendKeys(password);
            Submit.Click();
        }
        public String geTitle()
        {
            String title = driver.Title;
            return title;
        }
        public String geterror()
        {
            String err = errrr.Text;
            return err;
        }
        public void Cleartext()
        {
            UserName.Clear();
        }
        public void LoginTobycapchaenter()
        { 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.alert('pls enter capcha and password test1234 then  click on submit to continue')");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.TextToBePresentInElement(txt,"Electronics, Cars, Fashion, Collectibles, Coupons and More | eBay"));
        }
    }
}
