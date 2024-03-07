using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempestEngine.Elements;

namespace TempestEngine
{
    internal interface ITempest
    {
    }

    public interface IEntity 
    {
        int Width { get; set; }
        int Height { get; set; }
        int X { get; set; }
        int Y { get; set; }
        bool Collision(IEntity entity);
    }
    public interface IMovable 
    {
        void Move();
    }
    public interface IMovementStrategy
    {
        void Move(AlphaWarrior warrior);
    }
    public interface IKickable { }
    public interface ILevel { }
}
