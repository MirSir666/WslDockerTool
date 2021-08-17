using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Core.Mvvm
{
	public abstract class Collection<T>: BindableBase
		where T:class
	{

		readonly ObservableCollection<T> items = new ObservableCollection<T>();

		private bool _isAllSelected = false;

		public ObservableCollection<T> Items
		{
			get { return items; }
		}

	


	}
}
