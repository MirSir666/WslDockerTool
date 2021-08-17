using Docker.DotNet;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WslDockerTool.Shared.Extensions
{
	public static class DockerClientExtensions
	{
        //public static DockerClient RegisterDockerClient()
        //{
        //    var dockerAddress = RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
        //                        ? "unix:///var/run/docker.sock"
        //                        : "npipe://./pipe/docker_engine"; //windows addr
        //     var dockerClientConfiguration = new DockerClientConfiguration(new Uri(dockerAddress));
        //    var dockerClient = dockerClientConfiguration.CreateClient();

        //    return dockerClient;
        //}
    }
}
