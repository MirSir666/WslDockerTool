using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Shared.Internal
{
	public class ContainerHandler: IContainerHandler
	{
		private readonly DockerClient dockerClient;

		public ContainerHandler(DockerClient dockerClient)
		{
			this.dockerClient = dockerClient;
		}

		public Task<IList<ContainerListResponse>> ListContainersAsync(ContainersListParameters parameters = null)
		{
			if (parameters == null) parameters = new ContainersListParameters() { All=true };
			return dockerClient.Containers.ListContainersAsync(parameters);
		}
	}
}
