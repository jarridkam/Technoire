using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using Sirenix;
using Sirenix.OdinInspector;
#endif
namespace Technoire.BattleSystem.Attacks
{
    public class AttackDatabase : SerializedMonoBehaviour
    {
        
        public static Dictionary<string, AttackObject> AttackCyclopedia = new  Dictionary<string, AttackObject>();

        [DictionaryDrawerSettings(KeyLabel = "Custom Key Name", ValueLabel = "Custom Value Label")]
        public Dictionary<string, AttackObject> dispalyCyclopedia = new Dictionary<string, AttackObject>();

        private void Update()
        {
            foreach(KeyValuePair<string, AttackObject> kvp in AttackCyclopedia)
            {
                dispalyCyclopedia.Add(kvp.Key, kvp.Value);
            }

        }

        public static void AddAttackToDatabase(AttackObject attack)
        {
            AttackCyclopedia.Add(attack.attackName, attack);
        }
    }
}
