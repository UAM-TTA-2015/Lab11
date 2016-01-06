using System;
using System.Collections.Generic;
using System.Linq;
using UamTTA.Model;
using UamTTA.Storage;

namespace UamTTA.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetFactory _factory;
        private readonly IRepository<Budget> _budgetRepository;
        private readonly IRepository<BudgetTemplate> _templateRepository;
        private readonly IRepository<Account> _accountRepository;

        public BudgetService(IBudgetFactory factory, IRepository<Budget> budgetRepository, IRepository<BudgetTemplate> templateRepository, IRepository<Account> accountRepository)
        {
            _factory = factory;
            _budgetRepository = budgetRepository;
            _templateRepository = templateRepository;
            _accountRepository = accountRepository;
        }

        public BudgetTemplate CreateBudgetTemplate(BudgetTemplate template)
        {
            return _templateRepository.Persist(template);
        }

        public BudgetTemplate UpdateBudgetTemplate(BudgetTemplate template)
        {
            return _templateRepository.Persist(template);
        }

        public Budget CreateBudgetFromTemplate(BudgetTemplate template, DateTime startDate)
        {
            Budget newBudget = _factory.CreateBudget(template, startDate);
            _budgetRepository.Persist(newBudget);
            return newBudget;
        }

        public Budget CreateBudgetFromTemplate(int templateId, DateTime startDate)
        {
            var template = _templateRepository.FindById(templateId);
            Budget newBudget = _factory.CreateBudget(template, startDate);
            _budgetRepository.Persist(newBudget);
            return newBudget;
        }

        public Budget GetBudgetById(int budgetId)
        {
            return _budgetRepository.FindById(budgetId);
        }

        public Budget UpdateBudget(Budget budget)
        {
            return _budgetRepository.Persist(budget);
        }

        public IEnumerable<Budget> GetAllBudgets()
        {
            return _budgetRepository.GetAll();
        }

        public Budget AddAccountToBudget(int budgetId, int accountId)
        {
            Budget budget = _budgetRepository.FindById(budgetId);
            if (budget == null)
                throw new ArgumentException("Budget id is invalid!", nameof(budgetId));
            if (budget.RelatedAccounts == null)
                budget.RelatedAccounts = new List<Account>();
            if (budget.RelatedAccounts.Any(a => a.Id == accountId))
                return budget;
            Account account = _accountRepository.FindById(accountId);
            if (account == null)
                throw new ArgumentException("Account id is invalid!", nameof(accountId));
            budget.RelatedAccounts.Add(account);
            return _budgetRepository.Persist(budget);
        }

        public Budget AddTransferToBudget(int budgetId, Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}