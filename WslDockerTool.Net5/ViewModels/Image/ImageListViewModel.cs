using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Net5.Manage;
using WslDockerTool.Net5.Models.Image;

namespace WslDockerTool.Net5.ViewModels.Image
{
	public class ImageListViewModel : Collection<ImageListItemModel>
	{
		public ImageListViewModel()
		{
			this.Items.AddRange(new ImageListItemModel(), new ImageListItemModel());
		}
	}
}
