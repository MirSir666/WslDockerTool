using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Models.Image;

namespace WslDockerTool.Net5.Core.Events
{
    internal class CreateContainerSentEvent:PubSubEvent<ImageInfo>
    {
    }
}
