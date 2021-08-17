using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WslDockerTool.Net5.Manage
{
	public static class UIThread
	{
		public static void Run(Action action)
		{
			var dispatcher = Dispatcher.CurrentDispatcher;
			if (dispatcher.CheckAccess())
				action();
			else dispatcher.Invoke(action);

		}
	}
}
