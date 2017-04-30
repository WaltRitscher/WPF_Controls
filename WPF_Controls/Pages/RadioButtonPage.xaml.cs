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
  /// Interaction logic for RadioButtonPage.xaml
  /// </summary>
  public partial class RadioButtonPage : Page
  {
    public RadioButtonPage()
    {
      InitializeComponent();
    }

    private void StackPanel_Checked(object sender, RoutedEventArgs e)
    {
      var currentRadio = e.OriginalSource as RadioButton;
      MessageTextBlock.Text = "Checked: " + currentRadio.Content.ToString();
    }

    private void StackPanel_Unchecked(object sender, RoutedEventArgs e)
    {

    }
  }
}
