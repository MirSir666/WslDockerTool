using System;
using System.Collections.Generic;
using System.Text;

namespace WslDockerTool.Shared.Config
{
	public class DockerConfig
	{
		public Uri BaseUri { get; set; }
		public TimeSpan DefaultTimeout { get; set; }
		public string Version { get; set; }
	}
}
