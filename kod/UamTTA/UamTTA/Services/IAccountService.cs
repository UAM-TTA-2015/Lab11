using UamTTA.Model;

namespace UamTTA.Services
{
    public interface IAccountService
    {
        Account GetAccountById(int accountId);

        Account CreateAccount(Account account);

        Account UpdateAccount(Account account);
    }
}