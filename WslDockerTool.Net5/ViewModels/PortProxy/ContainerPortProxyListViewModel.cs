using AutoMapper;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Net5.Manage;
using WslDockerTool.Net5.Models;
using WslDockerTool.Net5.Models.PortProxy;
using WslDockerTool.Shared;
using WslDockerTool.Shared.Handlers;
using WslDockerTool.Shared.Models;

namespace WslDockerTool.Net5.ViewModels.PortProxy
{
    public class ContainerPortProxyListViewModel : Collection<PortProxyListItemModel>, IDialogAware
    {

        private readonly IPortProxyHandler portProxyHandler;
        private readonly IContainerHandler containerHandler;
        private readonly IMapper mapper;
        private readonly IDialogService dialogService;
        private string containerName;

        public ContainerPortProxyListViewModel(IPortProxyHandler portProxyHandler, IContainerHandler containerHandler, IMapper mapper, IDialogService dialogService)
        {
            this.portProxyHandler = portProxyHandler;
            this.containerHandler = containerHandler;
            this.mapper = mapper;
            this.dialogService = dialogService;
            CreateCommand = new DelegateCommand(Create);
            MultipleRemoveCommand = new DelegateCommand<IEnumerable>(Remove);
            RemoveCommand = new DelegateCommand<PortProxyListItemModel>(Remove);
            QueryCommand = new DelegateCommand(Query);
            ModifyCommand = new DelegateCommand<PortProxyListItemModel>(Modify);
            CloseCommand = new DelegateCommand<ButtonResult?>(CloseAction);

            //  InitData();
        }
        public string Title { get; set; } = "容器端口映射";
        public DelegateCommand CreateCommand { get; set; }
        public DelegateCommand QueryCommand { get; set; }
        public DelegateCommand<ButtonResult?> CloseCommand { get; set; }
        public DelegateCommand<IEnumerable> MultipleRemoveCommand { get; set; }

        public DelegateCommand<PortProxyListItemModel> RemoveCommand { get; set; }
        public DelegateCommand<PortProxyListItemModel> ModifyCommand { get; set; }
        public string ContainerId { get; set; }
        public string ContainerName { get => containerName; set => SetProperty(ref containerName, value); }

        public System.Collections.ObjectModel.ObservableCollection<ComboBoxSelectItem> ContainerPortList { get; set; } = new System.Collections.ObjectModel.ObservableCollection<ComboBoxSelectItem>();

        private ComboBoxSelectItem selectedContainerPort;
        public ComboBoxSelectItem SelectedContainerPort
        {
            get { return selectedContainerPort; }
            set
            {
                SetProperty(ref selectedContainerPort, value);
            }
        }
        public List<string> Ports { get; set; }

        public async void InitData()
        {
            var container = await containerHandler.InspectContainerAsync(ContainerId);
            var portProxyItems = await portProxyHandler.GetPortProxyList();
            var list = mapper.Map<List<PortProxyListItemModel>>(portProxyItems);
            if (container?.Config?.ExposedPorts?.Count() > 0)
            {
                Ports = container.Config.ExposedPorts.Where(o => o.Key.Contains("tcp")).Select(o => o.Key.Split('/')[0]).ToList();
                list = list.Where(o => Ports.Contains(o.ListenPort)).ToList();
                this.Items.Refresh(list);
                Ports.ForEach(o => ContainerPortList.Add(new ComboBoxSelectItem() { Name=o,Value=o }));
            }
            this.ContainerName=container.Name;

        }
        public async void Query()
        {
            var portProxyItems = await portProxyHandler.GetPortProxyList();
            var list = mapper.Map<List<PortProxyListItemModel>>(portProxyItems);
            if (Ports.Count > 0)
            {
                list = list.Where(o => Ports.Contains(o.ListenPort)).ToList();
                this.Items.Refresh(list);
            }
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
            dialogService.ShowDialog(DictKeySet.CreatePortProxyDialog, dialogParameters, o =>
            {
                if (o.Result == ButtonResult.OK)
                    Query();
            });
        }

        public void Create()
        {

            if (selectedContainerPort == null)
            {
                HandyControl.Controls.MessageBox.Warning("请选择创建端口");
                return;
            }
            
            var parame = new DialogParameters();
            parame.Add(DictKeySet.ContainerPortKey, selectedContainerPort.Name);
            dialogService.ShowDialog(DictKeySet.CreatePortProxyDialog, parame, o =>
            {
                if (o.Result == ButtonResult.OK)
                    Query();
            });
        }

        PortProxyListItemModel[] GetSelect(IEnumerable Selectlist)
        {
            return Selectlist.OfType<PortProxyListItemModel>().ToArray();
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }


        private void CloseAction(ButtonResult? parameter)
        {
            ButtonResult button = parameter ?? ButtonResult.None;

            RequestClose?.Invoke(new DialogResult(button, new DialogParameters()));
        }
        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            this.ContainerId = parameters.GetValue<string>(DictKeySet.ContainerIdKey);
            InitData();

        }
    }
}
