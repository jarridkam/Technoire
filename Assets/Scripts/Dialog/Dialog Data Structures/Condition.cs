using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif

[System.Serializable]
public class Condition : ScriptableObject
{
    public enum conditionType
    {
        hasInteractedWith,
    }

    public conditionType condition;

    public bool conditionMet;
    
}

