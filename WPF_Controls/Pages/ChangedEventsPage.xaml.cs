using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for ChangedEventsPage.xaml
  /// </summary>
  public partial class ChangedEventsPage : Page
  {
    public ChangedEventsPage()
    {
      InitializeComponent();
      this.Loaded += Page_Loaded;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      TextChangedTextBox.TextChanged += TextChangedTextBox_TextChanged;
      passwordEvalBox.TextChanged += Password_TextChanged;
    }

  

    private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
      if (String.IsNullOrEmpty(MainTextBox.SelectedText))
      {
        return;
      }
      SelectionChangedTextBlock.Text = MainTextBox.SelectedText;
    }

  

    private void TextChangedTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      var fullText = (sender as TextBox).Text;
      if (e.Changes.Any())
      {
        addedTextBlock.Text = (e.Changes.Last().AddedLength.ToString());

        offsetTextBlock.Text = (e.Changes.Last().Offset.ToString());

        removedTextBlock.Text = (e.Changes.Last().RemovedLength.ToString());
     
      }
    }

    private void Password_TextChanged(object sender, TextChangedEventArgs e)
    {
      var count = passwordEvalBox.Text.Count();

      theTransform.X = Math.Min(count * 10, 290);

      if (count > 8)
      {
        messageTextBlock.Text = "Weak";
      }
      if (count > 12)
      {
        messageTextBlock.Text = "Good";
      }
      if (count > 20)
      {
        messageTextBlock.Text = "Strong";
      }

      if (count > 28)
      {
        messageTextBlock.Text = "Very Strong";
      }
    }
  }
}