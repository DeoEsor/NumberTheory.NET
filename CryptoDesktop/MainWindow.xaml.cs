using System;
using System.Windows;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using СryptoClient;

namespace CryptoDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		private Connection Connection;
		public MainWindow()
		{
			Connection = new Connection();
			InitializeComponent();
			TextBlock.Text = Connection.last_string;
		}
	}
}
