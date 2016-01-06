using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace UamTTA.WebApp.Tests
{
    [Binding]
    public class BudgetListSteps
    {
        private IWebDriver _driver;

        [Given(@"I have started web browser")]
        public void GivenIHaveStartedBrowser()
        {
            _driver = new FirefoxDriver(new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe"), new FirefoxProfile());
        }

        [Given(@"I navigated to application URL")]
        public void GivenINavigatedToApplicationPage()
        {
            _driver.Navigate().GoToUrl("localhost:9999");
        }

        [When(@"I click Get Budgets button")]
        public void WhenIClickGetBudgetsButton()
        {
            var button = _driver.FindElement(By.Id("getBudgetsBtn"));
            button.Click();
        }

        [Then(@"Budget list is not empty")]
        public void ThenBudgetListHasItems()
        {
            var budgetsList = _driver.FindElement(By.Id("budgetsTable"));
            var rows = budgetsList.FindElements(By.TagName("tr")).Skip(1);
            CollectionAssert.IsNotEmpty(rows);
        }

        [Then(@"Budget list is empty")]
        public void ThenBudgetListIsEmpty()
        {
            var budgetsList = _driver.FindElement(By.Id("budgetsTable"));
            var rows = budgetsList.FindElements(By.TagName("tr")).Skip(1);
            CollectionAssert.IsEmpty(rows);
        }

        [When(@"Wait for (.*) seconds")]
        public void WhenWaitForSecond(int p0)
        {
            Thread.Sleep(TimeSpan.FromSeconds(p0));
        }

        [AfterScenario]
        public void CloseApp()
        {
            _driver.Close();
        }
    }
}
