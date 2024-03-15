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

        public BasicQuest()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
