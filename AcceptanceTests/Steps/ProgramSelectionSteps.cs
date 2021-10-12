using System;
using TechTalk.SpecFlow;
//
using AcceptanceTests.Interface;
using AcceptanceTests.Common.Application;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class ProgramSelectionSteps
    {
        [Given(@"I select the program ""(.*)""")]
        public void GivenISelectTheProgram(string program)
        {
            //ScenarioContext.Current.Pending();

            //Update Test Context
            TestRunnerInterface.Map.testContext.program = program;

            //Wait for PROGRAM AND ORGANIZATION SELECTION

            //The search page is not the default home page
            TestRunnerInterface.Map.programSelectionPage.ProgramSelection(program);

            //Wait for Product Home PAGE
            TestRunnerInterface.Map.safePage.WaitProductHomePage("PROVIDER SEARCH PAGE", RunTimeVars.REPEAT_TIMES);


        }

        [When(@"I select the program ""(.*)""")]
        public void WhenISelectTheProgram(string program)
        {
            //ScenarioContext.Current.Pending();
            //Wait for PROGRAM AND ORGANIZATION SELECTION

            //The search page is not the default home page
            TestRunnerInterface.Map.programSelectionPage.ProgramSelection(program);

            //Wait for Product Home PAGE
            TestRunnerInterface.Map.safePage.WaitProductHomePage("PROVIDER SEARCH PAGE", RunTimeVars.REPEAT_TIMES);

        }


        [Given(@"I select the parent program ""(.*)""")]
        public void GivenISelectTheParentProgram(string program)
        {
            //ScenarioContext.Current.Pending();

            //Update Test Context
            TestRunnerInterface.Map.testContext.program = program;

            //Wait for PROGRAM AND ORGANIZATION SELECTION

            //The search page is the default home page
            TestRunnerInterface.Map.programSelectionPage.ProgramSelection(program, false);

            //Wait for Product Home PAGE
            TestRunnerInterface.Map.safePage.WaitProductHomePage("ADVANCED STUDENT SEARCH PAGE", RunTimeVars.REPEAT_TIMES);


        }




    }
}
