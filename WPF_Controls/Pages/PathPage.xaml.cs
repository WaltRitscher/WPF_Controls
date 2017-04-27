using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for PathPage.xaml
  /// </summary>
  public partial class PathPage : Page
  {
    public PathPage()
    {
      InitializeComponent();

      foreach (CheckBox item in MainStackPanel.Children.OfType<CheckBox>())
      {
        item.IsChecked = true;
      }
      PathDataTextBlock.Text = String.Empty;
    }

    private void CircleBackPath_Checked(object sender, RoutedEventArgs e)
    {
      CircleBackPath.Opacity = 1;
      ShowPathData(CircleBackPath);
    }

    private void CircleBackPath_Unchecked(object sender, RoutedEventArgs e)
    {
      CircleBackPath.Opacity = 0;
      ShowPathData(CircleBackPath);
    }

    private void GradientPathButton_Checked(object sender, RoutedEventArgs e)
    {
      Path3.Opacity = 1;
      ShowPathData(Path3);
    }

    private void GradientPathButton_Unchecked(object sender, RoutedEventArgs e)
    {
      Path3.Opacity = 0;
      ShowPathData(Path3);
    }

    private void Path4Button_Checked(object sender, RoutedEventArgs e)
    {
      CheckPath.Opacity = 1;
      ShowPathData(CheckPath);
    }

    private void Path4Button_Unchecked(object sender, RoutedEventArgs e)
    {
      CheckPath.Opacity = 0;
      ShowPathData(CheckPath);
    }

    private void Path5Button_Checked(object sender, RoutedEventArgs e)
    {
      CheckOutlinePath.Opacity = 1;
      ShowPathData(CheckOutlinePath);
    }

    private void Path5Button_Unchecked(object sender, RoutedEventArgs e)
    {
      CheckOutlinePath.Opacity = 0;
      ShowPathData(CheckOutlinePath);
    }

    private void ShowPathData(Path showPath)
    {
      PathDataTextBlock.Text = FormatGeometryDataString(showPath.Data.ToString());
    }

    private string FormatGeometryDataString(string dataString)
    {
      dataString = dataString.Replace("F", "FillRule: ");
      dataString = dataString.Replace("M", "\nStart Point (M): ");

      dataString = dataString.Replace("C", "\nBezier (C): ");
      dataString = dataString.Replace("L", "\nLine (L): ");
      dataString = dataString.Replace("Q", "\nQuadratic Bezier (C): ");
      return dataString;
    }
  }
}