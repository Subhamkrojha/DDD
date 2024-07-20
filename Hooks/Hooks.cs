using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using BindingAttribute = TechTalk.SpecFlow.BindingAttribute;

namespace PlivoAssignment.Hooks
{
    [Binding]
    class Hooks
    {
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
         AventStack.ExtentReports.ExtentTest scenario,step;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
                                  + Path.DirectorySeparatorChar + "Result"
                                  + Path.DirectorySeparatorChar + "result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlreport);
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }
        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}
