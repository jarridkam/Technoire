using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Sirenix;
using Sirenix.OdinInspector;
using Technoire.BattleSystem.Attacks;

namespace Technoire.BattleSystem
{
    [CustomEditor(typeof(AttackData))]
    public class CustomAttackInspector : Editor
    {
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Add To Database"))
            {
                AttackObject attack = new AttackObject();
                attack.SetData((AttackData)target);
                AttackDatabase.AddAttackToDatabase(attack);
            }

            if(GUILayout.Button("Print Database"))
            {
                foreach(KeyValuePair<string, AttackObject> attack in AttackDatabase.AttackCyclopedia)
                {
                    Debug.Log(attack.Key + " " + attack.Value);
                }
            }
            
        }
    }
}
