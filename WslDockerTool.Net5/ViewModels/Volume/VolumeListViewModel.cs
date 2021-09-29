using AutoMapper;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Net5.Manage;
using WslDockerTool.Net5.Models.Volume;
using WslDockerTool.Shared;

namespace WslDockerTool.Net5.ViewModels.Volume
{
	public class VolumeListViewModel : Collection<VolumeListItemModel>
	{
		private readonly IVolumeHandler volumeHandler;
		private readonly IMapper mapper;

		public VolumeListViewModel(IVolumeHandler  volumeHandler, IMapper mapper)
		{
			this.volumeHandler = volumeHandler;
			this.mapper = mapper;
			RemoveCommand = new DelegateCommand(Remove);
			Init();
		}
		public DelegateCommand RemoveCommand { get; set; }

		public async void Init()
		{
			var ret = await volumeHandler.ListAsync();
			var list = mapper.Map<List<VolumeListItemModel>>(ret);
			this.Items.AddRange(list);
		}

		public void Remove()
		{

		}
	}
}
