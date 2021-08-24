using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Shared
{
	public interface INetworkHandler
	{
		Task<IList<NetworkResponse>> ListNetworksAsync(NetworksListParameters parameters = null);
	}
}
