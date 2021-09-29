﻿using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Shared
{
	public interface IContainerHandler
	{
		Task<IList<ContainerListResponse>> ListContainersAsync(ContainersListParameters parameters=null);
		void Removes(params string[] ids);
	}
}
