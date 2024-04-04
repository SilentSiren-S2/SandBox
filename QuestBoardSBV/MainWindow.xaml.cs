using QuestBoardSBV.QuestLegacy;
using QuestBoardSBV.QuestView;
using System.IO;
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
using System.Xml.Serialization;

namespace QuestBoardSBV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BasicQuest> quests = new List<BasicQuest> { };
        //UCDesk mainDesk;
        public MainWindow()
        {
            InitializeComponent();

            AddNewTabWithDesk();
            quests = XmlUtils.LoadData<BasicQuest>("quests.xml", XmlUtils.StorageLocation.ProjectBin);
            lvLeft.ItemsSource = quests;
            
            mainDesk.InitQuests(quests);
        }

        private void AddNewTabWithDesk()
        {
            TabItem newTab = new TabItem();
            newTab.Header = "Новий таб";
            UCDesk deskContent = new UCDesk(quests);
            newTab.Content = deskContent;

            tabControl.Items.Add(newTab);
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //AddQuest();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            quests = mainDesk.quests;
            XmlUtils.SaveDataToBin(quests, "quests.xml");
        }

        private void bFilter_Click(object sender, RoutedEventArgs e)
        {
            WFilter filter = new WFilter();
            filter.Init(mainDesk);
        }

        private void bCreateNewQuest_Click(object sender, RoutedEventArgs e)
        {
            mainDesk.AddQuest();
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

    public static class XmlTestUtils
    {
        public static List<BasicQuest> LoadQuests()
        {
            List<BasicQuest> quests = new List<BasicQuest> { };
            XmlSerializer serializer = new XmlSerializer(typeof(List<BasicQuest>));
            if (File.Exists("quests.xml"))
            {
                using (FileStream fs = new FileStream("quests.xml", FileMode.Open))
                {
                    quests = (List<BasicQuest>)serializer.Deserialize(fs);
                }
            }
            return quests;
        }

        public static void SaveQuests(List<BasicQuest> quests)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BasicQuest>));
            using (FileStream fs = new FileStream("quests.xml", FileMode.Create))
            {
                serializer.Serialize(fs, quests);
            }
        }
    }
    #endregion
}