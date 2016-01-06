using UamTTA.GUI.ViewModels;

namespace UamTTA.GUI.Controllers
{
	public interface IMainWindowController
	{
		MainWindowViewModel ViewModel { get; set; }

		void OnGetBudgets();
	}
}