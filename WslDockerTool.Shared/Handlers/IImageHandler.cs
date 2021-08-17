﻿using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WslDockerTool.Shared
{
	public interface IImageHandler
	{
		Task<Stream> BuildImageFromDockerfileAsync(Stream contents, ImageBuildParameters parameters, CancellationToken cancellationToken = default);
		Task<CommitContainerChangesResponse> CommitContainerChangesAsync(CommitContainerChangesParameters parameters, CancellationToken cancellationToken = default);
		Task CreateImageAsync(ImagesCreateParameters parameters, AuthConfig authConfig, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default);
		Task CreateImageAsync(ImagesCreateParameters parameters, AuthConfig authConfig, IDictionary<string, string> headers, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default);
		Task CreateImageAsync(ImagesCreateParameters parameters, Stream imageStream, AuthConfig authConfig, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default);
		Task CreateImageAsync(ImagesCreateParameters parameters, Stream imageStream, AuthConfig authConfig, IDictionary<string, string> headers, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default);
		Task<IList<IDictionary<string, string>>> DeleteImageAsync(string name, ImageDeleteParameters parameters, CancellationToken cancellationToken = default);
		Task<IList<ImageHistoryResponse>> GetImageHistoryAsync(string name, CancellationToken cancellationToken = default);
		Task<ImageInspectResponse> InspectImageAsync(string name, CancellationToken cancellationToken = default);
		Task<IList<ImagesListResponse>> ListImagesAsync(ImagesListParameters parame);
		Task LoadImageAsync(ImageLoadParameters parameters, Stream imageStream, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default);
		Task<ImagesPruneResponse> PruneImagesAsync(ImagesPruneParameters parameters = null, CancellationToken cancellationToken = default);
		Task PushImageAsync(string name, ImagePushParameters parameters, AuthConfig authConfig, IProgress<JSONMessage> progress, CancellationToken cancellationToken = default);
		Task<Stream> SaveImageAsync(string name, CancellationToken cancellationToken = default);
		Task<Stream> SaveImagesAsync(string[] names, CancellationToken cancellationToken = default);
		Task<IList<ImageSearchResponse>> SearchImagesAsync(ImagesSearchParameters parameters, CancellationToken cancellationToken = default);
		Task TagImageAsync(string name, ImageTagParameters parameters, CancellationToken cancellationToken = default);
	}
}