using Course.Shell;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace WpfControls
{
  public partial class AutoFillTreeView : UserControl
  {
    public AutoFillTreeView()
    {
      InitializeComponent();
      LoadXmlData();
      this.MouseLeftButtonUp += new MouseButtonEventHandler(TreeView_MouseLeftButtonUp);
      this.Loaded += new RoutedEventHandler(UserControl_Loaded);
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      TreeViewItem tvi;
      foreach (var item in InnerTreeView.Items)
      {
        tvi = InnerTreeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
        tvi.IsExpanded = true;
      }
    }

    public XmlMenu GetFirstMenu()
    {
      if (InnerTreeView.Items.Count > 0)
      {
        if (InnerTreeView.Items[0] is XmlCategory category)
        {
          if (category.Menus[0] is XmlMenu menu)
          {
            return menu;
          }
        }
      }
      return null;
    }

    #region Events

    public event RoutedPropertyChangedEventHandler<object> SelectedAutoTreeItemChanged;

    protected virtual void OnSelectedAutoTreeItemChanged(object oldItem, object newItem)
    {
      var handler = SelectedAutoTreeItemChanged;
      if (handler != null)
      {
        RoutedPropertyChangedEventArgs<object> args =
            new RoutedPropertyChangedEventArgs<object>(newItem, newItem);

        try
        {
          handler(this, args);
        }
        catch
        { }
      }
    }

    #endregion Events

    private void TreeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      var xe = InnerTreeView.SelectedItem as XmlMenu;
      if (xe != null)
      {
        OnSelectedAutoTreeItemChanged(null, xe);
      }
    }

    public void LoadXmlData()
    {
      List<XmlCategory> categories = new List<XmlCategory>();
      if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
      {
        return;
      }
      XDocument categoriesXML = XDocument.Load("menu.xml");

      categories = this.GetCategories(categoriesXML.Element("menus"));
      this.InnerTreeView.ItemsSource = categories;
    }

    private List<XmlCategory> GetCategories(XElement element)
    {
      return (from category in element.Elements("category")
              select new XmlCategory()
              {
                CategoryName = category.Attribute("categoryName").Value,
                Menus = GetMenus(category)
              }).ToList();
    }

    private List<XmlMenu> GetMenus(XElement element)
    {
      return (from menu in element.Elements("menu")
              select new XmlMenu()
              {
                Header = menu.Attribute("header").Value,
                Page = menu.Attribute("page").Value
              }).ToList();
    }
  }
}