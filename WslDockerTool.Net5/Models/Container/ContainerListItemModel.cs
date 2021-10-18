using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Container
{
	public class ContainerListItemModel : BindableBase
	{

		public string ID { get; set; }

		public IList<string> Names { get; set; }

		string nameF;
		public string NameF
		{
			get {
				if (Names != null && Names.Any())
					return string.Join(',', Names);

				return string.Empty;
			}
			set { nameF=value; }
		}
		


		public string Image { get; set; }

		public string ImageID { get; set; }

		public string Command { get; set; }

		public DateTime Created { get; set; }

		public IList<Port> Ports { get; set; }
		public string PortF
		{
			get
			{
				if (Ports != null && Ports.Any())
					return string.Join(',', Ports.Select(o => o.PublicPort).ToList());
				
				return string.Empty;
			}
			set { portF = value; }
		}
		string portF;

		public string State { get; set; }
		public string Status { get; set; }

		
	}

	public class Port
	{
		public string IP { get; set; }
		public ushort PrivatePort { get; set; }
		public ushort PublicPort { get; set; }
		public string Type { get; set; }
	}
}
