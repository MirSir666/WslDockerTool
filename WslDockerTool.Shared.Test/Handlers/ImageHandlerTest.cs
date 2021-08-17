using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DryIoc;

namespace WslDockerTool.Shared.Test.Handlers
{
	public class ImageHandlerTest:TestBase
	{
		private readonly IImageHandler imageHandler;
		public ImageHandlerTest(ContainerSetup setup)
		  : base(setup)
		{
			imageHandler = Setup.Container.Resolve<IImageHandler>();
		}

		[Fact]
		public void ListImagesAsyncTest()
		{
		  var ret=imageHandler.ListImagesAsync(new Docker.DotNet.Models.ImagesListParameters()).Result;
		

		}
	}
}
