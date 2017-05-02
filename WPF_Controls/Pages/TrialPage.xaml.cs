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
  /// Interaction logic for TrialPage.xaml
  /// </summary>
  public partial class TrialPage : Page
  {
    public TrialPage()
    {
      InitializeComponent();
    }

    private void GetSelectedButton_Click(object sender, RoutedEventArgs e)
    {
      string selected = selectionTextbox.SelectedText;
      messageText.Text = selected;
    }

    private void SetSelectedButton_Click(object sender, RoutedEventArgs e)
    {
      selectionTextbox.Focus();
      selectionTextbox.Select(12, 30);

    }

    private void SelectAllButton_Click(object sender, RoutedEventArgs e)
    {
      selectionTextbox.Focus();
      selectionTextbox.SelectAll();
    }

  }
}
