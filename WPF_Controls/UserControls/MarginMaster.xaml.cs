using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfControls.UserControls
{
  /// <summary>
  /// Interaction logic for MarginMaster.xaml
  /// </summary>
  public partial class MarginMaster : UserControl
  {
    public MarginMaster()
    {
      InitializeComponent();
      this.SizeChanged += MarginMaster_SizeChanged;
      this.Loaded += MarginMaster_Loaded;
    }

    private void MarginMaster_Loaded(object sender, RoutedEventArgs e)
    {
      MarginHighlighter.Fill = this.Background;
      _originalY = MarginTranslateTransform.Y;
    }

    private void MarginMaster_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      MarginHighlighter.Width = this.ActualWidth;
      MarginHighlighter.Height = this.ActualWidth;
    }

    private const double MARGIN_SET =10.0;

    private double _originalY;

    private void TopPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      this.Margin = new Thickness(this.Margin.Left, this.Margin.Top + MARGIN_SET, this.Margin.Right, this.Margin.Bottom);
      TopMessage.Text = this.Margin.Top.ToString() + "px";

      UpdateTransforms();
    }

    

    private void BottomPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      this.Margin = new Thickness(this.Margin.Left, this.Margin.Top, this.Margin.Right, this.Margin.Bottom + MARGIN_SET);
      BottomMessage.Text = this.Margin.Bottom.ToString() + "px";
      UpdateTransforms();
     
    }


    private void LeftPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      this.Margin = new Thickness(this.Margin.Left + MARGIN_SET, this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
      LeftMessage.Text = this.Margin.Left.ToString() + "px";

      UpdateTransforms();
    }

    private void RightPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      this.Margin = new Thickness(this.Margin.Left, this.Margin.Top, this.Margin.Right + MARGIN_SET, this.Margin.Bottom);
      RightMessage.Text = this.Margin.Right.ToString() + "px";
     

      UpdateTransforms();
    }


    private void UpdateTransforms()
    {
      var scaleFactorY = (this.ActualHeight + this.Margin.Top + this.Margin.Bottom) / this.ActualHeight;
      MarginTranslateTransform.Y = -(this.Margin.Top - this.Margin.Bottom) / (scaleFactorY * 2);

      MarginScaleTransform.ScaleY = scaleFactorY;

      var scaleFactorX = (this.ActualWidth + this.Margin.Left + this.Margin.Right) / this.ActualWidth;
      MarginTranslateTransform.X = -(this.Margin.Left - this.Margin.Right) / (scaleFactorX * 2);

      MarginScaleTransform.ScaleX = scaleFactorX;
    }

    private void TopPanel_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      var newMargin = Math.Max(this.Margin.Top - MARGIN_SET, 0);
      this.Margin = new Thickness(this.Margin.Left, newMargin, this.Margin.Right, this.Margin.Bottom);
      TopMessage.Text = this.Margin.Top.ToString() + "px";
      UpdateTransforms();
    }

    private void LeftPanel_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      var newMargin = Math.Max(this.Margin.Left - MARGIN_SET, 0);
      this.Margin = new Thickness(newMargin, this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
      LeftMessage.Text = this.Margin.Left.ToString() + "px";
      UpdateTransforms();
    }

    private void RightPanel_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      var newMargin = Math.Max(this.Margin.Right - MARGIN_SET, 0);
      this.Margin = new Thickness(this.Margin.Left, this.Margin.Top, newMargin, this.Margin.Bottom);
      RightMessage.Text = this.Margin.Right.ToString() + "px";
      UpdateTransforms();
    }

    private void BottomPanel_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      var newMargin = Math.Max(this.Margin.Bottom - MARGIN_SET, 0);
      this.Margin = new Thickness(this.Margin.Left, Margin.Top, this.Margin.Right, newMargin);
      BottomMessage.Text = this.Margin.Bottom.ToString() + "px";
      UpdateTransforms();
    }

    #region Letter

    private static FrameworkPropertyMetadataOptions flags = FrameworkPropertyMetadataOptions.AffectsRender;

    /// <summary>
    /// Letter Dependency Property
    /// </summary>
    public static readonly DependencyProperty LetterProperty =
        DependencyProperty.Register("Letter", typeof(char), typeof(MarginMaster),
            new FrameworkPropertyMetadata(defaultValue: (char)'A',
              propertyChangedCallback: new PropertyChangedCallback(OnLetterChanged),
              flags: flags));

    /// <summary>
    /// Gets or sets the Letter property. This dependency property
    /// indicates what character to show.
    /// </summary>
    public char Letter {
      get { return (char)GetValue(LetterProperty); }
      set { SetValue(LetterProperty, value); }
    }

    /// <summary>
    /// Handles changes to the Letter property.
    /// </summary>
    private static void OnLetterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      MarginMaster target = (MarginMaster)d;
      char oldLetter = (char)e.OldValue;
      char newLetter = target.Letter;
      target.OnLetterChanged(oldLetter, newLetter);
    }

    /// <summary>
    /// Provides derived classes an opportunity to handle changes to the Letter property.
    /// </summary>
    protected virtual void OnLetterChanged(char oldLetter, char newLetter)
    {
      LetterTextBlock.Text = newLetter.ToString();


    }

    #endregion Letter

    private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      this.Margin = new Thickness(0);
      UpdateTransforms();
			RightMessage.Text= LeftMessage.Text= TopMessage.Text= BottomMessage.Text = "0px";
		}
  }
}