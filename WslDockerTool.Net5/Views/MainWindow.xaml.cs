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
using System.Windows.Shapes;

namespace WslDockerTool.Net5.Views
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow 
	{
		public MainWindow()
		{
			InitializeComponent();
			this.Loaded += (r, s) =>
			{
				this.MouseDown += (x, y) =>
				{
					if (y.LeftButton == MouseButtonState.Pressed)
					{
						this.DragMove();
					}
				};
			};
		}
	}
}
