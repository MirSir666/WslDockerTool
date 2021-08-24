using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Container
{
	public class ContainerListItemModel
	{

		public string ID { get; set; }

		public IList<string> Names { get; set; }

		public string Image { get; set; }

		public string ImageID { get; set; }

		public string Command { get; set; }

		public DateTime Created { get; set; }

		public IList<string> Ports { get; set; }

		public string State { get; set; }
		public string Status { get; set; }


	}
}
