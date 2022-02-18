using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.Example
{
    public partial class MainWindow : Window
    {
        private AlignmentViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new AlignmentViewModel();
            DataContext = viewModel;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SetAlignmentLines();
        }

        public void SetAlignmentLines()
        {
            viewModel.Alignments.Add(new AlignmentData() { SourceWord = "Test 1", TargetWord = "Test C" });
            viewModel.Alignments.Add(new AlignmentData() { SourceWord = "Test 2", TargetWord = "Test E" });
            viewModel.Alignments.Add(new AlignmentData() { SourceWord = "Test 3", TargetWord = "Test A" });
            viewModel.Alignments.Add(new AlignmentData() { SourceWord = "Test 4", TargetWord = "Test D" });
            viewModel.Alignments.Add(new AlignmentData() { SourceWord = "Test 5", TargetWord = "Test B" });

            foreach (var a in viewModel.Alignments)
            {
                a.SourcePoint = GetWordBlockPoint(a.SourceWord, true);
                a.TargetPoint = GetWordBlockPoint(a.TargetWord, false);
            }
        }

        private Point GetWordBlockPoint(string wordText, bool source)
        {
            var textBlock = RecurseChildren<TextBlock>(Application.Current.MainWindow).Where(w => w.Text == wordText).FirstOrDefault();
            Border parentBorder = textBlock.Parent as Border;
            Grid parentGrid = parentBorder.Parent as Grid;
            double centerWidthPoint = parentGrid.ActualWidth / 2;
            double bottomPoint = source ? parentGrid.ActualHeight : 0;

            return parentGrid.TransformToAncestor((Visual)this).Transform(new Point(centerWidthPoint, bottomPoint));
        }

        public static IEnumerable<T> RecurseChildren<T>(DependencyObject root) where T : UIElement
        {
            if (root is T)
            {
                yield return root as T;
            }

            if (root != null)
            {
                var count = VisualTreeHelper.GetChildrenCount(root);

                for (var idx = 0; idx < count; idx++)
                {
                    foreach (var child in RecurseChildren<T>(VisualTreeHelper.GetChild(root, idx)))
                    {
                        yield return child;
                    }
                }
            }
        }
    }
}
