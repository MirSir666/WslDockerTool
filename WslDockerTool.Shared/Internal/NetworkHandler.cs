using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Shared.Internal
{
	public class NetworkHandler: INetworkHandler
	{
		private readonly DockerClient dockerClient;

		public NetworkHandler(DockerClient dockerClient)
		{
			this.dockerClient = dockerClient;
		}

		public Task<IList<NetworkResponse>> ListNetworksAsync(NetworksListParameters parameters = null)
		{
			return dockerClient.Networks.ListNetworksAsync(parameters);
		}
	}
}
