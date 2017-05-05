using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
	/// Interaction logic for MethodsPage.xaml
	/// </summary>
	public partial class MethodsPage : Page
	{
		public MethodsPage()
		{
			InitializeComponent();
		}

    private void ShortButton_Checked(object sender, RoutedEventArgs e)
    {
      MainTextBox.Height = 140;
      MainTextBox.Width = 180;
    }

    private void ShortButton_Unchecked(object sender, RoutedEventArgs e)
    {
      MainTextBox.Height = double.NaN;
      MainTextBox.Width = double.NaN;
    }

   
    private void ScrollEndButton_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.ScrollToEnd();

    }

    private void ScrollHomeButton_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.ScrollToHome();
    }

    

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.Clear();
    }

    private void AppendText_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.AppendText(" [Live Text, added in the demo.]");
    }

    private void LineUpButton_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.LineUp();
    }

    private void LineDownButton_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.LineDown();
    }

    private void UndoButton_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.Undo();
    }

    private void RedoButton_Click(object sender, RoutedEventArgs e)
    {
      MainTextBox.Redo();
    }

    private void BeginButton_Click(object sender, RoutedEventArgs e)
    {
     

      // Begin the change block. Once BeginChange() is called
      // no text content or selection change events will be raised 
      // until EndChange is called. Also, all edits made within
      // a BeginChange/EndChange block are wrapped in a single undo block.
      MainTextBox.BeginChange();

     

      // Change one
      
      MainTextBox.Text =  MainTextBox.Text.Insert(0, "[Add Text at the Start] \n");

      // change two
      MainTextBox.Text = MainTextBox.Text.Replace("Sally", "[Minako]");

      // Change three
      MainTextBox.AppendText("[Append text] ");

      // Whenever BeginChange() is called EndChange() must also be
      // called to end the change block.
      MainTextBox.EndChange();
    }

  }
}
