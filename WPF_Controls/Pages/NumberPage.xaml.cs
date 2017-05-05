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
	/// Interaction logic for NumberPage.xaml
	/// </summary>
	public partial class NumberPage : Page
	{
		public NumberPage()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			double result;
			bool isNumber = double.TryParse(NumberTextBox.Text, out result);

			var tripleNumber = result * 3.0;

			MessageTextBlock.Text = $"{result} * 3 = {tripleNumber}";

		}

		
		private void TripleNumberSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var tripleNumber = TripleNumberSlider.Value * 3.0;
			try
			{
				MessageTextBlock2.Text = $"{TripleNumberSlider.Value} * 3 = {tripleNumber}";
			}
			catch
			{
				// ignore
			}
		}
	}
}
