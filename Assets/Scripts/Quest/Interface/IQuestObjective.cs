using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestObjective
{
    string Title { get; }
    string Description { get; }
    bool IsComplete { get; }
    void UpdateProgress();
    void CheckProgress();

}
