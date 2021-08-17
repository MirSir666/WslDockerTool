using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WslDockerTool.Shared.Internal
{
	public class ImageHandler: IImageHandler
	{
		private readonly DockerClient dockerClient;

		public ImageHandler(DockerClient dockerClient)
		{
			this.dockerClient = dockerClient;
		}

		public Task<Stream> BuildImageFromDockerfileAsync(Stream contents, ImageBuildParameters parameters, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<CommitContainerChangesResponse> CommitContainerChangesAsync(CommitContainerChangesParameters parameters, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task CreateImageAsync(ImagesCreateParameters parameters, AuthConfig authConfig, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default)
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

		public Task<IList<IDictionary<string, string>>> DeleteImageAsync(string name, ImageDeleteParameters parameters, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IList<ImageHistoryResponse>> GetImageHistoryAsync(string name, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<ImageInspectResponse> InspectImageAsync(string name, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IList<ImagesListResponse>> ListImagesAsync(ImagesListParameters parame)
		{
			return dockerClient.Images.ListImagesAsync(parame);
		}

		public Task LoadImageAsync(ImageLoadParameters parameters, Stream imageStream, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<ImagesPruneResponse> PruneImagesAsync(ImagesPruneParameters parameters = null, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task PushImageAsync(string name, ImagePushParameters parameters, AuthConfig authConfig, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<Stream> SaveImageAsync(string name, CancellationToken cancellationToken = default)
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
