using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Shared.Config;
using Xunit;

namespace WslDockerTool.Shared.Test
{
    //[Collection(nameof(ContainerExtension))]
    public abstract class TestBase : IClassFixture<ContainerSetup>, IDisposable
    {
        private bool disposedValue;

        protected ContainerSetup Setup { get; }

        protected TestBase(ContainerSetup setup)
        {
            Setup = setup;
            Setup.Container.RegisterWslDockerToolShared();
            Setup.Container.RegisterDelegate<DockerConfig>(o => new DockerConfig() { BaseUri = new Uri("http://localhost:3000/") }) ;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Setup.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
