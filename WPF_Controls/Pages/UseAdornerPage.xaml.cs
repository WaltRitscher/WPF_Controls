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
using WpfControls.Adorners;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for UseAdornerPage.xaml
  /// </summary>
  public partial class UseAdornerPage : Page
  {
    public UseAdornerPage()
    {
      InitializeComponent();
      this.Loaded += new RoutedEventHandler(Page_Loaded);

    }
    private AdornerLayer _parentLayer;
    private Adorner _rectAdorner;
    void Page_Loaded(object sender, RoutedEventArgs e)
    {

      _parentLayer = AdornerLayer.GetAdornerLayer(MainGrid);
      _rectAdorner = new Adorners.ResizeAdorner(Rect1);
    }

  

    private void Rect1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      e.Handled = true;
			if (_parentLayer.GetAdorners(Rect1) == null)
			{
				 _parentLayer.Add(_rectAdorner);
			}
     
    }

    private void MainGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      _parentLayer.Remove(_rectAdorner);
    }
  }
}
