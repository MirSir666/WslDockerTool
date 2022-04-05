using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WslDockerTool.Shared.Internal
{
	public class ContainerHandler: IContainerHandler
	{
		private readonly DockerClient dockerClient;
        private readonly IDownloadHandler downloadHandler;

        public ContainerHandler(DockerClient dockerClient, IDownloadHandler downloadHandler)
		{
			this.dockerClient = dockerClient;
            this.downloadHandler = downloadHandler;
        }

		public  async Task CreateContainerAsync(CreateContainerParameters parameters)
		{
			// var waitContainerCts = new CancellationTokenSource(delay: TimeSpan.FromMinutes(0.5));
		     await dockerClient.Containers.CreateContainerAsync(parameters);
		}

        public Task ExportContainerAsync(string id, string fileName)
        {
			return downloadHandler.ExportContainerAsync(id, fileName);
		}

        public Task<ContainerInspectResponse> InspectContainerAsync(string id)
        {
            return dockerClient.Containers.InspectContainerAsync(id);	
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
