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

namespace QuestBoardSBV.QuestView
{
    /// <summary>
    /// Interaction logic for UCQuest.xaml
    /// </summary>
    public partial class UCQuest : UserControl
    {
        public Canvas canvas;
        private Point startPoint;
        private BasicQuest _quest;
        public UCQuest()
        {
            InitializeComponent();
            MouseLeftButtonDown += OnMouseLeftButtonDown;
            MouseMove += OnMouseMove;
            MouseLeftButtonUp += OnMouseLeftButtonUp;
        }

        internal void SetQuest(ref BasicQuest quest)
        {
            _quest = quest;
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
            _quest.Name = tbName.Text;
        }

        private void tbInfo_TextChanged(object sender, TextChangedEventArgs e)
        {
            _quest.Description = tbInfo.Text;
        }
    }
}
