using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Shared.Internal
{
	public class VolumeHandler: IVolumeHandler
	{
		private readonly DockerClient dockerClient;

		public VolumeHandler(DockerClient dockerClient)
		{
			this.dockerClient = dockerClient;
		}

		public async Task<IList<VolumeResponse>> ListAsync()
		{
			var response = await dockerClient.Volumes.ListAsync();
			return response.Volumes;
		}
	}
}
