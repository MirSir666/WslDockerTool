using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Models;
using WslDockerTool.Shared;
namespace WslDockerTool.Net5.ViewModels
{
	public class MainWindowViewModel: BindableBase
	{
		private readonly IRegionManager regionManager;


		public MainWindowViewModel(IRegionManager regionManager)
		{
			this.regionManager = regionManager;
			this.NavigateCommand = new DelegateCommand<string>(Navigate);
			this.LoadedCommand = new DelegateCommand(Loaded);
			//NavigateList.Add(new NavigationTreeItem("首页", null, "\ue64a"));
			NavigateList.Add(new NavigationTreeItem("容器管理", "ContainerList", "\ue64a"));
			NavigateList.Add(new NavigationTreeItem("镜像管理", "ImageList", "\ue617"));
			NavigateList.Add(new NavigationTreeItem("网络管理", "NetworkList", "\ue64d"));
			NavigateList.Add(new NavigationTreeItem("数据卷管理", "VolumeList", "\ue6bc"));
			NavigateList.Add(new NavigationTreeItem("端口映射管理", "PortProxyList", "\ue650"));
		}
		public List<NavigationTreeItem> NavigateList { get; set; } = new List<NavigationTreeItem>();

		public DelegateCommand<string> NavigateCommand { get; set; }
        public DelegateCommand LoadedCommand { get; set; }

        private void Navigate(string uri)
		{
			if (uri != null)
			{
				regionManager.RequestNavigate("ContentRegion", uri);
			}
		}

		public void Loaded()
		{
			Navigate("ContainerList");
		}
	}
}
