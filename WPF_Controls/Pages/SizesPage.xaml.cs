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
  /// Interaction logic for SizesPage.xaml
  /// </summary>
  public partial class SizesPage : Page
  {
    public SizesPage()
    {
      InitializeComponent(); 
    }

    private void LeftActionButton_Click(object sender, RoutedEventArgs e)
    {
      string message = $"Width: {LeftActionButton.Width}\nDesired Width: {LeftActionButton.DesiredSize.Width}\nActualSize: {LeftActionButton.ActualWidth}";
      LeftMessage.Text = message;
    }

    private void RightActionButton_Click(object sender, RoutedEventArgs e)
    {
      string message = $"Width: {RightActionButton.Width}\nDesired Width: {RightActionButton.DesiredSize.Width}\nActualSize: {RightActionButton.ActualWidth}";
      RightMessage.Text = message;
    }
  }
}
