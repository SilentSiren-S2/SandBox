using SandBox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    #region Tempest
    internal interface TempestInterface
    {
    }
    #endregion

    #region Factory Pattern
    public interface IFactory
    {
        IProduct CreateProduct();
        IStudent CreateStudent();
    }

    public interface IStuffFactory
    {
        IStuff CreateStuff();
    }

    public interface IStuff
    {

    }

    public interface IProduct
    {
        void Operation();
    }

    public interface IStudent
    {
        IStudentState State { get; set; }
        int Exp { get; set; }
        int Energy { get; set; }
        float Points { get; set; }
        void Study();
        void Work();
        void Relax();
    }
    #endregion

    #region Command Pattern
    public interface ICommand
    {
        void Execute();
    }

    public interface ISaveCommand
    {
        void Save();
    }

    public interface IDeleteCommand
    {
        void Delete();
    }
    #endregion

    #region Observer Pattern
    public interface IObserver
    {
        void Update(string message);
    }
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }
    #endregion

    #region State Pattern
    public class Context
    {
        private IState _state;

        public Context(IState initialState)
        {
            _state = initialState;
        }

        public IState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    public interface IState
    {
        void Handle(Context context);
    }

    public interface IStudentState
    {
        void Handle(IStudent student);
        void DoProsess(IStudent student);
    }
    #endregion


    public interface IStudentCommand
    {
        void Study();
        void Work();
        void Relax();
    }
}
