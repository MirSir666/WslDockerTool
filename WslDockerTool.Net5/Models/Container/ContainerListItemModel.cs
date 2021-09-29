using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Models.Container
{
	public class ContainerListItemModel : BindableBase, DataGirdMultiple
	{

		public string ID { get; set; }

		public IList<string> Names { get; set; }


		public string NameF
		{
			get {
				if (Names != null && Names.Any())
					return string.Join(',', Names);

				return string.Empty;
			}
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
		}

		public string State { get; set; }
		public string Status { get; set; }

		private bool _isSelected ;
		public bool IsSelected
		{
			get { return _isSelected; }
			set { SetProperty(ref _isSelected, value); }
		}
	}

	public class Port
	{
		public string IP { get; set; }
		public ushort PrivatePort { get; set; }
		public ushort PublicPort { get; set; }
		public string Type { get; set; }
	}
}
