using System;
using System.Collections.Generic;
using UamTTA.Model;

namespace UamTTA.Services
{
    public interface IBudgetService
    {
        BudgetTemplate CreateBudgetTemplate(BudgetTemplate template);

        Budget CreateBudgetFromTemplate(BudgetTemplate template, DateTime startDate);

        Budget CreateBudgetFromTemplate(int templateId, DateTime startDate);

        Budget GetBudgetById(int budgetId);

        Budget UpdateBudget(Budget budget);

        IEnumerable<Budget> GetAllBudgets();

        Budget AddAccountToBudget(int budgetId, int accountId);

        Budget AddTransferToBudget(int budgetId, Transfer transfer);
    }
}