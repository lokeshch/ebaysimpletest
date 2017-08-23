using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Data.OleDb;

namespace SpecFlowFramework
{
    [Binding]
    public class GoogleHook
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        ReadExcel re = new ReadExcel();
        OleDbDataReader result;
        [BeforeScenario]
        public void BeforeScenario()
        {
            result = re.RunReadQuery("select * from [Sheet1$] where Scenario='"+ScenarioContext.Current.ScenarioInfo.Title+"'");
            result.Read();

            for (int colNo = 1; colNo < result.FieldCount; colNo++)
            {
                string[] split = result.GetString(colNo).Split('=');
                ScenarioContext.Current[split[0]] = split[1];
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
