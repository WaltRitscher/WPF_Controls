using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for MouseEventsPage.xaml
  /// </summary>
  public partial class MouseEventsPage : Page
  {
    public MouseEventsPage()
    {
      InitializeComponent();
    }

    private void GridA_MouseDown(object sender, MouseButtonEventArgs e)
    {
      // fires when any mouse button is down.
      MessageTextBlock.Text = "GridA Button Down.";
    }

    private void GridA_MouseUp(object sender, MouseButtonEventArgs e)
    {
      MessageTextBlock.Text = "GridA Button Up.";
    }

    private void GridB_MouseDown(object sender, MouseButtonEventArgs e)
    {
      // examine the MouseButtonEventArgs args
      string message = $"Mouse Device: {e.MouseDevice.ToString()}\nMouse Button: {e.ChangedButton}";
      MessageTextBlock.Text = message;
    }

    private void GridC_MouseMove(object sender, MouseEventArgs e)
    {
      string positionMessage = $"X: {e.GetPosition(this).X.ToString("n0")}\nY: {e.GetPosition(this).Y.ToString("n0")}";
      MessageTextBlock.Text = positionMessage;
    }

    private void GridD_MouseMove(object sender, MouseEventArgs e)
    {
      // get the button state during move
      string positionMessage = $"X: {e.GetPosition(this).X.ToString("n0")}\nY: {e.GetPosition(this).Y.ToString("n0")}\n";
      string buttonStateMessage = $"LeftButton: {e.LeftButton}\nMiddleButton: {e.MiddleButton}\nMiddleButton: {e.RightButton}";
      MessageTextBlock.Text = positionMessage + buttonStateMessage;
    }

    private void GridE_MouseEnter(object sender, MouseEventArgs e)
    {
      Ellipse1.Fill = Brushes.Orange;
    }

    private void GridE_MouseLeave(object sender, MouseEventArgs e)
    {
      Ellipse1.Fill = Brushes.LightCoral;
    }

    private void GridF_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      if (e.Delta > 0)
      {
        // positive direction
        GridScaleTransform.ScaleX = GridScaleTransform.ScaleY = GridScaleTransform.ScaleX + .01;
      }
      else
      {
        GridScaleTransform.ScaleX = GridScaleTransform.ScaleY = GridScaleTransform.ScaleX - .01;
      }
    }
  }
}