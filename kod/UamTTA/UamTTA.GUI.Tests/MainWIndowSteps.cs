using System;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace UamTTA.GUI.Tests
{
    [Binding]
    public class MainWIndowSteps
    {
        private Application _appUnderTest;
        private Window _appWindow;

        [Given(@"I have started the application")]
        public void GivenIHaveStartedTheApplication()
        {
            _appUnderTest = Application.Launch(@"..\..\..\UamTTA.GUI\bin\Debug\UamTTA.GUI.exe");
            Assert.That(_appUnderTest, Is.Not.Null);
        }

        [Given(@"I can see application window")]
        public void GivenICanSeeApplicationWindow()
        {
            _appWindow = _appUnderTest.GetWindow("UamTTA Demo");
            Assert.That(_appWindow.Visible, Is.True);
        }

        [When(@"I click ([\w\s]+) button")]
        public void WhenIClickButton(string buttonCaption)
        {
            var button = _appWindow.Get<Button>(SearchCriteria.ByText(buttonCaption));
            button.Click();
        }

        [Then(@"Budget list is not empty")]
        public void ThenBudgetListHasItems()
        {
            var budgetsList = _appWindow.Get<ListBox>(SearchCriteria.ByAutomationId("BudgetsListView"));
            CollectionAssert.IsNotEmpty(budgetsList.Items);
        }

        [Then(@"Budget list is empty")]
        public void ThenBudgetListIsEmpty()
        {
            var budgetsList = _appWindow.Get<ListBox>(SearchCriteria.ByAutomationId("BudgetsListView"));
            CollectionAssert.IsEmpty(budgetsList.Items);
        }

        [When(@"Wait for (.*) second")]
        public void WhenWaitForSecond(int p0)
        {
            Thread.Sleep(TimeSpan.FromSeconds(p0));
        }


        [AfterScenario]
        public void CloseApp()
        {
            _appUnderTest.Kill();
        }
    }
}
