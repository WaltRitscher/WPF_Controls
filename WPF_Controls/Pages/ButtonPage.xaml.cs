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
  /// Interaction logic for ButtonPage.xaml
  /// </summary>
  public partial class ButtonPage : Page
  {
    public ButtonPage()
    {
      InitializeComponent();
    }
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ContentMessageTextBlock.Text = $"Clicked on Button content: {DateTime.Now.Second}";
		}
		private void OpenButton_Click(object sender, RoutedEventArgs e)
    {
      // RoutedEventArgs 

      ClearMessages();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      ClearMessages();
      ClickEventMessageTextBlock.Text = $"Save Button, Click {DateTime.Now.Second}";
    }

    private void All_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      ClearMessages();
      MouseMessageTextBlock.Text = $"Mouse Up {DateTime.Now.Second}";
    }

    private void All_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      ClearMessages();
      MouseMessageTextBlock.Text = $"Mouse Up {DateTime.Now.Second}";
    }

    private void ClearMessages()
    {
      ClickEventMessageTextBlock.Text = string.Empty;
      MouseMessageTextBlock.Text = String.Empty;
      TouchEventMessageTextBlock.Text = string.Empty;
      
    }

    private void All_TouchDown(object sender, TouchEventArgs e)
    {
      ClearMessages();
      TouchEventMessageTextBlock.Text = $"Touch Down {DateTime.Now.Second}";
    }

    private void All_TouchUp(object sender, TouchEventArgs e)
    {
      ClearMessages();
      TouchEventMessageTextBlock.Text = $"Touch Up {DateTime.Now.Second}";
    }

		
	}
}
