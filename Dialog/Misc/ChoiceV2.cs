using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlowCanvas;
using FlowCanvas.Nodes;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using Unity.VisualScripting;
using Technoire.Dialog.Nodes;
#if UNITY_EDITOR
using UnityEditor;
using NodeCanvas.Editor;
using Sirenix;
using Sirenix.OdinInspector;
#endif

namespace Technoire.Dialog
{
    [System.Serializable]
    public class ChoiceV2 
    {
        public Statement statement = new Statement();

        public bool conditionsMet;

        public ChoiceV2() {this.statement.statementText = "New Text";}}

}

