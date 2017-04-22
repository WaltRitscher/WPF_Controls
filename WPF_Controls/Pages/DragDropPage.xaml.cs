using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for DragDropPage.xaml
  /// </summary>
  public partial class DragDropPage : Page
  {
    public DragDropPage()
    {
      InitializeComponent();
    }

    private void TargetGrid_DragEnter(object sender, DragEventArgs e)
    {
      TargetGrid.Background = Brushes.LightYellow;
    }

    private void TargetGrid_Drop(object sender, DragEventArgs e)
    {
      if (e.Data.GetFormats()[0] == "System.Windows.Media.SolidColorBrush")
      {
        TargetGrid.Background = Brushes.LightGray;
        Ellipse orb = new Ellipse();
        orb.Width = orb.Height = 80;

        orb.Stroke = Brushes.Gray;
        orb.StrokeThickness = 5;
        orb.Fill = e.Data.GetData(typeof(SolidColorBrush)) as SolidColorBrush;
        orb.HorizontalAlignment = HorizontalAlignment.Center;
        orb.VerticalAlignment = VerticalAlignment.Center;

        TargetGrid.Children.Add(orb);
      }
      if (e.Data.GetFormats()[0] == "Text")
      {
        var textBlock = new TextBlock();
        textBlock.TextWrapping = TextWrapping.Wrap;
        textBlock.TextAlignment = TextAlignment.Center;
        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
        textBlock.VerticalAlignment = VerticalAlignment.Center;
        textBlock.Text = e.Data.GetData(typeof(String)) as String;
        TargetGrid.Children.Add(textBlock);
      }
    }

    private void TargetGrid_DragLeave(object sender, DragEventArgs e)
    {
      TargetGrid.Background = Brushes.LightGray;
    }

    private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
    {
      var currentEllipse = sender as Ellipse;
      if (currentEllipse == null)
      {
        return;
      }
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        DataObject brushData = new DataObject(typeof(SolidColorBrush), currentEllipse.Fill as SolidColorBrush);
        DragDrop.DoDragDrop(currentEllipse, brushData, DragDropEffects.Copy);
      }
    }

    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
      var currentTextBlock = sender as TextBlock;
      if (currentTextBlock == null)
      {
        return;
      }

      if (e.LeftButton == MouseButtonState.Pressed)
      {
        DataObject textData = new DataObject(typeof(String), currentTextBlock.Text);
        DragDrop.DoDragDrop(currentTextBlock, textData, DragDropEffects.Copy);
      }
    }
  }
}