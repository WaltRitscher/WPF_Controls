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

  public partial class RepeatButtonPage : Page
  {
    public RepeatButtonPage()
    {
      InitializeComponent();
    }

    private void LeftButton_Click(object sender, RoutedEventArgs e)
    {
      ImageLayoutTransform.X -=5;
    }

    private void TopButton_Click(object sender, RoutedEventArgs e)
    {
      ImageLayoutTransform.Y -= 5;
    }

    private void BottomButton_Click(object sender, RoutedEventArgs e)
    {
      ImageLayoutTransform.Y += 5;
    }

    private void RightButton_Click(object sender, RoutedEventArgs e)
    {
      ImageLayoutTransform.X += 5;
    }
  }
}
