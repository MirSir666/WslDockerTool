using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Core.Common
{
    internal static class StreamTool
    {
        public static byte[] StreamToBytes(Stream stream)
        {
            if (stream == null) return null;
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        public static Stream BytesToStream(byte[] bytes)
        {
            if (bytes == null) return null;
            Stream stream = new MemoryStream(bytes);
            return stream;
        }


        public static void StreamToFile(Stream stream, string fileName)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }
        public static void BytesToFile(byte[] bytes, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }


        public static Stream FileToStream(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        public static Stream FileToMemoryStream(string fileName)
        {
            if (File.Exists(fileName))
            {
                var memoryStream = new MemoryStream();
                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(memoryStream);
                }
                memoryStream.Position = 0;
                return memoryStream;
            }
            return null;
        }
    }
}
