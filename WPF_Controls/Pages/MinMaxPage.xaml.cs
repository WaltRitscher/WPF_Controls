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
  /// Interaction logic for MinMaxPage.xaml
  /// </summary>
  public partial class MinMaxPage : Page
  {
    public MinMaxPage()
    {
      InitializeComponent();
    }
    private string _sourceText = "The quick onyx goblin jumps over the lazy dwarf. Jinxed wizards pluck ivy from the big quilt.";
    private int _counter = 10;
    private void AddLetters_Click(object sender, RoutedEventArgs e)
    {
      _counter += 10;
      Button1.Content = Button2.Content = _sourceText.Substring(0, Math.Min(_counter, _sourceText.Length));

    }

    private void RemoveLetters_Click(object sender, RoutedEventArgs e)
    {
      _counter -= 10;
      Button1.Content = Button2.Content = _sourceText.Substring(0, Math.Max(_counter, 0));
    }
  }
}
