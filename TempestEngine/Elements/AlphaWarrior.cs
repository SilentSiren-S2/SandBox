using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempestEngine.Elements
{
    public abstract class AlphaWarrior : BasicObject, IMovable
    {
        protected AlphaWarrior(int width, int height, int x, int y) : base(width, height, x, y)
        {
        }

        public void Move()
        {
        }
    }
}
