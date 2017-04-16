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
  /// Interaction logic for Page1.xaml
  /// </summary>
  public partial class ImageEditorPage : Page
  {
    public ImageEditorPage()
    {
      InitializeComponent();
      this.Loaded += MainWindow_Loaded;
      mainImage.MouseMove += MainImage_MouseMove;
    }
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      mainImage.MouseMove += MainImage_MouseMove;
    }
    private void MainImage_MouseMove(object sender, MouseEventArgs e)
    {

      
      {
        lineX.Visibility = Visibility.Visible;
        lineY.Visibility = Visibility.Visible;
      }



      var positionString = String.Format("{0:#000} - {1:#000}",
                                          e.GetPosition(mainImage).X,
                                          e.GetPosition(mainImage).Y);
      PostionTextBlock.Text = positionString;


      #region lineX
      lineX.X1 = 0;
      lineX.Y1 = e.GetPosition(mainImage).Y;

      lineX.X2 = mainImage.ActualWidth;
      lineX.Y2 = lineX.Y1;
      #endregion
      #region lineY

      {

      }

      lineY.X1 = e.GetPosition(this).X;
      lineY.Y1 = 0;

      lineY.X2 = lineY.X1;
      lineY.Y2 = mainImage.ActualHeight;


      #endregion


    }

     private void ColorToneMenu_Click(object sender, RoutedEventArgs e)
    {
     
      var effect = new PixelSmith.Effects.ColorToneEffect()
      {
        DarkColor = Colors.Orange,
        LightColor = Colors.AliceBlue
      };
      mainImage.Effect = effect;
    }

    private void ToonMenu_Click(object sender, RoutedEventArgs e)
    {
      
      var effect = new PixelSmith.Effects.ToonShaderEffect()
      {
        Levels = 5
      };
      mainImage.Effect = effect;
    }

    private void MonochromeMenu_Click(object sender, RoutedEventArgs e)
    {
    
      var effect = new PixelSmith.Effects.MonochromeEffect();

      effect.FilterColor = Colors.Tan;

      mainImage.Effect = effect;
    }

    private void NoEffectMenu_Click(object sender, RoutedEventArgs e) 
    {
      mainImage.Effect = null;
    }
  }
}
