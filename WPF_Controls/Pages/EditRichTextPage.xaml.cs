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
  /// Interaction logic for EditRichTextPage.xaml
  /// </summary>
  public partial class EditRichTextPage : Page
  {
    public EditRichTextPage()
    {
      InitializeComponent();
    }



    private void BoldButton_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(MainRichTextBox.Selection.Text))
      {
        return;
      }
      var sel = MainRichTextBox.Selection;
      sel.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Bold);

    }


    private void ItalicButton_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(MainRichTextBox.Selection.Text))
      {
        return;
      }
      var sel = MainRichTextBox.Selection;
      sel.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Italic);
    }



    private void FontPlusButton_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(MainRichTextBox.Selection.Text))
      {
        return;
      }
      var sel = MainRichTextBox.Selection;
      double currentSize = (double)sel.GetPropertyValue(RichTextBox.FontSizeProperty);
      sel.ApplyPropertyValue(RichTextBox.FontSizeProperty, currentSize + 4);
    }

    private void FontMinusButton_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(MainRichTextBox.Selection.Text))
      {
        return;
      }
      var sel = MainRichTextBox.Selection;
      double currentSize = (double)sel.GetPropertyValue(RichTextBox.FontSizeProperty);
      sel.ApplyPropertyValue(RichTextBox.FontSizeProperty, currentSize - 4);
    }

    private void ColorButton_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(MainRichTextBox.Selection.Text))
      {
        return;
      }
      var sel = MainRichTextBox.Selection;
      sel.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.DarkOrange);
    }
  }
}
