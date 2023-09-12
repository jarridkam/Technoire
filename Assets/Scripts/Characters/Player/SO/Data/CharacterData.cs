using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterData : ScriptableObject
{
    public string charName;

    public int health;
    public int vril;// MP

    public int strength;//attack
    public int endurace;//defense
    public int intelligence;//magic strength, exp, environmental interactions
    public int wisdom;//magic defense
    public int agility;//speed
    public int luck;//critical hit

}
