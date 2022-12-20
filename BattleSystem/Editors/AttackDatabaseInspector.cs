using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using Technoire.BattleSystem.Attacks;
using Sirenix.OdinInspector.Editor;

#if UNITY_EDITOR
using Sirenix;
using Sirenix.OdinInspector;
#endif

namespace Technoire.Battlesystem
{
    [CustomEditor(typeof(AttackDatabase))]
    [CanEditMultipleObjects]
    public class AttackDatabaseInspector :OdinEditor
    {
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

    }
}
