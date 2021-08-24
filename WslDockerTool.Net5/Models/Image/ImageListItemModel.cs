using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Image
{
	public class ImageListItemModel: DataGirdMultiple
	{
		public string ID { get; set; }
		public bool IsSelected { get; set; }

		public DateTime Created { get; set; }

		public long Size { get; set; }

		public string Name { get; set; }

	}
}
