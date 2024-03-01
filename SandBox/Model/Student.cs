using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Model
{
    internal class Student : IStudent
    {
        private IStudentState _state;
        public IStudentState State { get { return _state; } set { _state = value; } }

        private string name;
        private int exp;
        private int energy;
        private float points;

        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }

        public int Energy
        {
            get { return energy; }
            set 
            {
                if (value >= 0 && value <= 100)
                {
                    energy = value;
                }
                else if (value < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = 100;
                }
            }
        }

        public float Points
        {
            get { return points; }
            set { points = value; }
        }
        
        public Student(string name)
        {
            this.name = name;
            exp = 0;
            Energy = 100;
            points = 0;
            _state = new LearningState();
        }

        public void Relax()
        {
            if(Energy < 100)
                Energy++;
        }

        public virtual void Study()
        {
            if(Energy < 20)
            {
                exp++;
            }
            else
            {
                exp += 5;
            }
            Energy--;
        }

        public void Work()
        {
            if (Energy > 20) 
            {
                exp++; 
                points += 2 * exp / 100; 
            }
            else
                points += exp / 100;
            Energy--;
        }

        public override string ToString() 
        {
            return name; 
        }
    }

    internal class Mathematician : Student
    {
        public Mathematician(string name) : base(name)
        {
        }

        public override void Study()
        {
            Exp += 10;
            Energy--;
        }
    }

    internal class Statistician : Student
    {
        public Statistician(string name) : base(name)
        {
        }
    }

    internal class ComputerMechanic : Student
    {
        public ComputerMechanic(string name) : base(name)
        {
        }
    }

    internal class ComputerMathematician : Student
    {
        public ComputerMathematician(string name) : base(name)
        {
        }
    }

    internal class Educator : Student
    {
        public Educator(string name) : base(name)
        {
        }
    }
    
}
