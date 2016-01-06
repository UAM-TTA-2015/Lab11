using System.Windows;
using Autofac;
using UamTTA.GUI.Controllers;
using UamTTA.GUI.Models;
using UamTTA.GUI.Services;
using UamTTA.GUI.ViewModels;
using UamTTA.GUI.Views;

namespace UamTTA.GUI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var builder = new ContainerBuilder();
            builder.RegisterType<MainWindowController>().As<IMainWindowController>();
            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
            builder.RegisterType<BudgetService>().As<IBudgetService>();
            builder.RegisterType<MainWindow>();
		    var container = builder.Build();
			var window = container.Resolve<MainWindow>();
			window.Show();
		}
	}
}