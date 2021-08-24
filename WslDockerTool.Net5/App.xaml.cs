using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WslDockerTool.Net5.Core.Mapping;
using WslDockerTool.Net5.Views;
using WslDockerTool.Net5.Views.Container;
using WslDockerTool.Net5.Views.Image;
using WslDockerTool.Net5.Views.Network;
using WslDockerTool.Net5.Views.PortProxy;
using WslDockerTool.Net5.Views.Volume;
using WslDockerTool.Shared;
using WslDockerTool.Shared.Config;

namespace WslDockerTool.Net5
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}


		protected override IContainerExtension CreateContainerExtension()
		{
			var container = new Container(CreateContainerRules());
			container.RegisterDelegate<DockerConfig>(o => new DockerConfig() { BaseUri = new Uri("http://localhost:3000/") });
			container.RegisterWslDockerToolShared();
			container.RegisterAutoMapper();
			return new DryIocContainerExtension(container);
		}


		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<ContainerList>("ContainerList");
			containerRegistry.RegisterForNavigation<ImageList>("ImageList");
			containerRegistry.RegisterForNavigation<VolumeList>("VolumeList");
			containerRegistry.RegisterForNavigation<NetworkList>("NetworkList");
			containerRegistry.RegisterForNavigation<PortProxyList>("PortProxyList");
		}
	}
}
