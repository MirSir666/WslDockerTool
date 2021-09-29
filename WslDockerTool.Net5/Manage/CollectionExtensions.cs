using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WslDockerTool.Net5.Models;

namespace WslDockerTool.Net5.Manage
{
    public  static partial class CollectionExtensions
    {
        public static void AddRange<T>(this Collection<T> collection, params T[] ts)
        {
            if (ts == null) return;
            if (ts.Count() == 0) return;
            foreach (var item in ts)
            {
                collection.Add(item);
            }
        }

        public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> ts)
        {
            if (ts == null) return;
            if (ts.Count() == 0) return;
            foreach (var item in ts)
            {
                collection.Add(item);
            }
        }

        public static void Refresh<T>(this Collection<T> collection, params T[] ts)
        {
            UIThread.Run(() =>
            {
                collection.Clear();
                collection.AddRange(ts);
            });
        }

        public static void Refresh<T>(this Collection<T> collection, IEnumerable<T> ts)
        {
            UIThread.Run(() =>
            {
                collection.Clear();
                collection.AddRange(ts);
            });
		}
	}

    public static partial class CollectionExtensions
    {
        public static IEnumerable<T> GetSelectList<T>(this Collection<T> collection)
            where T: DataGirdMultiple
        {
            return collection.Where(o => o.IsSelected == true).ToArray();
        }
    }





}
