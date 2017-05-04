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
      var openDialog = new Microsoft.Win32.OpenFileDialog();
      openDialog.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
      var exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      openDialog.InitialDirectory = Directory.GetParent(Directory.GetParent(exePath).ToString()).ToString();
      if (openDialog.ShowDialog() == true)
      {

        //FileStream xamlFile = System.IO.File.Open(String.Format(openDialog.FileName), FileMode.Open);
        //MainRichText.Document = (FlowDocument)XamlReader.Load(xamlFile);

      // Create a TextRange around the entire document.
                TextRange documentTextRange = new TextRange(
                    MainRichText.Document.ContentStart, MainRichText.Document.ContentEnd);

        using (FileStream fs = File.Open(openDialog.FileName, FileMode.Open))
        {
          if (System.IO.Path.GetExtension(openDialog.FileName).ToLower() == ".rtf")
          {
            documentTextRange.Load(fs, DataFormats.Rtf);
          }
          else
          {
            documentTextRange.Load(fs, DataFormats.Xaml);
          }
        }
      }
    }

    private void SaveFileButton_Click(object sender, RoutedEventArgs e)
    {
      var saveDialog = new SaveFileDialog();
      saveDialog.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
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
    private void Test()
    {
      //// from the Microsoft sample
      //var contentToSave = MainRichText.Document;

      //if (DoesDocumentContainUIElements())
      //{
      //  MessageBox.Show("Saving documents with UIElements is not supported");
      //  return;
      //}

      //var dialog = new SaveFileDialog();
      //dialog.DefaultExt = ".sav";
      //dialog.Filter = "Saved Files|*.sav|All Files|*.*";

      //if (dialog.ShowDialog() == true)
      //{
      //  using (var fs = (FileStream)dialog.OpenFile())
      //  {
      //    var enc = new System.Text.UTF8Encoding();
      //    byte[] buffer = enc.GetBytes(contentToSave);
      //    fs.Write(buffer, 0, buffer.Length);
      //    fs.Close();
      //  }
      //}
    }
    private bool DoesDocumentContainUIElements()
    {
      //Check if the file contains any UIElements
      var q = from block in MainRichText.Document.Blocks
              from inline in (block as Paragraph).Inlines
              where inline.GetType() == typeof(InlineUIContainer)
              select inline;

      //If the file contains any UIElements, it will not be saved
      return q.Count() != 0;

    }
  }
}
