using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Technoire
{
    public class Player : CharacterBase
    {
        public int charismaInit;

        protected int charisma;

        public override void SetCharacter(CharacterData characterData)
        {
            this.charName = characterData.charName;

            this.health = characterData.health;
            this.vril = characterData.vril;

            this.strength = characterData.strength;
            this.endurace = characterData.endurace;
            this.intelligence = characterData.intelligence;
            this.wisdom = characterData.wisdom;
            this.agility = characterData.agility;
            this.luck = characterData.luck;
            this.charisma = this.charismaInit;
        }
    }
}

