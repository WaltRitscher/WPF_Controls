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
using System.Windows.Media.Animation;
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
      var currentPosition = (Point)e.MouseDevice.GetPosition(MainCanvas);
      DynamicPolyline.Points.Add(currentPosition);

    }

    private void Canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      DynamicPolyline.Points.Clear();

    }
    private double _range = 10;
    static Random random = new Random();

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (MainTabControl.SelectedIndex == 3)
      {
        for (int counter = 0; counter < 20; counter++)
        {
          ChartLine.Points.Add(new Point(counter * _range, random.Next(5, 70)));
        }
       
       

        var animation = new DoubleAnimation
        {
          To = -30,
          Duration = TimeSpan.FromMilliseconds(300),
          // FillBehavior = FillBehavior.Stop
        };

        animation.Completed += (s, a) =>
        {
          animation.To-=10;
          ChartLine.Points.Add(new Point(ChartLine.Points.Count * _range, random.Next(5, 70)));
         // ChartLine.Points.RemoveAt(0);
          ChartTranslateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        };

        ChartTranslateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
      }
    }
  }
}

