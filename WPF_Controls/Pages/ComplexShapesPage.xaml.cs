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

namespace WpfControls {
	/// <summary>
	/// Interaction logic for ComplexShapesPage.xaml
	/// </summary>
	public partial class ComplexShapesPage : Page {
		public ComplexShapesPage() {
			InitializeComponent();
		}

		private void CheckPath_MouseEnter(object sender, MouseEventArgs e) {
			CheckGradientStop.Color = Colors.Orange;
			CheckRotateTransform.Angle = CheckOutlineRotateTransform.Angle= 6;
		}

		private void CheckPath_MouseLeave(object sender, MouseEventArgs e) {
			CheckGradientStop.Color = Colors.White;
			CheckRotateTransform.Angle = CheckOutlineRotateTransform.Angle = 0;
		}
	}
}
