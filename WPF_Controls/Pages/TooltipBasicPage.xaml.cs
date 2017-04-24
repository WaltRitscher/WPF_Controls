using System;
using System.Windows.Controls;

namespace WpfControls.Pages
{
  public partial class TooltipBasicPage : Page
  {
    public TooltipBasicPage()
    {
      InitializeComponent();
    }

    private void Image_ToolTipOpening(object sender, ToolTipEventArgs e)
    {
      var currentImage = sender as Image;
      if (currentImage!= null)
      {
        currentImage.ToolTip = $"This tooltip created at {DateTime.Now.ToLongTimeString()}";
      }
    }
  }
}