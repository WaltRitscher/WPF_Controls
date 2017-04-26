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
  /// Interaction logic for PolylinePage.xaml
  /// </summary>
  public partial class PolylinePage : Page
  {
    public PolylinePage()
    {
      InitializeComponent();
    }

    private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      var currentPositnio = (Point)e.MouseDevice.GetPosition(MainCanvas);
      DynamicPolyline.Points.Add(currentPositnio);

    }

    private void Canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      DynamicPolyline.Points.Clear();

    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (MainTabControl.SelectedIndex== 3)
      {
        
      }
    }
  }
}
