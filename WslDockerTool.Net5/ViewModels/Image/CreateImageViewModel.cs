using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core;
using WslDockerTool.Net5.Core.Mvvm;

namespace WslDockerTool.Net5.ViewModels
{
    public class CreateImageViewModel : DialogViewModelBase
    {

		//private readonly IContainerHandler containerHandler;

		public CreateImageViewModel()//(IContainerHandler containerHandler)
		{
			this.Title = "拉取镜像";
			CloseCommand = new DelegateCommand<ButtonResult?>(CloseAction);
			//this.containerHandler = containerHandler;
		}

		public string ImageName { get; set; } 

        public DelegateCommand<ButtonResult?> CloseCommand { get; set; }

		private void CloseAction(ButtonResult? parameter)
		{
			ButtonResult button = parameter ?? ButtonResult.None;
			//if (button == ButtonResult.OK)
			//{
			//}
			var parames = new DialogParameters() ;
			parames.Add(DictKeySet.ImageNameKey, ImageName);
			RaiseRequestClose(new DialogResult(button, parames));
		}
	}
}
