using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using NodeCanvas;
using FlowCanvas;
using FlowCanvas.Nodes;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Linq;
using Technoire.Dialog.Nodes;

namespace Technoire.Dialog
{
    public class Dialog
    {
        public GreetingNode currentGreeting;
        public List<GreetingNode> greetings = new List<GreetingNode>();

        public Dialog() { }

        public Dialog(FlowGraph graph)
        {
            
            foreach(GreetingNode greeting in graph.GetAllNodesOfType<GreetingNode>())
            {
                greetings.Add(greeting);
            }
        }

    }
}

