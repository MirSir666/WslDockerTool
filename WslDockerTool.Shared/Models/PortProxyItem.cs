using System;
using System.Collections.Generic;
using System.Text;

namespace WslDockerTool.Shared.Models
{
    public class PortProxyItem
    {
        public string ListenPort { get; set; }

        public string ListenAddress { get; set; }

        public string ConnectPort { get; set; }
        public string ConnectAddress { get; set; }
    }
}
