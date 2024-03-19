using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBoardSBV.QuestLegacy
{
    public class BasicQuest
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public QuestType QType { get; set; }
        
        public BasicQuest()
        {
            QType = QuestType.NoType;
            IsDone = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    #region хто я?
    public class Quest2 : BasicQuest 
    {

    }
    #endregion

    public enum QuestType
    {
        NoType,
        ToDev,
        Ideas,
        Daily,
        Tracks,
        Epic
    }
}
