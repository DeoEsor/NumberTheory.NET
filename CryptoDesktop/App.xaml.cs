using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CryptoDesktop.MVVM.ViewModel;
using DryIoc;
using СryptoClient;

namespace CryptoDesktop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static Container Container { get; set; }
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			
			Container = new Container();
			
			// Grpc client
			Container.Register<CryptoClient>(Reuse.Singleton);
			//Views
			Container.Register<Registration>(Reuse.Transient);
			Container.Register<MainWindow>(Reuse.Transient);
			//ViewModels
			Container.Register<ChatViewModel>(Reuse.Singleton);
			
			var reg = Container.Resolve<Registration>();
			reg.DataContext = new RegistrationViewModel(reg);
			reg.Show();
		}

		protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
		{
			base.OnSessionEnding(e);
		}
	}
}
