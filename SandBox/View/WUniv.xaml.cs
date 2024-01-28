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
using System.Windows.Threading;
using SandBox.Model;

namespace SandBox.View
{
    /// <summary>
    /// Interaction logic for WUniv.xaml
    /// </summary>
    public partial class WUniv : Window
    {
        private University _university; 
        private System.Windows.Threading.DispatcherTimer timer;
        private StackPanel activePanel;


        public WUniv()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            _university = new University();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            // Створюємо таймер
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Встановлюємо інтервал таймера на n секунд
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            IStudent student = _university.CreateStudent();
            UCStudent ucStudent = new UCStudent(student);

            string specialtyName = GetSpecialtyName(student);
            StackPanel targetStackPanel = FindStackPanelByName(specialtyName);

            if (targetStackPanel != null)
            {
                targetStackPanel.Children.Add(ucStudent);
            }

            #region window stud
            // ws = new WStudent(_university.CreateStudent());
            //
            //ws.Show();

            //(Application.Current as App).CreateStudWindows.Add(ws);
            #endregion
        }


        private void Timer_TickOld(object sender, EventArgs e)
        {
            // Цей метод буде викликатися на кожному тіку таймера
            foreach (UIElement element in spStudents.Children)
            {
                if (element is UCStudent ucStudent)
                {
                    ucStudent.OnTimerTick();
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (StackPanel stackPanel in pFill.Children)
            {
                if (stackPanel is StackPanel && stackPanel.Children.Count > 0)
                {
                    Task.Run(() =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            foreach (UIElement element in stackPanel.Children)
                            {
                                if (element is UCStudent ucStudent)
                                {
                                    ucStudent.OnTimerTick();
                                }
                            }
                        });
                    });
                }
            }
        }

        private string GetSpecialtyName(IStudent student)
        {
            if (student is Mathematician)
                return "spMathematician";
            else if (student is Statistician)
                return "spStatistician";
            else if (student is ComputerMechanic)
                return "spComputerMechanic3";
            else if (student is ComputerMathematician)
                return "spComputerMathematician";
            else if (student is Educator)
                return "spEducator";
            else
                return "spStudents";
        }

        private StackPanel FindStackPanelByName(string stackPanelName)
        {
            return (StackPanel)pFill.FindName(stackPanelName);
        }

        private void speciality_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            myPopup.IsOpen = true;
            activePanel = (StackPanel)sender;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //activePanel.Name;
        }

        private void Kick_Click(object sender, RoutedEventArgs e) 
        {
            List<UIElement> elementsToRemove = new List<UIElement>();
            foreach (UIElement element in activePanel.Children)
            {
                if (element is UCStudent ucStudent)
                {
                    elementsToRemove.Add(element);
                }
            }
            foreach (UIElement elementToRemove in elementsToRemove)
            {
                activePanel.Children.Remove(elementToRemove);
            }
        }

        private void Scholarship_Click(object sender, RoutedEventArgs e) 
        {
            foreach (UIElement element in activePanel.Children)
            {
                if (element is UCStudent ucStudent)
                {
                    ucStudent.Scholarship();
                }
            }
        }

        private void Work_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in activePanel.Children)
            {
                if (element is UCStudent ucStudent)
                {
                    ucStudent.Work();
                }
            }
        }

        private void Learn_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in activePanel.Children)
            {
                if (element is UCStudent ucStudent)
                {
                    ucStudent.Study();
                }
            }
        }

        private void Relax_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in activePanel.Children)
            {
                if (element is UCStudent ucStudent)
                {
                    ucStudent.Relax();
                }
            }
        }
    }
}
