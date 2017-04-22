using System.Windows.Controls;
using System.Windows.Input;

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