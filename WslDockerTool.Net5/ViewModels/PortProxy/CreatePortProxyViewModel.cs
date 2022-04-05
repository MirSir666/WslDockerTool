using AutoMapper;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Net5.Models.PortProxy;
using WslDockerTool.Shared.Handlers;
using WslDockerTool.Shared.Internal;
using WslDockerTool.Shared.Models;

namespace WslDockerTool.Net5.ViewModels.PortProxy
{
    public class CreatePortProxyViewModel : DialogViewModelBase
    {
        private string listenPort;
        private string listenAddress = "0.0.0.0";
        private string connectPort;
        private string connectAddress;
        private string tips;
        private bool isUpdate = false;
        private bool isPort;
        private readonly IPortProxyHandler portProxyHandler;
        private readonly IMapper mapper;

        public CreatePortProxyViewModel(IPortProxyHandler portProxyHandler, IMapper mapper)
        {
            Tips = WSLCommand.GetIfconfigEth0Inet();
            this.portProxyHandler = portProxyHandler;
            this.mapper = mapper;
            CloseCommand = new DelegateCommand<ButtonResult?>(CloseAction);
            this.Title = "创建";
        }

        public DelegateCommand<ButtonResult?> CloseCommand { get; set; }

        public string ListenPort { get => listenPort; set => SetProperty(ref listenPort, value); }
        public string ListenAddress { get => listenAddress; set => SetProperty(ref listenAddress, value); }
        public string ConnectPort { get => connectPort; set => SetProperty(ref connectPort, value); }
        public string ConnectAddress { get => connectAddress; set => SetProperty(ref connectAddress, value); }
        public string Tips { get => tips; set => SetProperty(ref tips, value); }
        public bool IsUpdate { get => isUpdate; set => SetProperty(ref isUpdate, value); }
        public bool IsPort { get => isPort; set => SetProperty(ref isPort, value); }
        private void CloseAction(ButtonResult? parameter)
        {
            ButtonResult button = parameter ?? ButtonResult.None;
            if (button == ButtonResult.OK)
            {
                if (IsUpdate)
                    portProxyHandler.UpdatePortProxy(mapper.Map<PortProxyItem>(this));
                else
                    portProxyHandler.AddPortProxy(mapper.Map<PortProxyItem>(this));
            }
            RaiseRequestClose(new DialogResult(button, new DialogParameters()));
        }



        public override void OnDialogOpened(IDialogParameters parameters)
        {

            var port = parameters.GetValue<string>(DictKeySet.ContainerPortKey);

            if (!string.IsNullOrEmpty(port))
            {
                IsPort = true;
                ConnectPort = port;
            }

            var info = parameters.GetValue<PortProxyListItemModel>(DictKeySet.PortProxyListItemKey);
            if (info == null) return;
            this.ListenAddress = info.ListenAddress;
            this.ConnectPort = info.ConnectPort;
            this.ConnectAddress = info.ConnectAddress;
            this.ListenPort = info.ListenPort;
            this.IsUpdate = true;
            this.Title = "修改";

        }
    }
}
