using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace WslDockerTool.Net5.Controls
{
    /// <summary>
    /// SearchComboBox.xaml 的交互逻辑
    /// 来源 https://github.com/vain0x/DotNetKit.Wpf.AutoCompleteComboBox
    /// </summary>
    public partial class SearchComboBox : ComboBox
    {
        private readonly SerialDisposable disposable = new SerialDisposable();

        private TextBox editableTextBoxCache;

        private Predicate<object> defaultItemsFilter;

        private bool _ignoreTextChanged;

        public SearchComboBox()
        {
            InitializeComponent();
            AddHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(OnTextChanged));
        }

        public TextBox EditableTextBox
        {
            get
            {
                if (editableTextBoxCache == null)
                {
                    const string name = "PART_EditableTextBox";
                    editableTextBoxCache = (TextBox)FindChild(this, name);
                }
                return editableTextBoxCache;
            }
        }

        public FrameworkElement FindChild(DependencyObject obj, string childName)
        {
            if (obj == null) return null;

            var queue = new Queue<DependencyObject>();
            queue.Enqueue(obj);

            while (queue.Count > 0)
            {
                obj = queue.Dequeue();

                var childCount = VisualTreeHelper.GetChildrenCount(obj);
                for (var i = 0; i < childCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(obj, i);

                    var fe = child as FrameworkElement;
                    if (fe != null && fe.Name == childName)
                    {
                        return fe;
                    }

                    queue.Enqueue(child);
                }
            }

            return null;
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);

            defaultItemsFilter = newValue is ICollectionView cv ? cv.Filter : null;
        }

        /// <summary>
        /// Gets text to match with the query from an item.
        /// Never null.
        /// 获取与项中的查询匹配的文本。
        /// </summary>
        /// <param name="item"/>
        private string TextFromItem(object item)
        {
            if (item == null) return string.Empty;

            var d = new DependencyVariable<string>();
            d.SetBinding(item, TextSearch.GetTextPath(this));
            return d.Value ?? string.Empty;
        }

        #region Setting

        private static readonly DependencyProperty settingProperty =
            DependencyProperty.Register(
                "Setting",
                typeof(SearchComboBoxSetting),
                typeof(SearchComboBox)
            );

        public static DependencyProperty SettingProperty
        {
            get { return settingProperty; }
        }

        public SearchComboBoxSetting Setting
        {
            get { return (SearchComboBoxSetting)GetValue(SettingProperty); }
            set { SetValue(SettingProperty, value); }
        }

        private SearchComboBoxSetting SettingOrDefault
        {
            get { return Setting ?? SearchComboBoxSetting.Default; }
        }

        #endregion Setting

        #region OnTextChanged

        private long revisionId;
        private string previousText;

        private static int CountWithMax<T>(IEnumerable<T> xs, Predicate<T> predicate, int maxCount)
        {
            var count = 0;
            foreach (var x in xs)
            {
                if (predicate(x))
                {
                    count++;
                    if (count > maxCount) return count;
                }
            }
            return count;
        }

        private void Unselect()
        {
            var textBox = EditableTextBox;
            textBox.Select(textBox.SelectionStart + textBox.SelectionLength, 0);
        }

        private void UpdateFilter(Predicate<object> filter)
        {
            using (new TextBoxStatePreserver(EditableTextBox))
            using (Items.DeferRefresh())
            {
                // Can empty the text box. I don't why.
                Items.Filter = filter;
            }
        }

        private void OpenDropDown(Predicate<object> filter)
        {
            UpdateFilter(filter);
            IsDropDownOpen = true;
            Unselect();
        }

        private void OpenDropDown()
        {
            var filter = GetFilter();
            OpenDropDown(filter);
        }

        private void UpdateSuggestionList()
        {
            var text = Text;

            if (text == previousText) return;
            previousText = text;

            if (string.IsNullOrEmpty(text))
            {
                IsDropDownOpen = false;
                SelectedItem = null;

                using (Items.DeferRefresh())
                {
                    Items.Filter = defaultItemsFilter;
                }
            }
            else if (SelectedItem != null && TextFromItem(SelectedItem) == text)
            {
                // It seems the user selected an item.
                // Do nothing.
                //用户似乎选择了一个项目。
                //什么都不做。
            }
            else
            {
                using (new TextBoxStatePreserver(EditableTextBox))
                {
                    SelectedItem = null;
                }

                var filter = GetFilter();
                var maxCount = SettingOrDefault.MaxSuggestionCount;
                var count = CountWithMax(ItemsSource?.Cast<object>() ?? Enumerable.Empty<object>(), filter, maxCount);

                if (count > maxCount) return;

                OpenDropDown(filter);
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var id = unchecked(++revisionId);
            var setting = SettingOrDefault;

            if (setting.Delay <= TimeSpan.Zero)
            {
                UpdateSuggestionList();
                return;
            }

            disposable.Content =
                new Timer(
                    state =>
                    {
                        Dispatcher.InvokeAsync(() =>
                        {
                            if (revisionId != id) return;

                            if (!_ignoreTextChanged)
                                return;

                            _ignoreTextChanged = false;

                            UpdateSuggestionList();
                        });
                    },
                    null,
                    setting.Delay,
                    Timeout.InfiniteTimeSpan
                );
        }

        private struct TextBoxStatePreserver : IDisposable
        {
            private readonly TextBox textBox;
            private readonly int selectionStart;
            private readonly int selectionLength;
            private readonly string text;

            public TextBoxStatePreserver(TextBox textBox)
            {
                this.textBox = textBox;
                selectionStart = textBox.SelectionStart;
                selectionLength = textBox.SelectionLength;
                text = textBox.Text;
            }

            public void Dispose()
            {
                textBox.Text = text;
                textBox.Select(selectionStart, selectionLength);
            }
        }

        #endregion OnTextChanged

        private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _ignoreTextChanged = true;

            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.Space)
            {
                OpenDropDown();
                e.Handled = true;
            }
        }


        private Predicate<object> GetFilter()
        {
            var filter = SettingOrDefault.GetFilter(Text, TextFromItem);

            return defaultItemsFilter != null
                ? i => defaultItemsFilter(i) && filter(i)
                : filter;
        }
    }
}