using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
using TempestEngine.Elements;
using TempestEngine.Logic;

namespace SandBox.Engine.VEngine
{
    /// <summary>
    /// Interaction logic for FightZone2.xaml
    /// </summary>
    public partial class FightZone2 : Window
    {
        private AlphaWarrior player;
        public FightZone2()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            player = new AlphaWarrior(new PlayerMove());
            DrawPlayer();
        }

        private void DrawPlayer()
        {
            // Ваш код для відображення гравця на канвасі
            // Наприклад, створення прямокутника або іншої фігури
            Rectangle playerRectangle = new Rectangle
            {
                Width = player.Width,
                Height = player.Height,
                Fill = Brushes.Green // Замініть це на вашу власну логіку для відображення гравця
            };

            Canvas.SetLeft(playerRectangle, player.X);
            Canvas.SetTop(playerRectangle, player.Y);

            MainCanvas.Children.Add(playerRectangle);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Обробка натискання клавіш для переміщення гравця
            switch (e.Key)
            {
                case Key.W:
                    player.Move();
                    break;
                case Key.S:
                    player.Move();
                    break;
                case Key.A:
                    player.Move();
                    break;
                case Key.D:
                    player.Move();
                    break;

                    // Додайте обробку інших клавіш, якщо потрібно
            }

            UpdatePlayerPosition();
        }

        private void UpdatePlayerPosition()
        {
            // Очищення канвасу
            MainCanvas.Children.Clear();

            // Відображення гравця на новій позиції
            DrawPlayer();
        }
    }
}
