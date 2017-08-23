using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class Browsers
    {
        private static IWebDriver webDriver;
        public static ReportsManager reports; // adding the report vaiable
        //private static string baseURL = ConfigurationManager.AppSettings["URL"];
        private static string browser = ConfigurationManager.AppSettings["browser"];
        public static IWebDriver Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    FirefoxDriverService ser = FirefoxDriverService.CreateDefaultService(@"c:\users\srini\source\repos\com.webTest\com.webTest\browser");
                    ser.FirefoxBinaryPath = @"C:\Program Files(x86)\Mozilla Firefox\firefox.exe";
                    webDriver = new FirefoxDriver(ser);
                    
                    break;
            }
            //webDriver.Manage().Window.Maximize();


            //bDriver.Url = ConfigurationManager.AppSettings["URL"];
            //webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(45));
            //reports = new ReportsManager(browser, baseURL);  // Creating New Instance of report
            //Goto(baseURL);
            return webDriver;
        }
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static IWebDriver getDriver
        {
            get { return webDriver; }
        }
        public static void Goto(string url)
        {
            webDriver.Url = url;
            reports.verifyURL(url); // Verifying the URL
        }
        public static void Close()
        {
            webDriver.Quit();
        }
    }
}
