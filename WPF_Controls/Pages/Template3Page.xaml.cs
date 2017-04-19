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
  /// Interaction logic for Templates3Page.xaml
  /// </summary>
  public partial class Template3Page : Page
  {
    public Template3Page()
    {
      InitializeComponent();
    }
    private string _dots = ".";
    private void Button_Click(object sender, RoutedEventArgs e)
    {

      MessageTextBlock.Text = $"Clicked the templated button {_dots}";
      _dots += ".";
    }
  }
}
