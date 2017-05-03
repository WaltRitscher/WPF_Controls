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
	/// Interaction logic for SelectTextPage.xaml
	/// </summary>
	public partial class SelectTextPage : Page
	{
		public SelectTextPage()
		{
			InitializeComponent();
			var editedText = SourceTextBox.Text;
		}
		private void GetSelectedButton_Click(object sender, RoutedEventArgs e)
		{
			string selected = SourceTextBox.SelectedText;
			messageText.Text = selected;
		}

		private void SetSelectedButton_Click(object sender, RoutedEventArgs e)
		{
			SourceTextBox.Focus();
			SourceTextBox.Select(12, 30);

		}

		private void SelectAllButton_Click(object sender, RoutedEventArgs e)
		{
			SourceTextBox.Focus();
			SourceTextBox.SelectAll();
		}

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			// get the location of the search word in source
			var start = SourceTextBox.Text.IndexOf(SearchTextBox.Text);
			SourceTextBox.Focus();
			SourceTextBox.Select(start, SearchTextBox.Text.Length);
		}
	}
}
