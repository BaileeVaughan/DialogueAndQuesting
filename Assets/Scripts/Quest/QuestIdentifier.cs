using System.Collections;
using UnityEngine;

namespace QuestSystem
{
    public class QuestIdentifier : IQuestIdentifier
    {
        public int questID;
        public int sourceID;

        public int QuestID
        {
            get
            {
                return QuestID;
            }
        }


        public int SourceID
        {
            get
            {
                return sourceID;
            }
        }
    }
}
