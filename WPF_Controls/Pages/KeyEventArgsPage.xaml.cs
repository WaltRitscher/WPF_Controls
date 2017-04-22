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
  /// Interaction logic for KeyEventArgsPage.xaml
  /// </summary>
  public partial class KeyEventArgsPage : Page
  {
    public KeyEventArgsPage()
    {
      InitializeComponent();
    }

    private ObservableCollection<TextChange> _additions = new ObservableCollection<TextChange>();
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      try
      {
        var fullText = (sender as TextBox).Text;
        if (e.Changes.Any())
        {
          Console.WriteLine(e.Changes.Count);
          var lastChanges = e.Changes.Last();
          addedTextBlock.Text = (lastChanges.AddedLength.ToString());

          offsetTextBlock.Text = (lastChanges.Offset.ToString());

          removedTextBlock.Text = (lastChanges.RemovedLength.ToString());


        }
      }
      catch (Exception)
      {

        // ignore;
      }
     

    }
  }
}
