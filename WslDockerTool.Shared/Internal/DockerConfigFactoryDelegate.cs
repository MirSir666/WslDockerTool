using DryIoc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using WslDockerTool.Shared.Config;

namespace WslDockerTool.Shared.Internal
{
	public class DockerConfigFactoryDelegate
	{
		public static DockerConfig GetDockerConfigFactoryDelegate(IResolverContext resolverContext)
		{
			var config = new DockerConfig();
			var address = RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
							   ? "unix:///var/run/docker.sock"
							   : "npipe://./pipe/docker_engine";
			config.BaseUri = new Uri(address);
			return config;
		}
	}
}
