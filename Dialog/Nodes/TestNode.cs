using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlowCanvas;
using FlowCanvas.Nodes;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
#if UNITY_EDITOR
using UnityEditor;
using NodeCanvas.Editor;
#endif

namespace Technoire.Dialog.Nodes
{
    [Name("Test Node")]
    [Category("Dialog")]
    [Color("18fff9")]
  
    public class TestNode : BaseDialogNode
    {
        [SerializeField]
        private Statement statement = new Statement("New Text");

        protected override void RegisterPorts()
        {
            var fOut = AddFlowOutput(" ", "Out");
            //AddFlowInput(" ", "In", (f) => { fOut.Call(f); });
        }



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

            EditorGUI.BeginChangeCheck();
            GUILayout.TextField("");
            EditorGUILayout.LabelField("Test Label");
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Second Label");

            var areaStyle = new GUIStyle(GUI.skin.GetStyle("TextArea"));
            areaStyle.wordWrap = true;

            statement.statementText = EditorGUILayout.TextArea(statement.statementText, areaStyle, GUILayout.Height(100));        }
    }
#endif
}


