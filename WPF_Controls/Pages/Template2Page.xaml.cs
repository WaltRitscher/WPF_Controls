using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for Template2Page.xaml
  /// </summary>
  public partial class Template2Page : Page
  {
    public Template2Page()
    {
      InitializeComponent();
    }

    private void Button1_Click(object sender, RoutedEventArgs e)
    {
      TimeSpan scaleDuration = new TimeSpan(0, 0, 0, 3, 0);
      DoubleAnimation ProgressAnimation1 = new DoubleAnimation(0, 100, scaleDuration, FillBehavior.HoldEnd);

      DoubleAnimation ProgressAnimation2 = new DoubleAnimation(0, 100, scaleDuration, FillBehavior.HoldEnd);

      DoubleAnimation ProgressAnimation3 = new DoubleAnimation(0, 100, scaleDuration, FillBehavior.HoldEnd);

      ProgressAnimation1.Completed += (s, e1) =>
      {
        Progress2.BeginAnimation(ProgressBar.ValueProperty, ProgressAnimation2);
      };

      ProgressAnimation2.Completed += (s, e1) =>
      {
        Progress3.BeginAnimation(ProgressBar.ValueProperty, ProgressAnimation3);
      };

      Progress1.BeginAnimation(ProgressBar.ValueProperty, ProgressAnimation1);
    }
  }
}