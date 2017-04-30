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
  /// Interaction logic for DefaultButtonPage.xaml
  /// </summary>
  public partial class DefaultButtonPage : Page
  {
    public DefaultButtonPage()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var currentButton = sender as Button;
      MessageTextBlock.Foreground = currentButton.Foreground;
      if (currentButton.IsDefault)
      {
        MessageTextBlock.Text = "Default button clicked";
      }
      else if (currentButton.IsCancel)
      {
        MessageTextBlock.Text = "Cancel button clicked";
      }
      else {
        MessageTextBlock.Text = currentButton.Content.ToString();
      }
     
    }
  }
}
