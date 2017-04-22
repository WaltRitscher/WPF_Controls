using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for TouchEventsPage.xaml
  /// </summary>
  public partial class TouchEventsPage : Page
  {
    public TouchEventsPage()
    {
      InitializeComponent();
    }

    private Dictionary<TouchDevice, Ellipse> _orbs = new Dictionary<TouchDevice, Ellipse>();

    private void MainRectangle_TouchDown(object sender, TouchEventArgs e)
    {
      Ellipse orb = CreateOrb();

      TouchPoint point = e.GetTouchPoint(MainRectangle);
      orb.RenderTransform = new TranslateTransform(point.Position.X, point.Position.Y);

      // add to dictionary
      _orbs[e.TouchDevice] = orb;

      // add to grid
      MainGrid.Children.Add(orb);
    }

    private static Ellipse CreateOrb()
    {
      Ellipse orb = new Ellipse();
      orb.Width = orb.Height = 21;

      orb.Fill = Brushes.Gray;
      orb.Stroke = Brushes.Orange;
      orb.HorizontalAlignment = HorizontalAlignment.Left;
      orb.VerticalAlignment = VerticalAlignment.Top;
      Grid.SetColumn(orb, 2);
      return orb;
    }

    private void MainRectangle_TouchMove(object sender, TouchEventArgs e)
    {
      Ellipse orb = _orbs[e.TouchDevice];
      TranslateTransform transform = orb.RenderTransform as TranslateTransform;

      TouchPoint point = e.GetTouchPoint(MainRectangle);

      transform.X = point.Position.X;
      transform.Y = point.Position.Y;
    }

    private void MainRectangle_TouchUp(object sender, TouchEventArgs e)
    {
      MainRectangle.ReleaseTouchCapture(e.TouchDevice);

      MainGrid.Children.Remove(_orbs[e.TouchDevice]);
      _orbs.Remove(e.TouchDevice);
    }
  }
}