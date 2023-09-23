using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Greeting : Root
{
    [TextArea(5, 30)]
    public string[] text;
}
