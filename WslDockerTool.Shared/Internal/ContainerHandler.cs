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

		public Task<CreateContainerResponse> CreateContainerAsync(CreateContainerParameters parameters)
		{
			throw new NotImplementedException();
		}

		public Task<IList<ContainerListResponse>> ListContainersAsync(ContainersListParameters parameters = null)
		{
			if (parameters == null) parameters = new ContainersListParameters() { All=true };
			return dockerClient.Containers.ListContainersAsync(parameters);
		}

		public async Task RemovesContainersAsync(params string[] ids)
		{
			foreach (var id in ids)
			   await dockerClient.Containers.RemoveContainerAsync(id, new ContainerRemoveParameters() { Force=true });
		}

		public async Task RestartContainerAsync(params string[] ids)
		{
			foreach (var id in ids)
				await dockerClient.Containers.RestartContainerAsync(id, new ContainerRestartParameters());
		}

		public async Task StartContainerAsync(params string[] ids)
		{
			foreach (var id in ids)
				await dockerClient.Containers.StartContainerAsync(id,new ContainerStartParameters());
		}

		public async Task StopContainerAsync(params string[] ids)
		{
			foreach (var id in ids)
				await dockerClient.Containers.StopContainerAsync(id,new ContainerStopParameters());
		}
	}
}
