using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class Result
{
    [TextArea(5, 30)]
    public string resultText;

    public enum ResultType
    {
        SimpleResponse,
        MultiChoice,
        EndConversation
    }

    public ResultType responseType;

    [ShowIf("IsMultiChoice")]
    public string[] playerChoices; // Displayed only if responseType is MultiChoice

    [ListDrawerSettings(ShowIndexLabels = true, DraggableItems = true, Expanded = true)]
    public Condition[] conditions;

    [InfoBox("Higher importance values will be chosen over lower ones if multiple conditions are met.")]
    public int importance;

    public bool IsMultiChoice() => responseType == ResultType.MultiChoice;
}
