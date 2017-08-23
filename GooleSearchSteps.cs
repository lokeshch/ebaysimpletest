using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SpecFlowFramework
{
    [Binding]
    public class GooleSearchSteps
    {
        FirefoxDriver f;
        [Given(@"I have google website open")]
        public void GivenIHaveGoogleWebsiteOpen()
        {
            f = new FirefoxDriver();
            f.Navigate().GoToUrl("http://www.google.com");
        }
        
        [Given(@"I have entered ""(.*)"" to search")]
        public void GivenIHaveEnteredToSearch(string p0)
        {
            string text = ScenarioContext.Current["text"].ToString();
            f.FindElementById("gbqfq").SendKeys(text);
        }
        
        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            f.FindElementById("gbqfb").Click();
        }
        
        [Then(@"the result page sould be on the screen")]
        public void ThenTheResultPageSouldBeOnTheScreen()
        {
            f.Navigate().Refresh();
            Assert.AreEqual(ScenarioContext.Current["text"].ToString() + " - Google Search", f.Title);
        }
    }
}
