using AutoMapper;
using HandyControl.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core;
using WslDockerTool.Net5.Core.Common;
using WslDockerTool.Net5.Core.Events;
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
		private readonly IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;

        public ImageListViewModel(IImageHandler imageHandler, IMapper mapper, IDialogService dialogService, IEventAggregator eventAggregator)
		{
			this.imageHandler = imageHandler;
			this.mapper = mapper;
			this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            MultipleRemoveCommand = new DelegateCommand<IEnumerable>(Remove);
			RemoveCommand = new DelegateCommand<string>(Remove);
			QueryCommand = new DelegateCommand(Query);
			CreateCommand = new DelegateCommand(Create);
			SaveCommand = new DelegateCommand<string>(Save);
			LoadCommand = new DelegateCommand(Load);
			CreateContainerCommand = new DelegateCommand<string>(CreateContainer);
			InitData();
		}
		public DelegateCommand<IEnumerable> MultipleRemoveCommand { get; set; }
        public DelegateCommand<string> RemoveCommand { get; set; }
        public DelegateCommand QueryCommand { get; set; }
		public DelegateCommand CreateCommand { get; set; }
		public DelegateCommand<string> SaveCommand { get; set; }
		public DelegateCommand LoadCommand { get; set; }
		public DelegateCommand<string> CreateContainerCommand { get; set; }

		public async void InitData()
		{
			var ret = await imageHandler.ListImagesAsync(new Docker.DotNet.Models.ImagesListParameters());
			var list = mapper.Map<List<ImageListItemModel>>(ret);
			this.Items.Refresh(list);
		}

		public  void Create()
		{
			dialogService.ShowDialog(DictKeySet.CreateImageDialog, async o => {
				if (o.Result == ButtonResult.OK)
				{
					var imagename = o.Parameters.GetValue<string>(DictKeySet.ImageNameKey);
					//var dialog = HandyControl.Controls.Dialog.Show("正在操作中,请稍后");
					Growl.InfoGlobal($"正在操作中,请稍后");
					await imageHandler.CreateImageAsync(imagename);
					//dialog.Close();
					Growl.SuccessGlobal($"{imagename}拉取成功！");
					Query();
				}
					
			});

		}

		public void Query()
		{
			InitData();
		}

		public async void Remove(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				await imageHandler.DeleteImageAsync(name);
				Query();
			}
		}

		public async void Remove(IEnumerable selectlist)
		{
			var names = GetSelectNames(selectlist);
			if (names.Any())
			{
			 	await imageHandler.DeleteImageAsync(names);
				Query();
			}
		}

		public async void Save(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				var filename = Popup.SaveFile(name, ".tar（*.tar）|*.tar",".tar");
				if (!string.IsNullOrEmpty(filename))
				{
					Growl.InfoGlobal($"正在操作中,请稍后");
					await imageHandler.SaveImageAsync(name, filename);
					Growl.SuccessGlobal($"{filename}保存成功！");
				}
			}
		}

		public async void Load()
		{
			var filename = Popup.OpenFile(".tar（*.tar）|*.tar", ".tar");
			if (!string.IsNullOrEmpty(filename))
			{
				Growl.InfoGlobal($"正在操作中,请稍后");
				await imageHandler.LoadImageAsync(filename);
				Growl.SuccessGlobal($"导入成功！");
				Query();
			}
		}

		public  void CreateContainer(string imageName)
		{
			var imageListItem = Items.FirstOrDefault(o => o.Name == imageName);
			var imageinfo = mapper.Map<ImageInfo>(imageListItem);
			var dialogParameters = new DialogParameters();
			dialogParameters.Add(DictKeySet.ImageInfoKey, imageinfo);
			dialogService.ShowDialog("CreateContainer", dialogParameters, o => {
				if (o.Result == ButtonResult.OK)
					Growl.SuccessGlobal($"创建成功！");
			});
			//eventAggregator.GetEvent<CreateContainerSentEvent>().Publish(image);
		}

		string[] GetSelectNames(IEnumerable Selectlist)
		{
			return Selectlist.OfType<ImageListItemModel>().Select(o => o.Name).ToArray();
		}
	}
}
