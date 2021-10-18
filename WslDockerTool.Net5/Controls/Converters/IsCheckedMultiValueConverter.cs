using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WslDockerTool.Net5.Controls.Converters
{
	[ValueConversion(typeof(bool), typeof(bool))]
	public class IsCheckedMultiValueConverter : IMultiValueConverter
	{
	
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{

			return values[0];
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{

			return new object[] { value, value };
		}
	}
}
