using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public string charName;
    public int level;

    public enum playerClass
    {
        AstralKnight,
        LunarMage,
        CelestialPaladin,
        AetherialCleric
    }

    public enum starsign
    {
        WaterBearer,
        FireBreather,
        SnakeCharmer,
        CloudEater
    }

    public int strenth;
    public int defense;
    public int wisdom;
    public int faith;
    public int speed;

}
