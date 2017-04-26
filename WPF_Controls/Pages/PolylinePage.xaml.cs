using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
      var currentPosition = e.MouseDevice.GetPosition(MainCanvas);
      DynamicPolyline.Points.Add(currentPosition);
    }

    private void Canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      DynamicPolyline.Points.Clear();
    }

    private double _range = 10;
    private static Random random = new Random();

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
        };

        animation.Completed += (s, a) =>
        {
          animation.To -= 10;
          ChartLine.Points.Add(new Point(ChartLine.Points.Count * _range, random.Next(5, 70)));
          ChartTranslateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        };

        ChartTranslateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
      }
    }
  }
}