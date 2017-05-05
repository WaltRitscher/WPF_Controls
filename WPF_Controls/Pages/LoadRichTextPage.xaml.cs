using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for LoadRichTextPage.xaml
  /// </summary>
  public partial class LoadRichTextPage : Page
  {
    public LoadRichTextPage()
    {
      InitializeComponent();
    }

    private void ChooseFileButton_Click(object sender, RoutedEventArgs e)
    {
      //MainFlowViewer.Document = null;
      //MainRichText.Document = null;
      var openDialog = new Microsoft.Win32.OpenFileDialog();
      openDialog.Filter = "RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All Files (*.*)|*.*";
      var exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      openDialog.InitialDirectory = Directory.GetParent(Directory.GetParent(exePath).ToString()).ToString();
      if (openDialog.ShowDialog() == true)
      {



        // Create a TextRange around the entire document.
        TextRange docTextRange = new TextRange(MainRichText.Document.ContentStart, MainRichText.Document.ContentEnd);


        using (FileStream fs = File.Open(openDialog.FileName, FileMode.Open))
        {
          if (System.IO.Path.GetExtension(openDialog.FileName).ToLower() == ".rtf")
          {
            docTextRange.Load(fs, DataFormats.Rtf);

          }
          else
          {
            docTextRange.Load(fs, DataFormats.Xaml);
          }

          _flowDoc = MainRichText.Document;
        }
      }
    }

    private void SaveFileButton_Click(object sender, RoutedEventArgs e)
    {
      var saveDialog = new SaveFileDialog();
      saveDialog.Filter = "RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All Files (*.*)|*.*";
      var exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      saveDialog.InitialDirectory = Directory.GetParent(exePath).ToString();
      if (saveDialog.ShowDialog() == true)
      {
        // Create a TextRange around the entire document.
        TextRange documentTextRange = new TextRange(
            MainRichText.Document.ContentStart, MainRichText.Document.ContentEnd);

        // If this file exists, it's overwritten.
        using (FileStream fs = File.Create(saveDialog.FileName))
        {
          if (System.IO.Path.GetExtension(saveDialog.FileName).ToLower() == ".rtf")
          {
            documentTextRange.Save(fs, DataFormats.Rtf);
          }
          else
          {
            documentTextRange.Save(fs, DataFormats.Xaml);
          }
        }
      }


    }

    private FlowDocument _flowDoc;
    private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (_flowDoc==null)
      {
        return;
      }
      switch (MainTabControl.SelectedIndex)
      {
        case 0:
          MainFlowViewer.Document = new FlowDocument(); 
          MainRichText.Document = _flowDoc;
          break;
        case 1:
          MainRichText.Document = new FlowDocument();
          MainFlowViewer.Document = _flowDoc;
          break;
        default:
          break;
      }
    }
  }
}
