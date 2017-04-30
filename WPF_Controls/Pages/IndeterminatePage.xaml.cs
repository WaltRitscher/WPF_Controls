using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
  /// Interaction logic for InderminatePage.xaml
  /// </summary>
  public partial class IndeterminatePage : Page
  {
    public IndeterminatePage()
    {
      InitializeComponent();
      var demoColor = new ObservableCollection<ColorData>();
      demoColor.Add(new ColorData { ColorName = "Orange", IsBlue = false, IsOrange = true });
      demoColor.Add(new ColorData { ColorName = "Blue", IsBlue = true, IsOrange = false });
      demoColor.Add(new ColorData { ColorName = "BurntOrange", IsBlue = false, IsOrange = true });
      demoColor.Add(new ColorData { ColorName = "LightBlue", IsBlue = true, IsOrange = false });
      demoColor.Add(new ColorData { ColorName = "CaramelOrange", IsBlue = false, IsOrange = true });
      this.DataContext = demoColor;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      
      var items = (sender as ListBox).SelectedItems.Cast<ColorData>();

      if (items.Count()== 0)
      {
        OrangeCheckbox.IsChecked = false;
        BlueCheckbox.IsChecked = false;
        return;
      }
      if (items.All(x => x.IsBlue))
      {
        BlueCheckbox.IsChecked = true;
      }
      else if (items.All(x => x.IsOrange))
      {
        OrangeCheckbox.IsChecked = true;
      }
      else
      {
        OrangeCheckbox.IsChecked = null;
        BlueCheckbox.IsChecked = null;
      }

    }
  }
  public class ColorData
  {
    public string ColorName { get; set; }
    public bool IsBlue { get; set; }
    public bool IsOrange { get; set; }

  }
}
