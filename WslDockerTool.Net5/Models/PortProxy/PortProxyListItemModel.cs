using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.PortProxy
{
    public class PortProxyListItemModel : DataGirdMultiple
    {
        public string ListenPort { get; set; }

        public string ListenAddress { get; set; }

        public string ConnectPort { get; set; }
        public string ConnectAddress { get; set; }
        public string ContainerName { get; set; }
        public bool IsSelected { get; set; }
    }
}
