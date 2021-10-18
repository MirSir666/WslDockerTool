using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Shared
{
	public interface IContainerHandler
	{
		Task<IList<ContainerListResponse>> ListContainersAsync(ContainersListParameters parameters=null);
		Task RemovesContainersAsync(params string[] ids);
		Task StartContainerAsync(params string[] ids);
		Task StopContainerAsync(params string[] ids);
		Task RestartContainerAsync(params string[] ids);
		Task<CreateContainerResponse> CreateContainerAsync(CreateContainerParameters parameters);
	}
}
