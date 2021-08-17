using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace WslDockerTool.Net5.Controls
{
	public class Icon: TextBlock
	{
        public Icon()
        {
            FontFamily = new FontFamily(new Uri("pack://application:,,,/WslDockerTool.Net5;component/Controls/icon/#iconfont"), "iconfont");
        }

        public static readonly DependencyProperty ValueProperty =
                  DependencyProperty.Register("Value", typeof(string), typeof(Icon), new PropertyMetadata(null, new PropertyChangedCallback(OnValueChanged)));




        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void OnValueChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            Icon source = (Icon)sender;
            if (args.NewValue != null)
                source.Text = source.Value;
        }
    }

    public enum IconType
    {
        volume,
        network,

    }

}
