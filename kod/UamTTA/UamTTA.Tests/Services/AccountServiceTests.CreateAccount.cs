using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class AccountServiceTests
    {
        [Test]
        public void CreateAccount_Should_Persist_Account_In_Repository()
        {
            var account = new Account();

            _sut.CreateAccount(account);

            A.CallTo(() => _repository.Persist(account))
                .MustHaveHappened();
        }

        [Test]
        public void CreateAccount_Should_Return_Account_From_Repository()
        {
            var expected = new Account();
            A.CallTo(() => _repository.Persist(A<Account>._))
                .Returns(expected);

            var result = _sut.CreateAccount(new Account());

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}