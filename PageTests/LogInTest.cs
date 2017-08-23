using NUnit.Framework;
using ConsoleApp1.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System;
using AventStack.ExtentReports;

namespace ConsoleApp1
{
   
    class LogInTest
    {

        private IWebDriver driver;
        ExtentReports extent;
        ExtentTest test;


        [TestFixtureSetUp]

        public void init()
        {
            extent = ExtentManager.GetExtent();
            driver =Browsers.Init();
            driver.Url = ConfigurationManager.AppSettings["URL"];
           
        }
         [Test]
         public void InValidInput1()
         {

            /*
               exceldata ex = new exceldata();
               ex.PopulateInCollection(@"C:\Users\Srini\source\repos\ConsoleApp1\ConsoleApp1\TestDataAccess\TestData.xlsx");
               string user1 = ex.ReadData(1,"Username");
               string Pass1 = ex.ReadData(1,"Password");*/
            try
            {
                driver.Url = ConfigurationManager.AppSettings["URL"];
            test = extent.CreateTest("QAVsite", "Verify HomePage");
                if (driver.Title.Contains("QA manual"))
                {
                   
                    test.Pass(driver.Title + " contain " + "QA manual");
 
                }
                else
                    //test.log(LogStatus.FAIL, driver.getTitle() +" doesn't contain "+"QA & Validation" );//earlier version
                    test.Log(Status.Fail, driver.Title + " doesn't contain " + "QA manual");
            }
            catch (Exception e) { test.Log(Status.Error, e.Message); }
        
        string user2 = ConfigurationManager.AppSettings["user1"];
            string Pass2 = ConfigurationManager.AppSettings["pass1"];
            var homePage = new HomePage(driver);
            homePage.ClickOnMyAccount();

            var loginPage = new LoginPage(driver);
            loginPage.LoginToApplication(user2, Pass2);
            loginPage.Cleartext();
            string result = loginPage.geterror();
            Assert.AreEqual(result, "Oops, that's not a match.");
            
        }
       [Test]
        public void InValidInput2()
        {
            string user2 = ConfigurationManager.AppSettings["user2"];
            string Pass2 = ConfigurationManager.AppSettings["pass2"];

            var loginPage = new LoginPage(driver);
            loginPage.LoginToApplication(user2, Pass2);
            loginPage.Cleartext();
            string result = loginPage.geterror();
            Assert.AreEqual(result, "Oops, that's not a match.");

        }
        [Test]
        public void InValidInput3()
        {
            string user2 = ConfigurationManager.AppSettings["user3"];
            string Pass2 = ConfigurationManager.AppSettings["pass3"];

            var loginPage = new LoginPage(driver);
            loginPage.LoginToApplication(user2, Pass2);
            loginPage.Cleartext();
            string result = loginPage.geterror();
            Assert.AreEqual(result, "Oops, that's not a match.");
            driver.Navigate().Back();
            loginPage.Cleartext();


        }

        [Test]
        public void ValidInputTest1()
        {
            
            string user1 = ConfigurationManager.AppSettings["user"];
            string Pass1 = ConfigurationManager.AppSettings["pass"];
            var loginPage = new LoginPage(driver);
            loginPage.LoginToApplication(user1, Pass1);
            loginPage.LoginTobycapchaenter();
            string result = loginPage.geTitle();
            Console.WriteLine(result);
            Assert.AreEqual(result, "Electronics, Cars, Fashion, Collectibles, Coupons and More | eBay");
        }
        [TestFixtureTearDown]
        public void tear()
        {
            extent.Flush();
            driver.Quit();
        }

    }
}
