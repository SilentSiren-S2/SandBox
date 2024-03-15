using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBoardSBV.QuestLegacy
{
    internal interface IQuest
    {
    }

    public interface IQuestObserver
    {
        void UpdateQuest(BasicQuest quest);
    }

    public interface IWathcable
    {
        void Attach(IQuestObserver observer); // Метод для підписки на спостереження
        void Detach(IQuestObserver observer); // Метод для відписки від спостереження
        void Notify();
    }
}
