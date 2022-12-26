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
#endif


namespace Technoire.Dialog.Nodes
{
    [Name("Response")]
    [Category("Dialog")]
    [Color("fff000")]
    public class ResponseNode : DialogFlowNode
    {
        private FlowOutput outFlow;
        private FlowInput inFlow;

        [SerializeField]
        private Statement statement = new Statement("New Text");


#if UNITY_EDITOR
        protected override void OnNodeGUI()
        {
            var content = statement.statementText;
            string displayContent = content.Length > 30 ? content.Substring(0, 30) + "..." : content;

            GUILayout.FlexibleSpace();
            GUILayout.Label("<i>\"" + displayContent + "\"</i>");
            
            base.OnNodeGUI();
        }

        protected override void OnNodeInspectorGUI()
        {
            base.OnNodeInspectorGUI();

            var areaStyle = new GUIStyle(GUI.skin.GetStyle("TextArea"));
            areaStyle.wordWrap = true;

            statement.statementText = EditorGUILayout.TextArea(statement.statementText, areaStyle, GUILayout.Height(100));
        }
#endif
    }

}


