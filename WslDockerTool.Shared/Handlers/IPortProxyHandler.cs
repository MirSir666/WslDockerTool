using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Shared.Models;

namespace WslDockerTool.Shared.Handlers
{
    public interface IPortProxyHandler
    {
        Task<IEnumerable<PortProxyItem>> GetPortProxyList();
        Task AddPortProxy(PortProxyItem  portProxyItem);
        Task UpdatePortProxy(PortProxyItem portProxy);
        Task DeletePortProxy(params DeletePortProxyParameters[] parameters);
        Task ResetPortProxy();
    }
}
