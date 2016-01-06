using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class BudgetServiceTests
    {
        [Test]
        public void UpdateBudget_Should_Persist_Budget_In_Repository()
        {
            var budget = new Budget();

            _sut.UpdateBudget(budget);

            A.CallTo(() => _budgetRepository.Persist(budget))
                .MustHaveHappened();
        }

        [Test]
        public void UpdateBudget_Should_Return_Budget_From_Repository()
        {
            var expected = new Budget();
            A.CallTo(() => _budgetRepository.Persist(A<Budget>._))
                .Returns(expected);

            var result = _sut.UpdateBudget(new Budget());

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}