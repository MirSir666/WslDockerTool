using AutoMapper;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
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
		private readonly IDialogService dialogService;

		public ContainerListViewModel(IContainerHandler containerHandler, IMapper mapper, IDialogService dialogService)
		{
			this.containerHandler = containerHandler;
			this.mapper = mapper;
			this.dialogService = dialogService;
			RestartCommand = new DelegateCommand(Restart);
			RemoveCommand = new DelegateCommand(Remove);
			QueryCommand = new DelegateCommand(Query);
			StartCommand = new DelegateCommand(Start);
			StopCommand = new DelegateCommand(Stop);
			CreateCommand = new DelegateCommand(Create);
			InitData();
		}
		public DelegateCommand RemoveCommand { get; set; }
		public DelegateCommand QueryCommand { get; set; }
		public DelegateCommand StartCommand { get; set; }
		public DelegateCommand StopCommand { get; set; }
		public DelegateCommand RestartCommand { get; set; }

		public DelegateCommand CreateCommand { get; set; }

		public async void InitData()
		{
			var ret = await containerHandler.ListContainersAsync();
			var list = mapper.Map<List<ContainerListItemModel>>(ret);
			this.Items.Refresh(list);
		}
		public void Query()
		{
			InitData();
		}
		public async void Remove()
		{
			var ids= GetSelectIds();
			if (ids.Any())
			{
			 	await containerHandler.RemovesContainersAsync(ids);
				Query();
			}
		}

		public async void Start()
		{
			var ids = GetSelectIds();
			if (ids.Any())
			{
				await containerHandler.StartContainerAsync(ids);
				Query();
			}
		}
		public async void Stop()
		{
			var ids = GetSelectIds();
			if (ids.Any())
			{
				await containerHandler.StopContainerAsync(ids);
				Query();
			}
		}

		public  void Create()
		{
			dialogService.ShowDialog("CreateContainer",o=> {
				if (o.Result == ButtonResult.OK)
					Query();
			});
			
		}

		public async void Restart()
		{
			var ids = GetSelectIds();
			if (ids.Any())
			{
				await containerHandler.RestartContainerAsync(ids);
				Query();
			}
		}

		string[] GetSelectIds()
		{
			var list = this.Items.GetSelectList();
				return list.Select(o => o.ID).ToArray();
		}


	}
}
