using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class BudgetServiceTests
    {
        [Test]
        public void AddAccountToBudget_Should_Get_Budget_From_Repository()
        {
            int budgetId = 2;

            _sut.AddAccountToBudget(budgetId, 17);

            A.CallTo(() => _budgetRepository.FindById(budgetId))
                .MustHaveHappened();
        }

        [Test]
        public void AddAccountToBudget_Should_Get_Account_From_Repository()
        {
            var accountId = 23;

            _sut.AddAccountToBudget(5, accountId);

            A.CallTo(() => _accountRepository.FindById(accountId))
                .MustHaveHappened();
        }

        [Test]
        public void AddAccountToBudget_Should_Return_Budget_From_Repository()
        {
            var budgetId = 11;
            var accountId = 7;
            var expected = new Budget();
            A.CallTo(() => _budgetRepository.FindById(budgetId))
                .Returns(new Budget { RelatedAccounts = new List<Account>() });
            A.CallTo(() => _budgetRepository.Persist(A<Budget>._))
                .Returns(expected);
            A.CallTo(() => _accountRepository.FindById(accountId))
                .Returns(new Account());

            var result = _sut.AddAccountToBudget(budgetId, accountId);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddAccountToBudget_Should_Return_Budget_From_Repository_For_Already_Existing_Account_Relationship()
        {
            var budgetId = 11;
            var accountId = 7;
            var expected = new Budget { RelatedAccounts = new List<Account> { new Account { Id = accountId } } };
            A.CallTo(() => _budgetRepository.FindById(budgetId))
                .Returns(expected);
            A.CallTo(() => _budgetRepository.Persist(A<Budget>._))
                .Returns(new Budget());

            var result = _sut.AddAccountToBudget(budgetId, accountId);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddAccountToBudget_Should_Return_Budget_With_Added_Account()
        {
            var budgetId = 11;
            var accountId = 7;
            var expectedBudget = new Budget { RelatedAccounts = new List<Account>() };
            var expectedAccount = new Account { Id = accountId };
            A.CallTo(() => _accountRepository.FindById(accountId))
                .Returns(expectedAccount);
            A.CallTo(() => _budgetRepository.FindById(budgetId))
                .Returns(expectedBudget);
            A.CallTo(() => _budgetRepository.Persist(A<Budget>._))
                .Returns(expectedBudget);

            var result = _sut.AddAccountToBudget(budgetId, accountId);

            CollectionAssert.Contains(result.RelatedAccounts, expectedAccount);
        }
    }
}