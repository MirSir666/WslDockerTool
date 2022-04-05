using AutoMapper;
using HandyControl.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core;
using WslDockerTool.Net5.Core.Common;
using WslDockerTool.Net5.Core.Events;
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
		private readonly IDialogService dialogService;

		public ContainerListViewModel(IContainerHandler containerHandler,  IMapper mapper, IDialogService dialogService)
		{
			this.containerHandler = containerHandler;
            this.mapper = mapper;
			this.dialogService = dialogService;
			MultipleRestartCommand = new DelegateCommand<IEnumerable>(Restart);
			RestartCommand = new DelegateCommand<string>(Restart);
			CreateCommand = new DelegateCommand(Create);
			MultipleRemoveCommand = new DelegateCommand<IEnumerable>(Remove);
			RemoveCommand = new DelegateCommand<string>(Remove);
			QueryCommand = new DelegateCommand(Query);
			MultipleStartCommand = new DelegateCommand<IEnumerable>(Start);
			MultipleStopCommand = new DelegateCommand<IEnumerable>(Stop);
			ExportCommand = new DelegateCommand<string>(Export);
			ContainerPortProxyCommand=new DelegateCommand<string>(ContainerPortProxy);
			InitData();
		}

		public DelegateCommand<IEnumerable> MultipleRemoveCommand { get; set; }

		public DelegateCommand<string> RemoveCommand { get; set; }
		public DelegateCommand QueryCommand { get; set; }
		public DelegateCommand<IEnumerable> MultipleStartCommand { get; set; }
		public DelegateCommand<IEnumerable> MultipleStopCommand { get; set; }
		public DelegateCommand<IEnumerable> MultipleRestartCommand { get; set; }
		public DelegateCommand<string> RestartCommand { get; set; }
		public DelegateCommand CreateCommand { get; set; }
        public DelegateCommand<string> ExportCommand { get; set; }
		public DelegateCommand<string> ContainerPortProxyCommand { get; set; }

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
		public async void Remove(IEnumerable selectlist)
		{
			var ids = GetSelectIds(selectlist);
            if (ids.Any())
            {
                await containerHandler.RemovesContainersAsync(ids);
                Query();
            }
        }
		public  void ContainerPortProxy(string id)
		{
			var parameter = new DialogParameters();
			parameter.Add(DictKeySet.ContainerIdKey, id);
			dialogService.ShowDialog(DictKeySet.ContainerPortProxyListDialog, parameter, o => { });
			
		}



		public async void Remove(string id)
		{
			if (!string.IsNullOrEmpty(id))
			{
				await containerHandler.RemovesContainersAsync(id);
				Query();
			}
		
		}

		public async void Start(IEnumerable selectlist)
		{
			var ids = GetSelectIds(selectlist);
			if (ids.Any())
			{
				await containerHandler.StartContainerAsync(ids);
				Query();
			}
		}
		public async void Stop(IEnumerable selectlist)
		{
			var ids = GetSelectIds(selectlist);
			if (ids.Any())
			{
				await containerHandler.StopContainerAsync(ids);
				Query();
			}
		}

		public  void Create()
		{
			dialogService.ShowDialog(DictKeySet.CreateContainerDialog,  o=> {
				if (o.Result == ButtonResult.OK)
					 InitData();
			});
			
		}



		public async void Restart(IEnumerable selectlist)
		{
			var ids = GetSelectIds(selectlist);
			if (ids.Any())
			{
				await containerHandler.RestartContainerAsync(ids);
				Query();
			}
		}
		public async void Restart(string id)
		{
			if (!string.IsNullOrEmpty(id))
			{
				await containerHandler.RestartContainerAsync(id);
				Query();
			}
		}

		public async void Export(string id)
		{
			var name= Items.FirstOrDefault(o=>o.ID==id)?.NameF;
			if (!string.IsNullOrEmpty(id))
			{
				var filename= Popup.SaveFile(name);
				if (!string.IsNullOrEmpty(filename))
				{
					Growl.InfoGlobal($"正在操作中,请稍后");
					await containerHandler.ExportContainerAsync(id, filename);
					Growl.SuccessGlobal($"{filename}保存成功！");
				}
			}
				
			
		}

		string[] GetSelectIds(IEnumerable Selectlist)
		{
			return Selectlist.OfType<ContainerListItemModel>().Select(o => o.ID).ToArray();
		}


	}
}
