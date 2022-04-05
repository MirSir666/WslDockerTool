using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Shared.Config;
using WslDockerTool.Shared.Handlers;

namespace WslDockerTool.Shared.Internal
{
    internal class DownloadHandler : IDownloadHandler
    {
        private readonly DockerConfig dockerConfig;
        private readonly WebClient webClient;

        public DownloadHandler(DockerConfig dockerConfig)
        {
            this.dockerConfig = dockerConfig;
            this.webClient = new WebClient();
        }
        public Task ExportContainerAsync(string id, string fileName) => DownloadFileTaskAsync($"/containers/{id}/export", fileName);
      

        public Task SaveImageAsync(string imageName, string fileName) => DownloadFileTaskAsync($"/images/{imageName}/get", fileName);
        

        public Task DownloadFileTaskAsync(string relativeUri, string fileName)
        {
            var url = new Uri(dockerConfig.BaseUri, relativeUri);
            return webClient.DownloadFileTaskAsync(url, fileName);
        }
    }
}
