using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;
using UamTTA.Services;
using UamTTA.Storage;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class BudgetServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _budgetFactory = A.Fake<IBudgetFactory>();
            _budgetRepository = A.Fake<IRepository<Budget>>();
            _templateRepository = A.Fake<IRepository<BudgetTemplate>>();
            _accountRepository = A.Fake<IRepository<Account>>();

            _sut = new BudgetService(_budgetFactory, _budgetRepository, _templateRepository, _accountRepository);
        }

        private BudgetService _sut;
        private IBudgetFactory _budgetFactory;
        private IRepository<Budget> _budgetRepository;
        private IRepository<BudgetTemplate> _templateRepository;
        private IRepository<Account> _accountRepository;
    }
}