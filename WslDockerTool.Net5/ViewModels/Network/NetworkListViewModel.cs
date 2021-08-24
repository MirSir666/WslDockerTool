using AutoMapper;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Net5.Manage;
using WslDockerTool.Net5.Models.Network;
using WslDockerTool.Shared;

namespace WslDockerTool.Net5.ViewModels.Network
{
	public class NetworkListViewModel :Collection<NetworkListItemModel> 
	{
		private readonly INetworkHandler networkHandler;
		private readonly IMapper mapper;

		public NetworkListViewModel(INetworkHandler networkHandler, IMapper mapper)
		{
			this.networkHandler = networkHandler;
			this.mapper = mapper;
			Init();
		}

		public async void Init()
		{
			var ret = await networkHandler.ListNetworksAsync();
			var list = mapper.Map<List<NetworkListItemModel>>(ret);
			this.Items.AddRange(list);
		}
	}
}
