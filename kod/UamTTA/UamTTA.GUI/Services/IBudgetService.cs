using System.Collections.Generic;
using System.Threading.Tasks;
using UamTTA.GUI.Contracts;

namespace UamTTA.GUI.Models
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> GetBudgetsAsync();
    }
}