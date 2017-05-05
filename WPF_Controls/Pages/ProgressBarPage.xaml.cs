using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControls.Pages
{
	/// <summary>
	/// Interaction logic for ProgressBarPage.xaml
	/// </summary>
	public partial class ProgressBarPage : Page
	{
		public ProgressBarPage()
		{
			InitializeComponent();
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			Progress1.IsIndeterminate = true;
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			Progress1.IsIndeterminate = false;
		}
		private Random _random = new Random();
		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			// set the maximum value to the number of steps used in the process

			Progress2.Maximum = 42; // number of files to download

			// do the work, update the progress value
			for (int counter = 0; counter < 43; counter++)
			{
				Progress2.Value = counter;
				await Task.Delay(_random.Next(50, 300));

			}
		}
	}
}
