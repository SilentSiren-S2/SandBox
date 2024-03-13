using QuestBoardSBV.QuestLegacy;
using QuestBoardSBV.QuestView;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuestBoardSBV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BasicQuest> quests = new List<BasicQuest> { };
        public MainWindow()
        {
            InitializeComponent();
            AddQuest();
        }

        private void AddQuest()
        {
            BasicQuest newQuest = new BasicQuest();
            quests.Add(newQuest);
            UCQuest uCQuest = new UCQuest();
            uCQuest.SetQuest(ref newQuest);


            canvas.Children.Add(uCQuest);
            Canvas.SetLeft(uCQuest, 0);
            Canvas.SetTop(uCQuest, 0);
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddQuest();
        }
    }




    #region тестовий утиль
    public class DraggableComponent : UserControl
    {
        public Canvas canvas;
        private Point startPoint;

        public DraggableComponent()
        {
            MouseLeftButtonDown += OnMouseLeftButtonDown;
            MouseMove += OnMouseMove;
            MouseLeftButtonUp += OnMouseLeftButtonUp;
            Background = Brushes.Transparent;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CaptureMouse();
            //startPoint = e.GetPosition(this);
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
    }
    #endregion
}