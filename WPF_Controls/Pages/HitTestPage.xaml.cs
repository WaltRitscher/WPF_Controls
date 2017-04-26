using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfControls.Pages
{
  /// <summary>
  /// Interaction logic for HitTestPage.xaml
  /// </summary>
  public partial class HitTestPage : Page
  {
    public HitTestPage()
    {
      InitializeComponent();

      Poly1.Loaded += Poly1_Loaded;
    }

    private void Poly1_Loaded(object sender, RoutedEventArgs e)
    {
      Poly1.ToolTip = $"Area size for Poly1: {Poly1.RenderedGeometry.GetArea()}";
    }

    private void Poly1_MouseMove(object sender, MouseEventArgs e)
    {
      // check whehter the mouse pointer is in the stroke or fill portion of shape
      var point = e.GetPosition(Poly1);
      if (Poly1.RenderedGeometry.FillContains(point))
      {
        Poly1.Fill = Brushes.Orange;
      }
      else
      {
        Poly1.Fill = Brushes.SteelBlue;
      }
      var pen = GetPenFromStroke(Poly1);
      if (Poly1.RenderedGeometry.StrokeContains(pen, point))
      {
        Poly1.Stroke = Brushes.Coral;
      }
      else
      {
        Poly1.Stroke = Brushes.LightSeaGreen;
      }
    }

    private void Poly1_MouseLeave(object sender, MouseEventArgs e)
    {
      Poly1.Fill = Brushes.SteelBlue;
      Poly1.Stroke = Brushes.Gray;
    }

    public static Pen GetPenFromStroke(Shape shape)
    {
      return new Pen()
      {
        Brush = shape.Stroke,
        Thickness = shape.StrokeThickness,
        DashCap = shape.StrokeDashCap,
        DashStyle = new DashStyle()
        {
          Dashes = shape.StrokeDashArray,
          Offset = shape.StrokeDashOffset
        },
        StartLineCap = shape.StrokeStartLineCap,
        EndLineCap = shape.StrokeEndLineCap,
        LineJoin = shape.StrokeLineJoin,
        MiterLimit = shape.StrokeMiterLimit
      };
    }
  }
}