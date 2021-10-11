using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core.Mvvm;

namespace WslDockerTool.Net5.ViewModels.Container
{
	public class CreateContainerViewModel: DialogViewModelBase
	{
		public CreateContainerViewModel()
		{
			this.Title = "添加容器";
		}
	}
}
