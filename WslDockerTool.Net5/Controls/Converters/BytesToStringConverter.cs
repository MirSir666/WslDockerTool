using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WslDockerTool.Net5.Controls.Converters
{
	public class BytesToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// "bytes", "KB", "MB", "GB"
			if (value is long)
			{
				var bytes = ((long)value);
				if (bytes > (1024 * 1024 * 1024))
				{
					var val = bytes / (1024 * 1024 * 1024);
					return $"{val}GB";
				}

				if (bytes > ( 1024 * 1024))
				{
					var val = bytes / ( 1024 * 1024);
					return $"{val}MB";
				}

				if (bytes > 1024)
				{
					var val = bytes / 1024;
					return $"{val}KB";
				}

			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
