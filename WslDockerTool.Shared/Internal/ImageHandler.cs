using Docker.DotNet;
using Docker.DotNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WslDockerTool.Shared.Internal
{
	public class ImageHandler: IImageHandler
	{
		private readonly DockerClient dockerClient;
        private readonly IDownloadHandler downloadHandler;
        CancellationTokenSource cts ;

		public ImageHandler(DockerClient dockerClient, IDownloadHandler downloadHandler)
		{
			this.dockerClient = dockerClient;
            this.downloadHandler = downloadHandler;
            cts = new CancellationTokenSource();
		}

		public async Task DeleteImageAsync(params string[] names)
		{
			foreach (var name in names)
				await dockerClient.Images.DeleteImageAsync(name,new ImageDeleteParameters() { Force=true, NoPrune=true });
		}

		public async Task CreateImageAsync(string imageName)
		{
			await dockerClient.Images.CreateImageAsync(
				new ImagesCreateParameters
				{
					FromImage = imageName,
					Tag = "latest"
				},
				null,
				new Progress<JSONMessage>((m) => { Console.WriteLine(JsonConvert.SerializeObject(m)); Debug.WriteLine(JsonConvert.SerializeObject(m)); }),
				cts.Token);
	
		}

		public Task SaveImageAsync(string imageName, string fileName)
		{
			return downloadHandler.SaveImageAsync( imageName, fileName);
			//return dockerClient.Images.SaveImageAsync(name);
		}

		public Task LoadImageAsync(string filePath)
		{

			var prog = new Progress<JSONMessage>((m) =>
			{
				Console.WriteLine(JsonConvert.SerializeObject(m));
				Debug.WriteLine(JsonConvert.SerializeObject(m));
			});
			return dockerClient.Images.LoadImageAsync(new ImageLoadParameters(), File.OpenRead(filePath), prog );
		}


		public Task<Stream> BuildImageFromDockerfileAsync(Stream contents, ImageBuildParameters parameters, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<CommitContainerChangesResponse> CommitContainerChangesAsync(CommitContainerChangesParameters parameters, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		

		public Task CreateImageAsync(ImagesCreateParameters parameters, AuthConfig authConfig, IDictionary<string, string> headers, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task CreateImageAsync(ImagesCreateParameters parameters, Stream imageStream, AuthConfig authConfig, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task CreateImageAsync(ImagesCreateParameters parameters, Stream imageStream, AuthConfig authConfig, IDictionary<string, string> headers, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		

		public Task<IList<ImageHistoryResponse>> GetImageHistoryAsync(string name, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<ImageInspectResponse> InspectImageAsync(string name, CancellationToken cancellationToken = default)
		{
			return dockerClient.Images.InspectImageAsync(name, cancellationToken);
		}

		public Task<IList<ImagesListResponse>> ListImagesAsync(ImagesListParameters parame)
		{
			return dockerClient.Images.ListImagesAsync(parame);
		}

		

		public Task<ImagesPruneResponse> PruneImagesAsync(ImagesPruneParameters parameters = null, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task PushImageAsync(string name, ImagePushParameters parameters, AuthConfig authConfig, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		

		public Task<Stream> SaveImagesAsync(string[] names, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IList<ImageSearchResponse>> SearchImagesAsync(ImagesSearchParameters parameters, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task TagImageAsync(string name, ImageTagParameters parameters, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
