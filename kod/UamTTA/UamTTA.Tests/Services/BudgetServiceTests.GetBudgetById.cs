using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class BudgetServiceTests
    {
        [Test]
        public void GetBudgetById_Should_Get_Budget_From_Repository()
        {
            int budgetId = 13;

            _sut.GetBudgetById(budgetId);

            A.CallTo(() => _budgetRepository.FindById(budgetId))
                .MustHaveHappened();
        }

        [Test]
        public void GetBudgetById_Should_Return_Budget_From_Repository()
        {
            var expected = new Budget();
            A.CallTo(() => _budgetRepository.FindById(A<int>._))
                .Returns(expected);

            var result = _sut.GetBudgetById(11);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}