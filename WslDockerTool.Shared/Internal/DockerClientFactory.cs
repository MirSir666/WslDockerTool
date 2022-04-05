using Docker.DotNet;
using System;
using System.Collections.Generic;
using System.Text;
using WslDockerTool.Shared.Config;

namespace WslDockerTool.Shared.Internal
{
	public class DockerClientFactory : IDockerClientFactory
	{
		private readonly DockerConfig dockerConfig;

		public DockerClientFactory(DockerConfig dockerConfig)
		{
			this.dockerConfig = dockerConfig;
		}
		public DockerClient RegisterDockerClient()
		{

			var dockerClientConfiguration = new DockerClientConfiguration(dockerConfig.BaseUri, defaultTimeout: dockerConfig.DefaultTimeout);
			var dockerClient = dockerClientConfiguration.CreateClient();

			if (!string.IsNullOrEmpty(dockerConfig.Version))
				dockerClient = dockerClientConfiguration.CreateClient(new Version(dockerConfig.Version));
			return dockerClient;
		}
	}
}
