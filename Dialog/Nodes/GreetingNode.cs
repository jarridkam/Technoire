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
    [Name("Greeting")]
    [Category("Dialog")]
    [Color("fff000")]

    public class GreetingNode : BaseDialogNode
    {
        private FlowOutput start;
        private ValueInput<bool> condition;

        [SerializeField]
        public Statement statement = new Statement("New Text");
        public int importance;

        protected override void RegisterPorts()
        {
            start = AddFlowOutput(" ", "Out");
            condition = AddValueInput<bool>("Condition");

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

            var areaStyle = new GUIStyle(GUI.skin.GetStyle("TextArea"));
            areaStyle.wordWrap = true;
            
            statement.statementText = UnityEditor.EditorGUILayout.TextArea(statement.statementText, areaStyle, GUILayout.Height(100));
        }
    }
#endif
}
