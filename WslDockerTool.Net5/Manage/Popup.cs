using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Core.Common
{
    internal static class Popup
    {
        public static string OpenFile(string filter = "tar.gz（*.tar.gz）|*.tar.gz", string defaultExt = ".tar.gz")
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = defaultExt;
            ofd.Filter = filter;
            if (ofd.ShowDialog() == true)
                return ofd.FileName;

            return string.Empty;
        }
        public static string SaveFile(string name,string filter= "tar.gz（*.tar.gz）|*.tar.gz",string defaultExt= ".tar.gz")
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = defaultExt;
            dlg.Filter = filter;
            dlg.FileName = $"{ReplaceBadCharOfFileName(name)}-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            if (dlg.ShowDialog() == true)
                return dlg.FileName;
               
            return string.Empty;
            //using (var stream = await client.Containers.ExportContainerAsync(containerRunResult.ID))
            //using (var fileStream = new GZipStream(File.OpenWrite(targetPath), CompressionMode.Compress, false))
            //{
            //    await stream.CopyToAsync(fileStream);
            //}

        }

        static string ReplaceBadCharOfFileName(string fileName)
        {
            string str = fileName;
            str = str.Replace("\\", string.Empty);
            str = str.Replace("/", string.Empty);
            str = str.Replace(":", string.Empty);
            str = str.Replace("*", string.Empty);
            str = str.Replace("?", string.Empty);
            str = str.Replace("\"", string.Empty);
            str = str.Replace("<", string.Empty);
            str = str.Replace(">", string.Empty);
            str = str.Replace("|", string.Empty);
            str = str.Replace(" ", string.Empty);    //前面的替换会产生空格,最后将其一并替换掉
            return str;
        }
    }
}
