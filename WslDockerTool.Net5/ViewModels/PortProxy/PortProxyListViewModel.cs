using AutoMapper;
using Prism.Services.Dialogs;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Models.PortProxy;
using WslDockerTool.Shared;
using WslDockerTool.Shared.Handlers;
using WslDockerTool.Net5.Manage;
using WslDockerTool.Net5.Core.Mvvm;
using System.Collections.Generic;
using Prism.Commands;
using System.Collections;
using WslDockerTool.Shared.Models;
using WslDockerTool.Net5.Core;

namespace WslDockerTool.Net5.ViewModels.PortProxy
{
	public class PortProxyListViewModel: Collection<PortProxyListItemModel>
	{
        private readonly IPortProxyHandler portProxyHandler;
        private readonly IContainerHandler containerHandler;
        private readonly IMapper mapper;
		private readonly IDialogService dialogService;

		public PortProxyListViewModel(IPortProxyHandler portProxyHandler, IContainerHandler containerHandler, IMapper mapper, IDialogService dialogService)
		{
            this.portProxyHandler = portProxyHandler;
            this.containerHandler = containerHandler;
            this.mapper = mapper;
			this.dialogService = dialogService;
			//MultipleRestartCommand = new DelegateCommand<IEnumerable>(Restart);
			//RestartCommand = new DelegateCommand<string>(Restart);
			CreateCommand = new DelegateCommand(Create);
			MultipleRemoveCommand = new DelegateCommand<IEnumerable>(Remove);
			RemoveCommand = new DelegateCommand<PortProxyListItemModel>(Remove);
			QueryCommand = new DelegateCommand(Query);
			ModifyCommand= new DelegateCommand<PortProxyListItemModel>(Modify);
			//MultipleStartCommand = new DelegateCommand<IEnumerable>(Start);
			//MultipleStopCommand = new DelegateCommand<IEnumerable>(Stop);
			//ExportCommand = new DelegateCommand<string>(Export);
			InitData();
		}
		
		public DelegateCommand CreateCommand { get; set; }
		public DelegateCommand QueryCommand { get; set; }
		public DelegateCommand<IEnumerable> MultipleRemoveCommand { get; set; }

		public DelegateCommand<PortProxyListItemModel> RemoveCommand { get; set; }
		public DelegateCommand<PortProxyListItemModel> ModifyCommand { get; set; }
		public async void InitData()
		{
			var containerLists=await containerHandler.ListContainersAsync();
			var portProxyItems = await portProxyHandler.GetPortProxyList();
			var list = mapper.Map<List<PortProxyListItemModel>>(portProxyItems);
			//list.ForEach(portProxyItem => { 
			//	portProxyItem.ContainerName= containerLists.FirstOrDefault(o=>o.Ports.Contains)
			//});
					 
					
			this.Items.Refresh(list);
		}
		public void Query()
		{
			InitData();
		}

		public async void Remove(IEnumerable selectlist)
		{
			var ends = GetSelect(selectlist);
			if (ends.Any())
			{
				await portProxyHandler.DeletePortProxy(mapper.Map<DeletePortProxyParameters[]>(ends));
				Query();
			}
		}

		public async void Remove(PortProxyListItemModel end)
		{
			if (end != null)
			{
				await portProxyHandler.DeletePortProxy(mapper.Map<DeletePortProxyParameters>(end));
				Query();
			}

		}

		public void Modify(PortProxyListItemModel end)
		{
			var dialogParameters = new DialogParameters();
			dialogParameters.Add(DictKeySet.PortProxyListItemKey, end);
			dialogService.ShowDialog(DictKeySet.CreatePortProxyDialog, dialogParameters, o => {
				if (o.Result == ButtonResult.OK)
				 	Query();
			});
		}

		public  void Create()
		{
			dialogService.ShowDialog(DictKeySet.CreatePortProxyDialog, o => {
				if (o.Result == ButtonResult.OK)
					Query();
			});
		}

		PortProxyListItemModel[] GetSelect(IEnumerable Selectlist)
		{
			return Selectlist.OfType<PortProxyListItemModel>().ToArray();
		}

	}
}
