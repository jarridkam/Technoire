using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialog : ScriptableObject
{
    public Greeting[] greetings;
    public Topic[] topics;
    public Goodbye[] goodbyes;
}
