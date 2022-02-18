using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Wpf.Example
{
    public partial class WordBoxUserControl : UserControl
    {
        public WordBoxUserControl()
        {
            InitializeComponent();
            ucRoot.DataContext = this;
        }

        public static readonly DependencyProperty _words =
            DependencyProperty.Register("WordCollection", typeof(ObservableCollection<WordBoxViewModel>), typeof(WordBoxUserControl),
            new PropertyMetadata(new ObservableCollection<WordBoxViewModel>()));

        public ObservableCollection<WordBoxViewModel> WordCollection
        {
            get => (ObservableCollection<WordBoxViewModel>)GetValue(_words);
            set => SetValue(_words, value);
        }
    }
}
