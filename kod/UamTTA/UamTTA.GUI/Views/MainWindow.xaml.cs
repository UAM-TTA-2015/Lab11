using UamTTA.GUI.ViewModels;

namespace UamTTA.GUI.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow(IMainWindowViewModel viewModel)
		{
			InitializeComponent();

			DataContext = viewModel;
		}
	}
}