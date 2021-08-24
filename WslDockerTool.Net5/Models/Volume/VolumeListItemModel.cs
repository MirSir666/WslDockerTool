using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Volume
{
	public class VolumeListItemModel: DataGirdMultiple
	{
		public bool IsSelected { get; set; }
		public DateTime Created { get; set; }
		public string Driver { get; set; }
		public string Mountpoint { get; set; }
		public string Name { get; set; }
		public string Scope { get; set; }
	}
}
