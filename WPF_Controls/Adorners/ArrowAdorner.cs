using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfControls.Adorners
{
  class ArrowAdorner : Adorner
  {
    public ArrowAdorner(UIElement adornedElement) : base(adornedElement)
    {
    }
    protected override void OnRender(
     System.Windows.Media.DrawingContext drawingContext)
    {
      SolidColorBrush grayBrush = new SolidColorBrush();
      grayBrush.Color = Color.FromRgb(153, 153, 153);

     
      Typeface typeFace = new Typeface("Segoe UI Symbol");
      FormattedText UpperLeftText = new FormattedText(textToFormat: "↖",
                                                      culture: Thread.CurrentThread.CurrentCulture,
                                                      flowDirection: FlowDirection.LeftToRight,
                                                      typeface: typeFace,
                                                      emSize: 14.0,
                                                      foreground: new SolidColorBrush(Colors.DarkOrange));
      FormattedText UpperRightText = new FormattedText(textToFormat: "↗",
                                                      culture: Thread.CurrentThread.CurrentCulture,
                                                      flowDirection: FlowDirection.LeftToRight,
                                                      typeface: typeFace,
                                                      emSize: 14.0,
                                                      foreground: new SolidColorBrush(Colors.DarkOrange));
      FormattedText LowerLeftText = new FormattedText(textToFormat: "↙",
                                                      culture: Thread.CurrentThread.CurrentCulture,
                                                      flowDirection: FlowDirection.LeftToRight,
                                                      typeface: typeFace,
                                                      emSize: 14.0,
                                                      foreground: new SolidColorBrush(Colors.DarkOrange));
      FormattedText LowerRightText = new FormattedText(textToFormat: "↘",
                                                      culture: Thread.CurrentThread.CurrentCulture,
                                                      flowDirection: FlowDirection.LeftToRight,
                                                      typeface: typeFace,
                                                      emSize: 14.0,
                                                      foreground: new SolidColorBrush(Colors.DarkOrange));
      FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
      double offset = 16;
      double offsetLeft = 9;
      drawingContext.DrawText(UpperLeftText, new Point(-offsetLeft, -offset));
      drawingContext.DrawText(UpperRightText, new Point(adornedElement.ActualWidth, - offset));
      drawingContext.DrawText(LowerLeftText, new Point(-offsetLeft, adornedElement.ActualHeight));
      drawingContext.DrawText(LowerRightText, new Point(adornedElement.ActualWidth, adornedElement.ActualHeight));

    }
  }
}
