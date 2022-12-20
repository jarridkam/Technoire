using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Technoire.BattleSystem;
#if UNITY_EDITOR
using Sirenix;
#endif

namespace Technoire.BattleSystem.Attacks
{
    [CreateAssetMenu(fileName = "NewAttack", menuName = "Technoire/BattleSystem/NewAttack")]
    public class AttackData : ScriptableObject
    {
       

        [HideInInspector]
        public static int IDint;
        public int attackDistance;

        public string attackName;

        public bool isRanged;

        public float baseDamage;
        public float baseSecondaryDamage;

        public enum DamageCategory { Sharp, Blunt, Pierce }
        public enum DamageEffect { Burning, Freezing, Electric, Bleeding }
        public DamageCategory damageCategory;
        public DamageEffect damageEffect;

        

 
    }
}

