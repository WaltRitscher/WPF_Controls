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
  /// Interaction logic for ToggleButtonPage.xaml
  /// </summary>
  public partial class ToggleButtonPage : Page
  {
    public ToggleButtonPage()
    {
      InitializeComponent();
    }

    private void HideImageButton_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void IsCheckedButton_Click(object sender, RoutedEventArgs e)
    {
      if (IsCheckedButton.IsChecked == true)
      {
        LogoImage.Visibility = Visibility.Hidden;
      }
      else
      {
        LogoImage.Visibility = Visibility.Visible;
      }
    }

    private void CheckedEventButton_Checked(object sender, RoutedEventArgs e)
    {
      LogoImage.Visibility = Visibility.Hidden;
    }

    private void CheckedEventButton_Unchecked(object sender, RoutedEventArgs e)
    {
      LogoImage.Visibility = Visibility.Visible;
    }
  }
}
