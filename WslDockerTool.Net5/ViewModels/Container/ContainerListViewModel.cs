using AutoMapper;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Net5.Manage;
using WslDockerTool.Net5.Models.Container;
using WslDockerTool.Shared;

namespace WslDockerTool.Net5.ViewModels.Container
{
	public class ContainerListViewModel : Collection<ContainerListItemModel>
	{
		private readonly IContainerHandler containerHandler;
		private readonly IMapper mapper;

		public ContainerListViewModel(IContainerHandler containerHandler, IMapper mapper)
		{
			this.containerHandler = containerHandler;
			this.mapper = mapper;
			Init();
		}

		public async void Init()
		{
			var ret = await containerHandler.ListContainersAsync();
			var list = mapper.Map<List<ContainerListItemModel>>(ret);
			this.Items.AddRange(list);
		}
	}
}
