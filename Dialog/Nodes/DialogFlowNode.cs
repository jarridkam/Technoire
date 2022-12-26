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
    public class DialogFlowNode : BaseDialogNode
    {


        [SerializeField]
        private Statement statement = new Statement("New Text");

        public static string statementContents;


        public struct PortRow
        {
            public System.Action content;
            public Port input;
            public Port output;

            public PortRow(Port input, Port output)
            {
                this.input = input;
                this.output = output;

                content = null;
            }

            public PortRow(Port input, System.Action content, Port output)
            {
                this.input = input;
                this.output = output;
                this.content = content;

            }   
        }


#if UNITY_EDITOR
        protected override void OnNodeGUI()
        {
            var content = statement.statementText;
      

            base.OnNodeGUI();
        }

        protected override void OnNodeInspectorGUI()
        {

           
            base.OnNodeInspectorGUI();

        }
#endif
    }

}
