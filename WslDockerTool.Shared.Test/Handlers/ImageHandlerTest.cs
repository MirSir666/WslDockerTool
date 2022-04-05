using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DryIoc;
using WslDockerTool.Shared.Internal;
using System.Net.Http;
using System.IO;
using System.Net;

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
		public void Test()
		{

			var http=new HttpClient().GetStreamAsync("http://localhost:3000/containers/3f1cd061f57234625de0212f034bfae4e0101e991363589f1ea1a45f6ca876bf/export");
			var werwer = http.Result;
			//var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:3000/containers/44543cedc223dc56d6279b8a00579e59aaf6836f18c7a9cfbadfa9f56f6bafbd/export");
			var test = new WebClient().DownloadDataTaskAsync("http://localhost:3000/containers/3f1cd061f57234625de0212f034bfae4e0101e991363589f1ea1a45f6ca876bf/export");
			var response= test.Result;
			using (var fs = new MemoryStream(response))
			{
				var wer = fs;
				//response(fs);
			}
		}
		[Fact]
		public void ListImagesAsyncTest()
		{

			var ret=imageHandler.ListImagesAsync(new Docker.DotNet.Models.ImagesListParameters()).Result;
		

		}
	}
}
