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
  /// Interaction logic for CheckboxPage.xaml
  /// </summary>
  public partial class CheckboxPage : Page
  {
    public CheckboxPage()
    {
      InitializeComponent();
    }

   

    private void ActiveCustomerCheckBox_Checked(object sender, RoutedEventArgs e)
    {
      MessageTextBlock.Text = "Paddington's Pastries is an active customer.";
    }

    private void ActiveCustomerCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
      MessageTextBlock.Text = "Paddington's Pastries is not an active customer.";
    }

    private void ActiveCustomerCheckBox_Indeterminate(object sender, RoutedEventArgs e)
    {
      MessageTextBlock.Text = "Cannot determine Paddington's Pastries customer status.";
    }
  }
}
