//The quest scripts were inspired by the Brackeys tutorial, but were changed to suit this project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string descrip;
    public int reward;
    public int clicks;
    public bool isActive;
    public bool isComplete;
}
