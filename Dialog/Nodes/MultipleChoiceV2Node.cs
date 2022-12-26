using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlowCanvas;
using FlowCanvas.Nodes;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
using NodeCanvas.Editor;
using Sirenix;
using Sirenix.OdinInspector;
#endif

namespace Technoire.Dialog.Nodes
{
    [Name("Multiple Choice v2")]
    [Category("Dialog")]

    //[HasRefreshButton]

    public class MultipleChoiceNodeV2 : DialogFlowNode
    {
        FlowInput Start;
        ValueInput<bool> condition;
        FlowOutput choice;

        [HideInInspector]
        public List<ChoiceV2> choices = new List<ChoiceV2>();
        List<FlowOutput> outs = new List<FlowOutput>();
        List<ValueInput<bool>> conditions = new List<ValueInput<bool>>();

        //public string displayText;

        protected override void RegisterPorts()
        {
            Start = AddFlowInput("", (f) => { });

            for(int i = 0; i <= outs.Count; i++)
            {
                outs.Add(AddFlowOutput(""));
            }
         
        
        }

        void AddChoice()
        {
            ChoiceV2 choice = new ChoiceV2();
            choices.Add(choice);
        }

        void RemoveChoice()
        {

        }



#if UNITY_EDITOR
            protected override void OnNodeGUI()
        {

            base.OnNodeGUI();

            foreach (ChoiceV2 choice in choices)
            {
                string labelText = choice.statement.statementText;
                GUILayout.Label(labelText);
            }
        }

        protected override void OnNodeInspectorGUI()
        {
            if (GUILayout.Button("Add Choice"))
            {
                AddChoice();
            }


            var areaStyle = new GUIStyle(GUI.skin.GetStyle("TextArea"));
            areaStyle.alignment = TextAnchor.MiddleLeft;
            areaStyle.wordWrap = true;

            foreach (ChoiceV2 choice in choices)
            {

                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();

                choice.statement.statementText = EditorGUILayout.TextArea(choice.statement.statementText, areaStyle, GUILayout.Height(20));

                if (GUILayout.Button("X", GUILayout.Width(25)))
                {
                    choices.Remove(choice);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
            }

            base.OnNodeInspectorGUI();

        }

    }
#endif
 }

        





