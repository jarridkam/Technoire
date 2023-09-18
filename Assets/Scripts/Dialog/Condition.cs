using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif

[System.Serializable]
public class Condition
{
    public string conditionName; // For example: "HasQuestItem"
    public bool conditionMet;
    // ... Any other variables or methods you need to evaluate the condition
}

