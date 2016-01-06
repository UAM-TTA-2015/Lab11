using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public partial class AccountServiceTests
    {
        [Test]
        public void GetAccountById_Should_Get_Account_From_Repository()
        {
            int accountId = 13;

            _sut.GetAccountById(accountId);

            A.CallTo(() => _repository.FindById(accountId))
                .MustHaveHappened();
        }

        [Test]
        public void GetAccountById_Should_Return_Account_From_Repository()
        {
            var expected = new Account();
            A.CallTo(() => _repository.FindById(A<int>._))
                .Returns(expected);

            var result = _sut.GetAccountById(11);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}