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
	/// Interaction logic for PasswordPage.xaml
	/// </summary>
	public partial class PasswordPage : Page
	{
		public PasswordPage()
		{
			InitializeComponent();
		}

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var pwd = passwordBox1.Password;

      // note, Password property is read/write.

      // The password value is return as normal string.
      // the backing Type used for Password value is SecureString
    }
  }
}
