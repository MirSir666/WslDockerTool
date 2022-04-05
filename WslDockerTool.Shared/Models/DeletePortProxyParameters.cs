using System;
using System.Collections.Generic;
using System.Text;
using WslDockerTool.Shared.Internal;

namespace WslDockerTool.Shared.Models
{
    public class DeletePortProxyParameters
    {
        public string ListenPort { get; set; }
        public string ListenAddress { get; set; }
        public PortProxyType PortProxyType { get; set; } = PortProxyType.v4tov4;

    }
}
