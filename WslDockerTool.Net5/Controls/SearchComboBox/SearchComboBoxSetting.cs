using System;

namespace WslDockerTool.Net5.Controls
{
    public class SearchComboBoxSetting
    {
        private static SearchComboBoxSetting @default = new SearchComboBoxSetting();

        /// <summary>
        /// Gets the default setting.
        /// </summary>
        public static SearchComboBoxSetting Default
        {
            get { return @default; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                @default = value;
            }
        }

        /// <summary>
        /// Gets an integer.
        /// The combobox opens the drop down
        /// if the number of suggested items is less than the value.
        /// Note that the value is larger, it's heavier to open the drop down.
        /// Default: 100.
        /// 获取整数。
        /// 组合框打开下拉列表
        /// 如果建议的项目数小于该值。
        /// 请注意，该值越大，打开下拉列表就越重。
        /// 默认值：100。
        /// </summary>
        public virtual int MaxSuggestionCount
        {
            get { return 100; }
        }

        /// <summary>
        /// Gets the duration to delay updating the suggestion list.
        /// 获取延迟更新建议列表的持续时间。
        /// Returns <c>Zero</c> if no delay.
        /// Default: 300ms.
        /// </summary>
        public virtual TimeSpan Delay
        {
            get { return TimeSpan.FromMilliseconds(500.0); }
        }

        /// <summary>
        /// Gets a filter function which determines whether items should be suggested or not
        /// for the specified query.
        /// Default: Gets the filter which maps an item to <c>true</c>
        /// if its text contains the query (case insensitive).
        /// </summary>
        /// <param name="query">
        /// The string input by user.
        /// 用户输入的字符串。
        /// </param>
        /// <param name="stringFromItem">
        /// The function to get a string which identifies the specified item.
        /// 获取标识指定项的字符串的函数。
        /// </param>
        /// <returns></returns>
        public virtual Predicate<object> GetFilter(string query, Func<object, string> stringFromItem)
        {
            return item => stringFromItem(item).IndexOf(query, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}