using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogComponent : ScriptableObject
{
    public string ID;
    public string[] text;
    public int importance;
    public List<bool> conditions = new List<bool>();
}
