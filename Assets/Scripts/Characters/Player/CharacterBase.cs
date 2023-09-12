using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Technoire
{
    public abstract class CharacterBase : MonoBehaviour
{
    public CharacterData characterData;

    public string charName;

    public int health;
    public int vril;// MP

    public int strength;//attack
    public int endurace;//defense
    public int intelligence;//magic strength, exp, environmental interactions
    public int wisdom;//magic defense
    public int agility;//speed
    public int luck;//critical hit

    private void Awake()
    {
        SetCharacter(characterData);
    }

    public abstract void SetCharacter(CharacterData characterData);
   

}


}
