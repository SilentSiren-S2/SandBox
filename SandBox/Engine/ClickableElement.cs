using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SandBox.Engine
{
    public class ClickableElement : Button
    {
        private Random random = new Random();
        private DispatcherTimer timer;
        public ClickableElement() 
        {
            Height = 44; Width = 84;
            Content = "Воїн";
            // Додайте обробники подій для переміщення
            MouseLeftButtonDown += ClickableElement_MouseLeftButtonDown;
            MouseMove += ClickableElement_MouseMove;
            MouseLeftButtonUp += ClickableElement_MouseLeftButtonUp;

            // Ініціалізуйте таймер для автоматичного переміщення
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100); // кожні 100 мілісекунд
            timer.Tick += Timer_Tick;
            timer.Start();

            // Додайте обробники подій для переміщення
            MouseLeftButtonDown += ClickableElementDrug_MouseLeftButtonDown;
            MouseMove += ClickableElementDrug_MouseMove;
            MouseLeftButtonUp += ClickableElementDrug_MouseLeftButtonUp;
        }

        private bool isDragging = false;
        private Point offset;
        private void ClickableElementDrug_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            offset = e.GetPosition(this);
        }

        private void ClickableElementDrug_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point position = e.GetPosition(Parent as UIElement);
                Canvas.SetLeft(this, position.X - offset.X);
                Canvas.SetTop(this, position.Y - offset.Y);
            }
        }

        private void ClickableElementDrug_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void ClickableElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            offset = e.GetPosition(this);
        }

        private void ClickableElement_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point position = e.GetPosition(Parent as UIElement);
                Canvas.SetLeft(this, position.X - offset.X);
                Canvas.SetTop(this, position.Y - offset.Y);
            }
        }

        private void ClickableElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Автоматичне переміщення на випадковий відстань
            double deltaX = random.Next(-8, 9); // випадковий зсув по осі X від -5 до 5
            double deltaY = random.Next(-8, 9); // випадковий зсув по осі Y від -5 до 5

            // Отримайте поточні позиції
            double currentLeft = Canvas.GetLeft(this);
            double currentTop = Canvas.GetTop(this);

            // Встановіть нові позиції
            Canvas.SetLeft(this, currentLeft + deltaX);
            Canvas.SetTop(this, currentTop + deltaY);
        }
    }
}
