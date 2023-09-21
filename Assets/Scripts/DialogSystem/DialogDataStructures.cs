using System.Collections.Generic;

[System.Serializable]
public class DialogData
{
    public Character character;
    public Greeting[] greetings;
    public Goodbye[] goodbyes;
    public Topic[] topics;
}

[System.Serializable]
public class Character
{
    public string name;
    public string image;
}

[System.Serializable]
public class Greeting
{
    public string text;
    public string condition;
    public int priority;
    public bool singleUse;
}

public class Topic
{
    public string text;
    public string response;
    public string condition;
    public string action;
    public int priority;
    public bool singleUse; //optional, will option will disappear after clicked if true
    public Topic[] newOptions; //optional to display new options when clicked
}

public class Goodbye
{
    public string text;
    public string condition;
    public int priority;
    public bool singleUse;
}






