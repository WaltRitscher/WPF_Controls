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
  /// Interaction logic for InteractionMode.xaml
  /// </summary>
  public partial class InteractionModesShapesPage : Page
  {
    public InteractionModesShapesPage()
    {
      InitializeComponent();
      this.Focus();
    }

    private void Ellipse1_MouseDown(object sender, MouseButtonEventArgs e)
    {
      MessageTextBlock.Foreground = new SolidColorBrush(Colors.DarkOrange);
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        MessageTextBlock.Text = "MouseDown Left Button";
      }

      if (e.RightButton == MouseButtonState.Pressed)
      {
        MessageTextBlock.Text = "MouseDown Right Button";
      }

    }

    private void Ellipse1_MouseMove(object sender, MouseEventArgs e)
    {
      MessageTextBlock.Foreground = new SolidColorBrush(Colors.DarkOrange);

      MessageTextBlock.Text = $"Mouse Move: {e.GetPosition(this).X.ToString("N0")} - {e.GetPosition(this).Y.ToString("N0")}";
    }

    

    private void Rectangle1_TouchDown(object sender, TouchEventArgs e)
    {
      MessageTextBlock.Foreground = new SolidColorBrush(Colors.DarkSlateGray);

      MessageTextBlock.Text = "Touch Down";
    }

    private void Rectangle1_TouchMove(object sender, TouchEventArgs e)
    {
      MessageTextBlock.Foreground = new SolidColorBrush(Colors.DarkSlateGray);

      MessageTextBlock.Text = 
        $"Touch Move: {e.GetTouchPoint(this).Position.X.ToString("N0")} - {e.GetTouchPoint(this).Position.Y.ToString("N0")}";

    }

   

    private void Rectangle1_TouchUp(object sender, TouchEventArgs e)
    {
      MessageTextBlock.Foreground = new SolidColorBrush(Colors.DarkSlateGray);

      MessageTextBlock.Text = "Touch Up";
    }
    private void Rectangle1_StylusDown(object sender, StylusDownEventArgs e)
    {

    }

    private void Page_KeyUp(object sender, KeyEventArgs e)
    {
      MessageTextBlock.Foreground = new SolidColorBrush(Colors.Black);

      MessageTextBlock.Text = e.Key.ToString();
    }
  }
}
