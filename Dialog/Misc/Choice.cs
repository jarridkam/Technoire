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
#endif

namespace Technoire.Dialog
{
    [System.Serializable]
    public class Choice 
    {
        public bool showChoice;

        [HideInInspector]
        public bool conditionsMet;
        
        public Statement statement = new Statement();

        public Choice(bool showChoice) {

            this.showChoice = showChoice;
        }

        public Choice(string choiceText) 
        {
            this.statement.statementText = choiceText;
        }
    }
}

