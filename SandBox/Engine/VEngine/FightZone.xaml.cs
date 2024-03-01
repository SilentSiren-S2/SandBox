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

namespace SandBox.Engine.VEngine
{
    /// <summary>
    /// Interaction logic for FightZone.xaml
    /// </summary>
    public partial class FightZone : Window
    {
        private List<WarriorPack.Warrior> warriors;

        public FightZone()
        {
            InitializeComponent();
            warriors = new List<WarriorPack.Warrior>();
        }

        private void FightZone_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Створіть нового воїна та додайте його до списку та Canvas
            //Отримайте позицію натискання миші відносно Canvas
            Point position = e.GetPosition(MainCanvas);
            WarriorPack.Warrior warrior = new WarriorPack.Warrior(MainCanvas, warriors, position);
            warriors.Add(warrior);
        }


        #region TempestSample
        //private void FightZone_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    // Створіть новий екземпляр ClickableElement
        //    ClickableElement clickableElement = new ClickableElement();

        //    // Отримайте позицію натискання миші відносно Canvas
        //    Point position = e.GetPosition(MainCanvas);

        //    // Встановіть позицію елемента
        //    Canvas.SetLeft(clickableElement, position.X - clickableElement.Width / 2);
        //    Canvas.SetTop(clickableElement, position.Y - clickableElement.Height / 2);

        //    // Додайте його до Canvas
        //    MainCanvas.Children.Add(clickableElement);
        //}
        #endregion
    }
}
