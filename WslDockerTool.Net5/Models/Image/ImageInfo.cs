using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Image
{
    public class ImageInfo
    {
        public ImageInfo() { }
        public ImageInfo(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public string ID { get; set; }
        public string Name { get; set; }
       
    }
}
