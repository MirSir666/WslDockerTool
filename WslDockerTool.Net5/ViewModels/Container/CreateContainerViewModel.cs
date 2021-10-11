using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Core.Mvvm;
using WslDockerTool.Shared;

namespace WslDockerTool.Net5.ViewModels.Container
{
	public class CreateContainerViewModel: DialogViewModelBase
	{
		private readonly IContainerHandler containerHandler;

		public CreateContainerViewModel(IContainerHandler containerHandler)
		{
			this.Title = "添加容器";
			CloseCommand = new DelegateCommand<ButtonResult?>(CloseAction);
			this.containerHandler = containerHandler;
		}

		    public DelegateCommand<ButtonResult?> CloseCommand { get; set; }

		private void CloseAction(ButtonResult? parameter)
		{
			ButtonResult button = parameter ?? ButtonResult.None;
			if (button == ButtonResult.OK)
			{
				containerHandler.cr
			}
			RaiseRequestClose(new DialogResult(button, new DialogParameters()));
		}

	}
}
