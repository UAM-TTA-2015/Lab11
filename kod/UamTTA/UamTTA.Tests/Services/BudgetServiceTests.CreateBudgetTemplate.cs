using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class BudgetServiceTests
    {
        [Test]
        public void CreateBudgetTemplate_Should_Persist_Budget_Template_In_Repository()
        {
            var budgetTemplate = new BudgetTemplate();

            _sut.CreateBudgetTemplate(budgetTemplate);

            A.CallTo(() => _templateRepository.Persist(budgetTemplate))
                .MustHaveHappened();
        }

        [Test]
        public void CreateBudgetTemplate_Should_Return_Budget_Template_From_Repository()
        {
            var expected = new BudgetTemplate();
            A.CallTo(() => _templateRepository.Persist(A<BudgetTemplate>._))
                .Returns(expected);

            var result = _sut.CreateBudgetTemplate(new BudgetTemplate());

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}