using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models
{
	public class NavigationTreeItem
	{
		public NavigationTreeItem() { }
		public NavigationTreeItem(string name, string url, string icon =null)
		{
			Name = name;
			Icon = icon;
			Url = url;

		}
		public string Name { get; private set; }
		public string Icon { get; private set; }
		public string Url { get; set; }
		public List<NavigationTreeItem> ChildItems { get; private set; }
	}
}
