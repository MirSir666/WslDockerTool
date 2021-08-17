using Docker.DotNet;
using DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using WslDockerTool.Shared.Config;
using WslDockerTool.Shared.Internal;

namespace WslDockerTool.Shared
{
	public static class WslDockerToolSharedBuilderExtensions
	{
		//public static void RegisterWslDockerToolShared(this IContainerRegistry containerRegistry)
		//{
		//	containerRegistry.RegisterSingleton<IContainerHandler, ContainerHandler>();
		//	containerRegistry.RegisterSingleton<IImageHandler, ImageHandler>();
		//	containerRegistry.RegisterSingleton<INetshHandler, NetshHandler>();
		//	containerRegistry.RegisterSingleton<INetworkHandler, NetworkHandler>();
		//	containerRegistry.RegisterSingleton<IVolumeHandler, VolumeHandler>();
		//}

		public static void RegisterWslDockerToolShared(this IContainer container)
		{
			container.Register<IContainerHandler, ContainerHandler>();
			container.Register<IImageHandler, ImageHandler>();
			container.Register<INetshHandler, NetshHandler>();
			container.Register<INetworkHandler, NetworkHandler>();
			container.Register<IVolumeHandler, VolumeHandler>();
			//container.RegisterDelegate<DockerConfig>(DockerConfigFactoryDelegate.GetDockerConfigFactoryDelegate);
			container.Register<IDockerClientFactory, DockerClientFactory>();
			container.RegisterDelegate<DockerClient>(o=>o.Resolve<IDockerClientFactory>().RegisterDockerClient());
		}
	}
}
