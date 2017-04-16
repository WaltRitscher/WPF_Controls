using Course.Shell;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfControls
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      DemoName.Text = AutoTree.GetFirstMenu().Header;
      ContentFrame.Navigate(new Uri(AutoTree.GetFirstMenu().Page, UriKind.RelativeOrAbsolute)); AutoTree.GetFirstMenu();
    }

    private void AutoTree_SelectedAutoTreeItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      SetupViewer(e);
      DemoName.Text = (e.NewValue as XmlMenu).Header;
    }

    private void SetupViewer(RoutedPropertyChangedEventArgs<object> e)
    {
      this.LoadedControlTitle.Text = string.Empty;
      try
      {
        var menuDetails = e.NewValue as XmlMenu;
        ContentFrame.Navigate(new Uri(menuDetails.Page, UriKind.RelativeOrAbsolute));

        MainTab.Items.Remove(FileTab);
        MainTab.Items.Insert(MainTab.Items.Count, FileTab);
        FileIndexStackPanel.Children.Clear();

        AddFileIndex("Demo:", menuDetails.Page);
        // SetupXamlTab(menuDetails);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void AddFileIndex(string headText, string filePath)
    {
      TextBlock header = new TextBlock();
      header.Text = headText;
      header.FontWeight = FontWeights.Bold;
      header.Foreground = new SolidColorBrush(Colors.DarkGray);

      var stackLayout = new StackPanel();
      stackLayout.Margin = new Thickness(3);
      stackLayout.Orientation = Orientation.Horizontal;

      TextBlock fileTextBlock = new TextBlock();
      fileTextBlock.Margin = new Thickness(10, 3, 0, 3);
      fileTextBlock.Text = filePath;
      FileIndexStackPanel.Children.Add(header);
      FileIndexStackPanel.Children.Add(stackLayout);
      stackLayout.Children.Add(fileTextBlock);
    }

    private void ContentFrame_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
    {
      e.Handled = true;
    }
  }
}