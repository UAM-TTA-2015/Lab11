using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using UamTTA.GUI.Contracts;
using UamTTA.GUI.Controllers;

namespace UamTTA.GUI.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private IEnumerable<Budget> _budgets;

        public IEnumerable<Budget> Budgets
        {
            get { return _budgets; }
            set
            {
                _budgets = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetBudgetsCommand { get; }

        public MainWindowViewModel(IMainWindowController controller)
        {
            controller.ViewModel = this;

            Budgets = new ObservableCollection<Budget>();
            GetBudgetsCommand = new DelegateCommand(controller.OnGetBudgets);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}