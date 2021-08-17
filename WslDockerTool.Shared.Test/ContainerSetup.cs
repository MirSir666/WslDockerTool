
using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WslDockerTool.Shared.Test
{
    public partial class ContainerSetup : IDisposable
    {
        public ContainerSetup()
        {
            Container = CreateContainer();
        }

        public IContainer Container;

        public Container CreateContainer()
        {
            return new Container();
        }

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            _disposed = true;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
}
