using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Image
{
	public class ImageListItemModel: DataGirdMultiple
	{
		public long id { get; set; }
		public bool IsSelected { get; set; }
	}
}
