using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif

public class Root : ScriptableObject
{
    public string greeting;
    [ListDrawerSettings(ShowIndexLabels = true, DraggableItems = true, Expanded = true)]
    public Result[] possibleResponses;

    // In-game, when a root is triggered:
    // 1. Display the greeting
    // 2. Evaluate the conditions of each Result in possibleResponses
    // 3. Choose the Result with the highest importance where all conditions are met
    // 4. Display the Result (if MultiChoice, give the player choices)
}
