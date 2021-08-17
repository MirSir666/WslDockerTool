using Docker.DotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace WslDockerTool.Shared
{
	public interface IDockerClientFactory
	{
		DockerClient RegisterDockerClient();
	}
}
