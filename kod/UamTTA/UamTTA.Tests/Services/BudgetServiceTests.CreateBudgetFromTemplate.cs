using System;
using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class BudgetServiceTests
    {
        [Test]
        public void CreateBudgetFromTemplate_By_Template_Should_Create_Budget_Using_Factory()
        {
            var someTemplate = new BudgetTemplate();
            var someDate = DateTime.Today;

            _sut.CreateBudgetFromTemplate(someTemplate, someDate);

            A.CallTo(() => _budgetFactory.CreateBudget(someTemplate, someDate))
             .MustHaveHappened();
        }

        [Test]
        public void CreateBudgetFromTemplate_By_Template_Should_Persist_Created_Budget_In_Repository()
        {
            var someBudget = new Budget();
            A.CallTo(() => _budgetFactory.CreateBudget(A<BudgetTemplate>._, A<DateTime>._))
                .Returns(someBudget);

            _sut.CreateBudgetFromTemplate(new BudgetTemplate(), DateTime.Today);

            A.CallTo(() => _budgetRepository.Persist(someBudget)).MustHaveHappened();
        }

        [Test]
        public void CreateBudgetFromTemplate_By_Template_Id_Should_Get_Template_From_Repository()
        {
            var someTemplateId = 1;
            var someDate = DateTime.Today;

            _sut.CreateBudgetFromTemplate(someTemplateId, someDate);

            A.CallTo(() => _templateRepository.FindById(someTemplateId))
             .MustHaveHappened();
        }

        [Test]
        public void CreateBudgetFromTemplate_By_Template_Id_Should_Create_Budget_Using_Factory()
        {
            var someTemplateId = 1;
            var someDate = DateTime.Today;

            _sut.CreateBudgetFromTemplate(someTemplateId, someDate);

            A.CallTo(() => _budgetFactory.CreateBudget(A<BudgetTemplate>._, someDate))
             .MustHaveHappened();
        }

        [Test]
        public void CreateBudgetFromTemplate_By_Template_Id_Should_Persist_Created_Budget_In_Repository()
        {
            var someTemplateId = 1;
            var someTemplate = new BudgetTemplate();
            var someBudget = new Budget();
            A.CallTo(() => _templateRepository.FindById(someTemplateId))
                .Returns(someTemplate);
            A.CallTo(() => _budgetFactory.CreateBudget(A<BudgetTemplate>._, A<DateTime>._))
                .Returns(someBudget);

            _sut.CreateBudgetFromTemplate(someTemplateId, DateTime.Today);

            A.CallTo(() => _budgetRepository.Persist(someBudget)).MustHaveHappened();
        }
    }
}