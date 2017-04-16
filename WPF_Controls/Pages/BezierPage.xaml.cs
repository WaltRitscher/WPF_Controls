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
  /// Interaction logic for BezierPage.xaml
  /// </summary>
  public partial class BezierPage : Page
  {
    Random ran = new Random();
    double speed = 0.04;
    double ranX;
    double ranY;
    double ranX2;
    double ranY2;
    double ranEndX;
    double ranEndY;
    Point startPoint = new Point(120, 150);
    Point endPoint = new Point(200, 220);
    Point controlPoint1 = new Point(100, 480);
    Point controlPoint2 = new Point(600, 300);

    public BezierPage()
    {
      InitializeComponent();
      SetInitialPoints();
    }

    private void SetInitialPoints()
    {
      Canvas.SetTop(startEllipse, 100);
      Canvas.SetLeft(startEllipse, 200);
      Canvas.SetTop(endEllipse, 230);
      Canvas.SetLeft(endEllipse, 330);
      Canvas.SetLeft(cpEllipse1, startPoint.X);
      Canvas.SetLeft(cpEllipse2, endPoint.X);
      Canvas.SetTop(cpEllipse1, startPoint.Y);
      Canvas.SetTop(cpEllipse2, endPoint.Y);
    }

    protected override void OnInitialized(System.EventArgs e)
    {
      base.OnInitialized(e);
      VisualTarget.Rendering += new System.EventHandler(this.DoDraw);
      _rainbowBrush = GetRainbowBrush();
      ranX = (ran.NextDouble() * 400);
      ranY = (ran.NextDouble() * 400);
      ranX2 = Math.Max((ran.NextDouble() * 400), 200);
      ranY2 = Math.Max((ran.NextDouble() * 400), 200);
      ranEndX = (ran.NextDouble() * 400);
      ranEndY = (ran.NextDouble() * 400);
    }
    private LinearGradientBrush GetRainbowBrush()
    {
      LinearGradientBrush rainbowBrush = new LinearGradientBrush()
      {
        StartPoint = new Point(ran.Next(0, 3), ran.Next(0, 4)),
        EndPoint = new Point(ran.Next(0, 3), ran.Next(0, 4))
      };
      rainbowBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
      rainbowBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
      rainbowBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
      rainbowBrush.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));
      return rainbowBrush;
    }

    private void MovePoints()
    {
      if ((Math.Abs((Canvas.GetLeft(cpEllipse1) - ranX)) < 0.1))
      {
        ranX = (ran.NextDouble() * this.ActualWidth / 1.5);
        ranY = (ran.NextDouble() * this.ActualHeight / 1.5);
        ranX2 = Math.Max((ran.NextDouble() * this.ActualWidth / 1.5), 200);
        ranY2 = Math.Max((ran.NextDouble() * this.ActualHeight / 1.5), 200);
        ranEndX = (ran.NextDouble() * this.ActualWidth / 1.5);
        ranEndY = (ran.NextDouble() * this.ActualHeight / 1.5);
      }
      Canvas.SetLeft(startEllipse, (Canvas.GetLeft(startEllipse)
                      + ((ranX - Canvas.GetLeft(startEllipse))
                      * speed)));
      Canvas.SetTop(startEllipse, (Canvas.GetTop(startEllipse)
                      + ((ranX - Canvas.GetTop(startEllipse))
                      * speed)));

      Canvas.SetLeft(endEllipse, (Canvas.GetLeft(endEllipse)
                     + ((ranEndX - Canvas.GetLeft(endEllipse))
                     * speed)));
      Canvas.SetTop(endEllipse, (Canvas.GetTop(endEllipse)
                      + ((ranEndY - Canvas.GetTop(endEllipse))
                      * speed)));
      Canvas.SetLeft(cpEllipse1, (Canvas.GetLeft(cpEllipse1)
                      + ((ranX - Canvas.GetLeft(cpEllipse1))
                      * speed)));
      Canvas.SetTop(cpEllipse1, (Canvas.GetTop(cpEllipse1)
                      + ((ranY - Canvas.GetTop(cpEllipse1))
                      * speed)));
      Canvas.SetLeft(cpEllipse2, (Canvas.GetLeft(cpEllipse2)
                      + ((ranX2 - Canvas.GetLeft(cpEllipse2))
                      * speed)));
      Canvas.SetTop(cpEllipse2, (Canvas.GetTop(cpEllipse2)
                      + ((ranY2 - Canvas.GetTop(cpEllipse2))
                      * speed)));
    }

    Int32 brushCounter = 0;
    LinearGradientBrush _rainbowBrush;
    public void DoDraw(object sender, EventArgs e)
    {
      
      brushCounter = brushCounter > 400 ? 0 : ++brushCounter;
      //  Create a Path to be drawn to the screen.
      System.Windows.Shapes.Path path1 = new System.Windows.Shapes.Path()
      {
        // rainbowBrush = (brushCounter == 1) ? GetRainbowBrush() : rainbowBrush;
        //_rainbowBrush = GetRainbowBrush();
        Stroke = _rainbowBrush,
        StrokeThickness = 40,
        StrokeEndLineCap = PenLineCap.Round,
        StrokeStartLineCap = PenLineCap.Round
      };
      SolidColorBrush mySolidColorBrush = new SolidColorBrush()
      {
        Color = Color.FromArgb(255, 204, 204, 255)
      };
      PathGeometry pGeometry = new PathGeometry();
      PathFigureCollection pFigureCollection = new PathFigureCollection();
      PathFigure pFigure = new PathFigure()
      {
        StartPoint = new Point(Canvas.GetLeft(startEllipse), Canvas.GetTop(startEllipse))
      };
      PathSegmentCollection pSegCollection = new PathSegmentCollection();
      Point bezControl1 = new Point(Canvas.GetLeft(cpEllipse1), Canvas.GetTop(cpEllipse1));
      Point bezControl2 = new Point(Canvas.GetLeft(cpEllipse2), Canvas.GetTop(cpEllipse2));
      Point bezEndPoint = new Point(Canvas.GetLeft(endEllipse), Canvas.GetTop(endEllipse));
      BezierSegment bs = new BezierSegment(bezControl1, bezControl2, bezEndPoint, true);
      pSegCollection.Insert(0, bs);
      pFigure.Segments = pSegCollection;
      pFigureCollection.Insert(0, pFigure);
      pGeometry.Figures = pFigureCollection;
      path1.Data = pGeometry;
      mainGrid.Children.Clear();
      mainGrid.Children.Add(path1);
      MovePoints();
      

    }


  }
}
