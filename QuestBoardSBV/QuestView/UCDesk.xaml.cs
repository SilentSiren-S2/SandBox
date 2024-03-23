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
    /// Interaction logic for UCDesk.xaml
    /// </summary>
    public partial class UCDesk : UserControl
    {
        public List<BasicQuest> quests;
        public UCDesk()
        {
            InitializeComponent();
        }

        public UCDesk(List<BasicQuest> quests) : this()
        {
            this.quests = quests;
            OpenQuests();
        }

        public void InitQuests(List<BasicQuest> lq)
        {
            quests = lq;
            OpenQuests();
        }

        //private void OpenQuests()
        //{
        //    OpenQuests(quests);
        //}

        private void OpenQuests(List<BasicQuest> questsToShow = null)
        {
            List<BasicQuest> questsToDisplay = questsToShow ?? quests;

            int i = 0;
            foreach (BasicQuest quest in questsToDisplay)
            {
                UCQuest uCQuest = new UCQuest(DeskCanvas);
                uCQuest.SetQuest(quest);
                uCQuest.QuestUpdatedInUCQuest += UpdateQuestInMainWindow;
                DeskCanvas.Children.Add(uCQuest);
                Canvas.SetLeft(uCQuest, i);
                Canvas.SetTop(uCQuest, 0);
                uCQuest.startPoint = new System.Windows.Point(i, 0);
                i += 60;
            }
        }

        private void UpdateQuestInMainWindow(BasicQuest updatedQuest)
        {
            // Оновіть відповідний елемент у списку quests
            int index = quests.FindIndex(q => q == updatedQuest);
            if (index != -1)
            {
                quests[index] = updatedQuest;
            }
        }

        internal void AddQuest()
        {
            BasicQuest newQuest = new BasicQuest();
            quests.Add(newQuest);
            UCQuest uCQuest = new UCQuest();
            uCQuest.SetQuest(newQuest);
            uCQuest.QuestUpdatedInUCQuest += UpdateQuestInMainWindow;

            DeskCanvas.Children.Add(uCQuest);
            Canvas.SetLeft(uCQuest, 0);
            Canvas.SetTop(uCQuest, 0);
        }

        public void ApplyFilter(QuestType selectedType, bool showCompleted)
        {
            // Очистити вміст Canvas
            DeskCanvas.Children.Clear();

            // Отримати список квестів, які відповідають фільтру
            var filteredQuests = quests.Where(q => (q.QType == selectedType || selectedType == QuestType.NoType) && (q.IsDone == showCompleted || !q.IsDone)).ToList();

            // Відобразити відфільтровані квести на Canvas
            OpenQuests(filteredQuests);
        }
    }
}
