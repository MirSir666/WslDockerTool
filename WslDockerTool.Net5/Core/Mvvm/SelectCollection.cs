using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Models;

namespace WslDockerTool.Net5.Core.Mvvm
{
	public abstract class SelectCollection<T>: Collection<T>
		where T:class,DataGirdMultiple
	{

		private bool _isAllSelected = false;

		public void CheckAll()
		{
			_isAllSelected = !_isAllSelected;
			foreach (var item in Items)
				item.IsSelected = _isAllSelected;
			
		}
	}
}
