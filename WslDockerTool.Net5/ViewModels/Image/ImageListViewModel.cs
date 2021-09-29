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
using WslDockerTool.Net5.Models.Image;
using WslDockerTool.Shared;

namespace WslDockerTool.Net5.ViewModels.Image
{
	public class ImageListViewModel : Collection<ImageListItemModel>
	{
		private readonly IImageHandler imageHandler;
		private readonly IMapper mapper;

		public  ImageListViewModel(IImageHandler imageHandler, IMapper mapper)
		{
			this.imageHandler = imageHandler;
			this.mapper = mapper;
			RemoveCommand = new DelegateCommand(Remove);
			Init();
		}
		public DelegateCommand RemoveCommand { get; set; }

		public async void Init()
		{
			var ret = await imageHandler.ListImagesAsync(new Docker.DotNet.Models.ImagesListParameters());
			var list = mapper.Map<List<ImageListItemModel>>(ret);
			this.Items.AddRange(list);
		}
		public void Remove()
		{

		}
	}
}
