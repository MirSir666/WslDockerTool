using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Network
{
	public class NetworkListItemModel: DataGirdMultiple
	{
		public string Driver { get; set; }
		public string Scope { get; set; }
		public DateTime Created { get; set; }
		public string ID { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }
	}
}
