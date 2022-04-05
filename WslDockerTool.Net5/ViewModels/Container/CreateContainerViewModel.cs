using AutoMapper;
using Docker.DotNet.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core;
using WslDockerTool.Net5.Core.Events;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Net5.Manage;
using WslDockerTool.Net5.Models;
using WslDockerTool.Net5.Models.Image;
using WslDockerTool.Shared;

namespace WslDockerTool.Net5.ViewModels.Container
{
    public class CreateContainerViewModel : DialogViewModelBase
    {
        private readonly IContainerHandler containerHandler;
        private readonly IImageHandler imageHandler;
        private readonly IMapper mapper;
        private readonly IEventAggregator eventAggregator;

        public CreateContainerViewModel(IContainerHandler containerHandler, IImageHandler imageHandler, IMapper mapper, IEventAggregator eventAggregator)
        {
            this.Title = "添加容器";
            CloseCommand = new DelegateCommand<ButtonResult?>(CloseAction);
            this.containerHandler = containerHandler;
            this.imageHandler = imageHandler;
            this.mapper = mapper;
            this.eventAggregator = eventAggregator;

            //this.eventAggregator.GetEvent<CreateContainerSentEvent>()
            //	.Subscribe(e =>
            //	{
            //		ImageId = e.ID;
            //		ImageName = e.Name;
            //	});
            Init();
        }

        public async void Init()
        {
            var ret = await imageHandler.ListImagesAsync(new Docker.DotNet.Models.ImagesListParameters());
            var list = mapper.Map<List<ComboBoxSelectItem>>(ret);
            this.ImageList.Refresh(list);
            if (!IsDialogParametersNull)
                this.SelectedImage = ImageList.FirstOrDefault(o => o.Name == ImageName);

        }

        public ObservableCollection<ComboBoxSelectItem> ImageList { get; set; } = new ObservableCollection<ComboBoxSelectItem>();

        private ComboBoxSelectItem selectedImage;
        public ComboBoxSelectItem SelectedImage
        {
            get { return selectedImage; }
            set
            {
                SetProperty(ref selectedImage, value);
                SwitchImage();
            }
        }
        public async void SwitchImage()
        {
            var imageInspect = await imageHandler.InspectImageAsync(SelectedImage.Value.ToString());

            var strs = imageInspect?.Config?.ExposedPorts?.Select(o => $"{o.Key.Split('/').First()}:{o.Key.Split('/').First()}").ToList();
            this.Ports = String.Join('|', strs);
            this.ImageId=selectedImage.Value.ToString();
            this.ImageName = selectedImage.Name;
        }

        private bool isDialogParametersNull = true;
        private string ports;

        public bool IsDialogParametersNull { get => isDialogParametersNull; set => SetProperty(ref isDialogParametersNull, value); }

        public string ImageId { get; set; }
        public string ImageName { get; set; }
        public string ContainerName { get; set; }
        public string Ports { get => ports; set => SetProperty(ref ports, value); }
        public string Envs { get; set; }
        public string Volumes { get; set; }

        public DelegateCommand<ButtonResult?> CloseCommand { get; set; }

        private void CloseAction(ButtonResult? parameter)
        {
            ButtonResult button = parameter ?? ButtonResult.None;
            if (button == ButtonResult.OK)
            {
                containerHandler.CreateContainerAsync(mapper.Map<CreateContainerParameters>(this));
            }
            RaiseRequestClose(new DialogResult(button, new DialogParameters()));
        }



        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var info = parameters.GetValue<ImageInfo>(DictKeySet.ImageInfoKey);
            if (info == null) return;
            this.ImageId = info.ID;
            this.ImageName = info.Name;
            this.IsDialogParametersNull = false;

        }

    }
}
