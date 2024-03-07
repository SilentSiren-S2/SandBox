using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempestEngine.Elements
{
    public class AlphaWarrior : BasicObject, IMovable
    {
        IMovementStrategy movementStrategy;
        public AlphaWarrior(IMovementStrategy movementStrategy) : base()
        {
            this.movementStrategy = movementStrategy;
        }

        protected AlphaWarrior(int width, int height, int x, int y) : base(width, height, x, y)
        {
        }

        public void Move()
        {
            movementStrategy.Move(this);
        }
    }
}
