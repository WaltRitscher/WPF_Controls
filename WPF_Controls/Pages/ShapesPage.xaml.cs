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
  /// Interaction logic for ShapesPage.xaml
  /// </summary>
  public partial class ShapesPage : Page
  {
    public ShapesPage()
    {
      InitializeComponent();
     
    }

    private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
    {
      Panel.SetZIndex(Ellipse1, Panel.GetZIndex(Ellipse2) + 1);
      Ellipse1.Fill = new SolidColorBrush(Colors.Orange);
      Ellipse2.Fill = new SolidColorBrush(Colors.LightSteelBlue);
    }

    private void Ellipse2_MouseEnter(object sender, MouseEventArgs e)
    {
      Panel.SetZIndex(Ellipse2, Panel.GetZIndex(Ellipse1) + 1);
      Ellipse2.Fill = new SolidColorBrush(Colors.Orange);
      Ellipse1.Fill = new SolidColorBrush(Colors.LightSteelBlue);
    }
  }
}
