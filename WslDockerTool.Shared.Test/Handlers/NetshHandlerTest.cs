using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Prism.Ioc;
using DryIoc;

namespace WslDockerTool.Shared.Test.Handlers
{
	public class NetshHandlerTest : TestBase
	{
		public NetshHandlerTest(ContainerSetup setup)
		  : base(setup)
		{
			
		}

		[Fact]
		public void AddPortProxyTest()
		{
			var netsh = Setup.Container.Resolve<INetshHandler>();
			netsh.AddPortProxy();
		}
	}
}
