using System.Windows;

namespace Wpf.Example
{
    public class AlignmentData : BindableBase
    {
        public string SourceWord { get; set; }
        public string TargetWord { get; set; }

        public string ToolTipText
        {
            get
            {
                return $"Source: {SourceWord}\r\nTarget: {TargetWord}";
            }
        }

        private Point _TargetPoint = new Point(0, 0);
        public Point TargetPoint
        {
            get => _TargetPoint;
            set { SetProperty(ref _TargetPoint, value, nameof(TargetPoint)); }
        }

        private Point _SourcePoint = new Point(0, 0);
        public Point SourcePoint
        {
            get => _SourcePoint;
            set { SetProperty(ref _SourcePoint, value, nameof(SourcePoint)); }
        }
    }
}