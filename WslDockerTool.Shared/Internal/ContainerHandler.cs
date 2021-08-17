using Docker.DotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace WslDockerTool.Shared.Internal
{
	public class ContainerHandler: IContainerHandler
	{
		public ContainerHandler()
		{
			var dockerClient = new DockerClientConfiguration().CreateClient();
			//DockerClient
		}
	}
}
