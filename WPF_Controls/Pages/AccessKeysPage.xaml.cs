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
  /// Interaction logic for AccessKeys.xaml
  /// </summary>
  public partial class AccessKeysPage : Page
  {
    public AccessKeysPage()
    {
      InitializeComponent();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      MessageTextBlock.Text = "Activated the Save button";
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
      MessageTextBlock.Text = "Activated the OK button";
    }

    private void AccessButton_Click(object sender, RoutedEventArgs e)
    {
      MessageTextBlock.Text = "Activated the First button";
    }
  }
}
