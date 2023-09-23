using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class Topic : Root
{
    [TextArea(2, 5)] 
    public string text;

    [ListDrawerSettings(ShowIndexLabels = true, DraggableItems = true, Expanded = true)]
    public Result[] possibleResponses;
}
