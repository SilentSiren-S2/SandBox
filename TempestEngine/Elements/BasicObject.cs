using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempestEngine.Elements
{
    public abstract class BasicObject : IEntity
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public BasicObject() 
        {
            Width = 5;
            Height = 10;
            X = 2;
            Y = 2;
        }

        public BasicObject(int width, int height, int x, int y)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
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
