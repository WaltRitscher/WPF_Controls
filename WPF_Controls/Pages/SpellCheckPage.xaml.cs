using System;
using System.Collections;
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
  /// Interaction logic for SpellCheckPage.xaml
  /// </summary>
  public partial class SpellCheckPage : Page
  {
    public SpellCheckPage()
    {
      InitializeComponent();

    }



    private void SpellCheckButton_Checked(object sender, RoutedEventArgs e)
    {
      MainTextBox.SpellCheck.IsEnabled = true;
    }

    private void SpellCheckButton_Unchecked(object sender, RoutedEventArgs e)
    {
      MainTextBox.SpellCheck.IsEnabled = false;
    }

    private void DictionaryButton_Checked(object sender, RoutedEventArgs e)
    {

      var uri = new Uri(@"pack://application:,,,/WpfControls;component/Dictionaries/LastNames.lex");

      IList dictionaries = SpellCheck.GetCustomDictionaries(MainTextBox);

      dictionaries.Add(uri);
    }

    private void DictionaryButton_Unchecked(object sender, RoutedEventArgs e)
    {
      SpellCheck.GetCustomDictionaries(MainTextBox).RemoveAt(0);
    }
  }
}
