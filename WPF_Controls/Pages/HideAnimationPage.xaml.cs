using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for HideAnimationPage.xaml
  /// </summary>
  public partial class HideAnimationPage : Page
  {
    public HideAnimationPage()
    {
      InitializeComponent();
    }

    private void Grid2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      FadeOut();
    }

    private void FadeOut()
    {
      var animation = new DoubleAnimation
      {
        To = 0,
        Duration = TimeSpan.FromSeconds(2),
        FillBehavior = FillBehavior.Stop
      };

      animation.Completed += (s, a) =>
      {
        Grid2.Opacity = 0;
        Grid2.Visibility = Visibility.Collapsed;
      };

      Grid2.BeginAnimation(UIElement.OpacityProperty, animation);
    }
  }
}