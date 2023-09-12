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
    [CreateAssetMenu(fileName = "NewAttack", menuName = "Technoire/BattleSystem/New Attack")]
    public class AttackData : ScriptableObject
    {
        [HideInInspector]
        public string attackName;
        public int attackDistance;

        public float baseDamage;
        public float baseSecondaryDamage;
        public float attackSpeed;

        public bool isRanged;

        public enum DamageCategory { Sharp, Blunt, Pierce }
        public enum DamageEffect { Burning, Freezing, Electric, Bleeding }
        public DamageCategory damageCategory;
        public DamageEffect damageEffect;
    }
}

