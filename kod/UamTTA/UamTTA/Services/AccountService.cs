using UamTTA.Model;
using UamTTA.Storage;

namespace UamTTA.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _repository;

        public AccountService(IRepository<Account> repository)
        {
            _repository = repository;
        }

        public Account GetAccountById(int accountId)
        {
            return _repository.FindById(accountId);
        }

        public Account CreateAccount(Account account)
        {
            return _repository.Persist(account);
        }

        public Account UpdateAccount(Account account)
        {
            return _repository.Persist(account);
        }
    }
}