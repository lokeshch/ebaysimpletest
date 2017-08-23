using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ExtentManager
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        private static ExtentHtmlReporter htmlReporter;
        private static string path = ConfigurationManager.AppSettings["path"];
        private static String filePath = path;


        public static ExtentReports GetExtent()
        {
            if (extent != null)
                return extent; //avoid creating new instance of html file
            extent = new ExtentReports();
            extent.AttachReporter(getHtmlReporter());
            return extent;
        }

        private static ExtentHtmlReporter getHtmlReporter()
        {
            
           
            
            htmlReporter = new ExtentHtmlReporter(filePath);
            string path = ConfigurationManager.AppSettings["EtentConfig"];
            htmlReporter.LoadConfig(path);
            // make the charts visible on report open
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().DocumentTitle = "com.amaz - QAV automation report";
            htmlReporter.Configuration().ReportName = "Regression cycle_1.1";
            return htmlReporter;
        }

        public static ExtentTest createTest(String name, String description)
        {
            test = extent.CreateTest(name, description);
            return test;
        }
    }
}

