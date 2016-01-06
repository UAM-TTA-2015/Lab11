using System.Collections.Generic;
using System.Windows.Input;
using UamTTA.GUI.Contracts;

namespace UamTTA.GUI.ViewModels
{
    public interface IMainWindowViewModel
    {
        IEnumerable<Budget> Budgets { get; set; }

        ICommand GetBudgetsCommand { get; }
    }
}