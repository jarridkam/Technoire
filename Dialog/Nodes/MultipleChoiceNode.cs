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
#endif

namespace Technoire.Dialog.Nodes
{
    [Name("Multiple Choice v1")]
    [Category("Dialog")]
    [HasRefreshButton]

    public class MultipleChoiceNode : DialogFlowNode
    {
        [HideInInspector]
        public List<Choice> choices = new List<Choice>();

        [HideInInspector]
        public Choice choice = new Choice("New Choice");

        bool testCondition = false;

        
        public int numberOfChoices = 0;


        protected override void RegisterPorts()
        {
            choices.Capacity = 10;
            var outs = new List<FlowOutput>();

           
            for (int i = 0; i < numberOfChoices; i++)
            {
                outs.Add(AddFlowOutput(""));  
            }
         
            AddFlowInput(" ", (f) => { });
            AddChoiceProperly(outs);
           

           
        }

        private string AddPortTextProperly(int index)
        {

            if (choices.Count > 0 && choices[index].statement.statementText != null)
            {
                return choices[index].statement.statementText;
            }
            else
            {
                return " ";
            }
            
        }

        private void AddChoiceProperly(List<FlowOutput> outs)
        {

           while ( choices.Count != outs.Count)
            {
                if(choices.Count < outs.Count)
                {
                    Choice choice = new Choice(true);
                    choices.Add(choice);
                }
                else if(choices.Count > outs.Count)
                {
                    for(int i = choices.Count; choices.Count!=outs.Count; i--)
                    {
                        choices.Remove(choices[i-1]);
                    }
                }
            }
        }
        



#if UNITY_EDITOR

        protected override void OnNodeGUI()
        {
            
            base.OnNodeGUI();
        }

        protected override void OnNodeInspectorGUI()
        {
            base.OnNodeInspectorGUI();

            var areaStyle = new GUIStyle(GUI.skin.GetStyle("TextArea"));
            areaStyle.wordWrap = true;

            
            if (choices.Count != 0)
            {
                foreach(Choice choice in choices)
                {
                    
                    string foldoutContent = choice.showChoice ? "" : choice.statement.statementText;
                    choice.showChoice = EditorGUILayout.Foldout(choice.showChoice, foldoutContent);
                    if (choice.showChoice)
                    {
                        choice.statement.statementText = EditorGUILayout.TextArea(choice.statement.statementText, areaStyle, GUILayout.Height(25));
                        EditorGUILayout.Space();
                    } 
                }   
            }            
        }

#endif
    }
}
