using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;
using UamTTA.Services;
using UamTTA.Storage;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class AccountServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IRepository<Account>>();

            _sut = new AccountService(_repository);
        }

        private AccountService _sut;
        private IRepository<Account> _repository;
    }
}