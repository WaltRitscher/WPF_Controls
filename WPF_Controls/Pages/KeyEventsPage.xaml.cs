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
  /// Interaction logic for KeyEventsPage.xaml
  /// </summary>
  public partial class KeyEventsPage : Page
  {
    public KeyEventsPage()
    {
      InitializeComponent();
    }

    private void PasswordEvalBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      var count = PasswordEvalBox.Text.Count();

      MoveTransform.X = Math.Min(count * 10, 290);

      if (count < 8)
      {
        MessageTextBlock.Text = "Very Weak";
      }
      if (count > 8)
      {
        MessageTextBlock.Text = "Weak";
      }
      if (count > 12)
      {
        MessageTextBlock.Text = "Good";
      }
      if (count > 20)
      {
        MessageTextBlock.Text = "Strong";
      }

      if (count > 28)
      {
        MessageTextBlock.Text = "Very Strong";
      }
    }
  }
}