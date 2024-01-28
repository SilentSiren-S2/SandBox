using SandBox.Model;
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

namespace SandBox.View
{
    /// <summary>
    /// Interaction logic for UCStudent.xaml
    /// </summary>
    public partial class UCStudent : UserControl, IStudentCommand
    {
        private IStudent _student;
        private IStudentState _studentState;
        public event EventHandler StudentTimerTick;

        public UCStudent(IStudent student) : this()
        {
            _student = student;
            lName.Content = student.ToString();
        }

        public UCStudent()
        {
            InitializeComponent();
            _studentState = new LearningState();
        }

        public void OnTimerTick()
        {
            StudentTimerTick?.Invoke(this, EventArgs.Empty);
            _studentState.DoProsess(_student);
            lExp.Content = _student.Exp;
            lPoints.Content = _student.Points;
            pbEnergy.Value = _student.Energy;
        }

        private void StudyButton_Click(object sender, RoutedEventArgs e)
        {
            Study();
        }

        private void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            Work();
        }

        private void RestButton_Click(object sender, RoutedEventArgs e)
        {
            Relax();
        }

        public void Study()
        {
            LearningState learningState = new LearningState();
            _studentState = learningState;
            learningState.Handle(_student);
        }

        public void Relax()
        {
            RelaxingState relaxingState = new RelaxingState();
            _studentState = relaxingState;
            relaxingState.Handle(_student);
        }

        public void Work()
        {
            WorkingState workingState = new WorkingState();
            _studentState = workingState;
            workingState.Handle(_student);
        }

        internal void Scholarship()
        {
            _student.Points += 1000;
        }

        internal void Dispose()
        {
            _student = null;
            StudentTimerTick = null;
            StackPanel sp = (StackPanel)this.Parent;
            sp.Children.Remove(this);
            //if (_studentState is IDisposable disposableState)
            //{
            //    disposableState.Dispose();
            //}
        }

        private void Kick_Click(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        private void Scholarship_Click(object sender, RoutedEventArgs e)
        {
            Scholarship();
        }

        private void lName_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            myPopup.IsOpen = true;
        }
    }
}
