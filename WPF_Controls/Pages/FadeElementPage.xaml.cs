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
  /// Interaction logic for FadeElementPage.xaml
  /// </summary>
  public partial class FadeElementPage : Page
  {
    public FadeElementPage()
    {
      InitializeComponent();
    }

    private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      if (Image1.Opacity > 0)
      {
        FadeOutImage();
      }
      else
      {
        FadeInImage();
      }

      e.Handled = true;
    }

    private void FadeOutImage()
    {
      var animation = new DoubleAnimation
      {
        To = 0,
        Duration = TimeSpan.FromSeconds(2),
        FillBehavior = FillBehavior.Stop
      };

      animation.Completed += (s, a) => Image1.Opacity = 0;

      Image1.BeginAnimation(UIElement.OpacityProperty, animation);
    }

    private void FadeInImage()
    {
      var animation = new DoubleAnimation
      {
        To = 1,
        Duration = TimeSpan.FromSeconds(2),
        FillBehavior = FillBehavior.Stop
      };

      animation.Completed += (s, a) => Image1.Opacity = 1;

      Image1.BeginAnimation(UIElement.OpacityProperty, animation);
    }

  }
}
