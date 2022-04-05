using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Shared
{
    public interface IDownloadHandler
    {
        Task ExportContainerAsync(string id, string fileName);
        Task SaveImageAsync(string imageName, string fileName);
    }
}
