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
  /// Interaction logic for Template1Page.xaml
  /// </summary>
  public partial class Template1Page : Page
  {
    public Template1Page()
    {
      InitializeComponent();
		
    }

		

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

			if ( SizableEllipse != null)
			{
				SizableEllipse.Width = (sender as Slider).Value;

			}
		
		}
	}
}
