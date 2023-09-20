using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOption
{
    public string text;
    public string response;
    public string condition;
    public int priority;
    public string action;
    public DialogOption newOption; // This replaces the NewOption reference
}

[System.Serializable]
public class DialogData
{
    public string character;
    public List<DialogOption> topics = new List<DialogOption>();
    public List<DialogOption> greetings = new List<DialogOption>();
    public List<DialogOption> goodbyes = new List<DialogOption>();
}


