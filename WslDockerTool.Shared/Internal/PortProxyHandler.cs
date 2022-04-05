using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Shared.Handlers;
using WslDockerTool.Shared.Models;

namespace WslDockerTool.Shared.Internal
{
    internal class PortProxyHandler : IPortProxyHandler
    {
        public Task AddPortProxy(PortProxyItem portProxy)
        {
            NetshInterfacePortProxyCommand.Add(PortProxyType.v4tov4,portProxy.ListenPort,portProxy.ListenAddress ?? "0.0.0.0", portProxy.ConnectPort,portProxy.ConnectAddress) ;
            return Task.CompletedTask;
        }

        public Task DeletePortProxy(params DeletePortProxyParameters[] parameters)
        {
            foreach (var param in parameters)
                NetshInterfacePortProxyCommand.Delete(portProxyType: param.PortProxyType, listenaddress: param.ListenAddress??"0.0.0.0", listenport: param.ListenPort);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<PortProxyItem>> GetPortProxyList()
        {
            var list = new List<PortProxyItem>();
            var ret = NetshInterfacePortProxyCommand.All();
            var arr = ret.Split('\r', '\n').Where(o => !string.IsNullOrEmpty(o)).ToList();
            var skip = 3;
            if (arr.Count() <= skip) return Task.FromResult(list.AsEnumerable());
            arr = arr.Skip(skip).ToList();
            foreach (var item in arr)
            {
                var tarr = item.Split(' ').Where(o => !string.IsNullOrEmpty(o)).ToList();
                var portProxyItem = new PortProxyItem() { ListenAddress=tarr[0], ListenPort=tarr[1], ConnectAddress=tarr[2], ConnectPort=tarr[3]  };
                list.Add(portProxyItem);
            }
            return Task.FromResult(list.AsEnumerable());
        }

        public Task ResetPortProxy()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePortProxy(PortProxyItem portProxy)
        {
            NetshInterfacePortProxyCommand.Set(PortProxyType.v4tov4, portProxy.ListenPort, portProxy.ListenAddress ?? "0.0.0.0", portProxy.ConnectPort, portProxy.ConnectAddress);
            return Task.CompletedTask;
        }
    }
}
