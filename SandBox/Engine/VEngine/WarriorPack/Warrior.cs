using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using TempestEngine;
using TempestEngine.Elements;

namespace SandBox.Engine.VEngine.WarriorPack
{
    class Warrior : IEntity
    {
        private Canvas canvas;
        private Ellipse warriorEllipse;
        private Random random = new Random();
        private DispatcherTimer movementTimer;
        private List<Warrior> enemies;
        private int health = 100; // Початкове здоров'я public int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Warrior(Canvas canvas, List<Warrior> enemies, Point position)
        {
            this.canvas = canvas;
            this.enemies = enemies;

            InitializeWarrior(position);
            InitializeMovementTimer();
        }

        private void InitializeWarrior(Point position)
        {
            warriorEllipse = new Ellipse
            {
                Width = 25,
                Height = 40,
                Fill = Brushes.LimeGreen                
            };

            // Позиція
            Canvas.SetLeft(warriorEllipse, position.X - warriorEllipse.Width / 2);
            Canvas.SetTop(warriorEllipse, position.Y - warriorEllipse.Height / 2);


            canvas.Children.Add(warriorEllipse);
        }

        private void InitializeMovementTimer()
        {
            movementTimer = new DispatcherTimer();
            movementTimer.Interval = TimeSpan.FromMilliseconds(100);
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            MoveTowardsEnemy();
            CheckCollisions();
        }

        private void MoveTowardsEnemy()
        {
            if (enemies.Count > 0)
            {
                Warrior enemy = enemies[random.Next(enemies.Count)];
                double deltaX = Canvas.GetLeft(enemy.warriorEllipse) - Canvas.GetLeft(warriorEllipse);
                double deltaY = Canvas.GetTop(enemy.warriorEllipse) - Canvas.GetTop(warriorEllipse);

                double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                if (distance > 20) // Визначте власний поріг відстані, при якому воїн зупиниться
                {
                    double angle = Math.Atan2(deltaY, deltaX);
                    double speed = 5;

                    double newLeft = Canvas.GetLeft(warriorEllipse) + speed * Math.Cos(angle);
                    double newTop = Canvas.GetTop(warriorEllipse) + speed * Math.Sin(angle);

                    Canvas.SetLeft(warriorEllipse, newLeft);
                    Canvas.SetTop(warriorEllipse, newTop);
                }
            }
        }

        private void CheckCollisions()
        {
            // Створіть копію списку ворогів
            List<Warrior> enemiesCopy = new List<Warrior>(enemies);

            foreach (var enemy in enemiesCopy)
            {
                if (enemy != this)
                {
                    double deltaX = Canvas.GetLeft(enemy.warriorEllipse) - Canvas.GetLeft(warriorEllipse);
                    double deltaY = Canvas.GetTop(enemy.warriorEllipse) - Canvas.GetTop(warriorEllipse);

                    double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                    if (distance < 30) // Визначте власний поріг відстані для колізії
                    {
                        // Зменште здоров'я при колізії
                        health -= 10;

                        // Якщо здоров'я воїна вичерпано, видаліть його з Canvas і списку
                        if (health <= 0)
                        {
                            canvas.Children.Remove(warriorEllipse);
                            enemies.Remove(this);
                        }
                    }
                }
            }
        }

        public bool Collision(IEntity entity)
        {
            // Перевірка на перетин прямокутників
            bool collisionX = (X < entity.X + entity.Width) && (X + Width > entity.X);
            bool collisionY = (Y < entity.Y + entity.Height) && (Y + Height > entity.Y);


            //bool tempColl = (X + Width < entity.X) || (X > entity.X + entity.Width);
            // Повертаємо результат колізії
            return collisionX && collisionY;
        }
    }
}