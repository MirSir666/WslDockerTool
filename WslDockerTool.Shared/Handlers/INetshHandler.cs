using System;
using System.Collections.Generic;
using System.Text;

namespace WslDockerTool.Shared
{
	public interface INetshHandler
	{
		void AddPortProxy();

		void DeletePortProxy();
	}
}
