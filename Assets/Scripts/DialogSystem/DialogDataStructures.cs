using System.Collections.Generic;

[System.Serializable]
public class DialogData
{
    public string character;
    public List<DialogOption> topics;
    public List<DialogOption> greetings;
    public List<DialogOption> goodbyes;
}

[System.Serializable]
public class DialogOption
{
    public string text;
    public string response;
    public string condition;
    public int priority;
    public string action;
    public DialogOption newOption;
}



