using System.Collections;
using UnityEngine;

namespace QuestSystem
{
    public interface IQuestIdentifier
    {
        int QuestID { get; }
        int SourceID { get; }
    } 
}
