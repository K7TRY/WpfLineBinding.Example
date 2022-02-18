using System.Collections.ObjectModel;
using System.Linq;

namespace Wpf.Example
{
    public class AlignmentViewModel
    {
        public ObservableCollection<WordBoxViewModel> SourceWords { get; set; } = new ObservableCollection<WordBoxViewModel>();
        public ObservableCollection<WordBoxViewModel> TargetWords { get; set; } = new ObservableCollection<WordBoxViewModel>();

        public ObservableCollection<AlignmentData> Alignments { get; set; } = new ObservableCollection<AlignmentData>();

        public AlignmentViewModel()
        {
            foreach (int i in Enumerable.Range(1, 5))
            {
                SourceWords.Add(new WordBoxViewModel
                {
                    Word = $"Test {i}"
                });
            };

            foreach (char c in Enumerable.Range('A', 'J').Take(5))
            {
                TargetWords.Add(new WordBoxViewModel
                {
                    Word = $"Test {c}"
                });
            };
        }
    }
}
