using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Model
{
    internal class LearningState : IStudentState
    {
        public void DoProsess(IStudent student)
        {
            student.Study();
        }

        public void Handle(IStudent student)
        {
            student.State = new LearningState();
        }
    }
    internal class WorkingState : IStudentState
    {
        public void DoProsess(IStudent student)
        {
            student.Work();
        }

        public void Handle(IStudent student)
        {
            student.State = new WorkingState();
        }
    }
    internal class RelaxingState : IStudentState
    {
        public void DoProsess(IStudent student)
        {
            student.Relax();
        }

        public void Handle(IStudent student)
        {
            student.State = new RelaxingState();
        }
    }
}
