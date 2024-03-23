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
using System.Windows.Shapes;

namespace QuestBoardSBV.QuestView
{
    /// <summary>
    /// Interaction logic for WFilter.xaml
    /// </summary>
    public partial class WFilter : Window
    {
        private UCDesk filteredDesk;

        public WFilter()
        {
            InitializeComponent();
        }

        internal void Init(UCDesk desk)
        {
            filteredDesk = desk;
            ShowDialog();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Отримати обрані значення фільтрів
            QuestType selectedType = (QuestType)cbQuestType.SelectedIndex;
            bool showCompleted = chkIsDone.IsChecked ?? false;

            // Викликати метод фільтрації у UCDesk
            filteredDesk.ApplyFilter(selectedType, showCompleted);

            // Закрити вікно фільтру
            Close();
        }
    }
}
