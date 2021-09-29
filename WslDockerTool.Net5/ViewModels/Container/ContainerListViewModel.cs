using AutoMapper;
using Prism.Commands;
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
	public class ContainerListViewModel : SelectCollection<ContainerListItemModel>
	{
		private readonly IContainerHandler containerHandler;
		private readonly IMapper mapper;

		public ContainerListViewModel(IContainerHandler containerHandler, IMapper mapper)
		{
			this.containerHandler = containerHandler;
			this.mapper = mapper;
			RemoveCommand = new DelegateCommand(Remove);
			QueryCommand = new DelegateCommand(Query);
			Init();
		}
		public DelegateCommand RemoveCommand { get; set; }
		public DelegateCommand QueryCommand { get; set; }

		public async void Init()
		{
			var ret = await containerHandler.ListContainersAsync();
			var list = mapper.Map<List<ContainerListItemModel>>(ret);
			this.Items.AddRange(list);
		}
		public void Query()
		{
			//CheckAll();
			Init();
		}
		public void Remove()
		{
			var list= this.Items.GetSelectList();
			if (list.Any())
			{
				var ids = list.Select(o => o.ID).ToArray();
				containerHandler.Removes(ids);
				Query();
			}
		}

		private bool _isSelected;
		public bool IsSelected
		{
			get { return _isSelected; }
			set { SetProperty(ref _isSelected, value); }
		}
	}
}
