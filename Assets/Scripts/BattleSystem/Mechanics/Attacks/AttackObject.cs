using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Technoire.BattleSystem;

namespace Technoire.BattleSystem.Attacks
{
    [System.Serializable]
    public class AttackObject 
    {
        public AttackData data;

        public string attackName;

        public int attackDistance;

        public bool isRanged;

        public enum DamageCategory { Sharp, Blunt, Pierce}
        public enum DamageEffect { Burning, Freezing, Electric, Bleeding }
        public DamageCategory damageCategory;
        public DamageEffect damageEffect;

        public void SetData(AttackData fData)
        { 
            this.attackName = fData.attackName;
            this.isRanged = fData.isRanged;
            this.attackDistance = fData.attackDistance;

            damageCategory = (DamageCategory)fData.damageCategory;
        }
    }
}




