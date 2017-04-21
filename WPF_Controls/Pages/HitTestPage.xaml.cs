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
  /// Interaction logic for HitTestPage.xaml
  /// </summary>
  public partial class HitTestPage : Page
  {
    public HitTestPage()
    {
      InitializeComponent();
    }

    private void Grid2_MouseUp(object sender, MouseButtonEventArgs e)
    {
      Message1.Text = Message1.Text + ".";
    }

    private void Grid5_MouseUp(object sender, MouseButtonEventArgs e)
    {
      Message2.Text = Message2.Text + ".";
    }
  }
}
