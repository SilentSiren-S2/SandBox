using QuestBoardSBV.QuestLegacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace QuestBoardSBV.QuestView
{
    /// <summary>
    /// Interaction logic for UCQuest.xaml
    /// </summary>
    public partial class UCQuest : UserControl
    {
        public Canvas canvas;
        public Point startPoint;
        private BasicQuest _quest;
        public BasicQuest Quest
        {
            get { return _quest; }
            set
            {
                _quest = value;
                QuestUpdatedInUCQuest?.Invoke(_quest);
            }
        }

        public string Name 
        {
            get { return _quest.Name; }
            set
            {
                _quest.Name = value;
                QuestUpdatedInUCQuest?.Invoke(_quest);
            }
        }
        public string Description 
        {
            get { return _quest.Description; }
            set
            {
                _quest.Description = value;
                QuestUpdatedInUCQuest?.Invoke(_quest);
            }
        }

        public event Action<BasicQuest> QuestUpdatedInUCQuest;

        public UCQuest()
        {
            InitializeComponent();
            MouseLeftButtonDown += OnMouseLeftButtonDown;
            MouseMove += OnMouseMove;
            MouseLeftButtonUp += OnMouseLeftButtonUp;
        }

        internal void SetQuest(BasicQuest quest)
        {
            _quest = quest;
            tbName.Text = quest.Name;
            tbInfo.Text = quest.Description;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CaptureMouse();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Point currentPoint = e.GetPosition(canvas);
                double dX = currentPoint.X - startPoint.X;
                double dY = currentPoint.Y - startPoint.Y;

                Canvas.SetLeft(this, Canvas.GetLeft(this) + dX);
                Canvas.SetTop(this, Canvas.GetTop(this) + dY);

                startPoint = currentPoint;
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = tbName.Text;
        }

        private void tbInfo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Description = tbInfo.Text;
        }
    }
}
