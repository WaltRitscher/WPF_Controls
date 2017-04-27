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
      Message1TextBlock.Text= $"Area size for Poly1: {Poly1.RenderedGeometry.GetArea()}";
			Message2TextBlock.Text = $"Area size for AbstractPath: {AbstractPath.RenderedGeometry.GetArea()}";
			_firstColor = AbstractGradientBrush.GradientStops[0].Color;
			_secondColor = AbstractGradientBrush.GradientStops[1].Color;
		}

    private void Poly1_MouseMove(object sender, MouseEventArgs e)
    {
      // check whether the mouse pointer is in the strokeportion of shape
      var point = e.GetPosition(Poly1);
     
      var pen = GetPenFromStroke(Poly1);
      if (Poly1.RenderedGeometry.StrokeContains(pen, point))
      {
        Poly1.Stroke = Brushes.Coral;
      }
      else
      {
        Poly1.Stroke = Brushes.Gray;
      }
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
		private Color _firstColor;
		private Color _secondColor;
		private void AbstractPath_MouseMove(object sender, MouseEventArgs e)
		{
			
			// check whether the mouse pointer is in the strokeportion of shape
			var point = e.GetPosition(AbstractPath);

			var pen = GetPenFromStroke(AbstractPath);
			if (AbstractPath.RenderedGeometry.StrokeContains(pen, point))
			{
				AbstractGradientBrush.GradientStops[0].Color = Colors.Orange;
				AbstractGradientBrush.GradientStops[1].Color = Colors.Purple;

			}
			else
			{
				AbstractGradientBrush.GradientStops[0].Color = _firstColor;
				AbstractGradientBrush.GradientStops[1].Color = _secondColor;
			}
		}

		private void Poly1_MouseLeave(object sender, MouseEventArgs e)
		{
			Poly1.Stroke = Brushes.Gray;
		}

		private void AbstractPath_MouseLeave(object sender, MouseEventArgs e)
		{
			AbstractGradientBrush.GradientStops[0].Color = _firstColor;
			AbstractGradientBrush.GradientStops[1].Color = _secondColor;
		}
	}
}