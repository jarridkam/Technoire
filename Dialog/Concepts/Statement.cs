using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using FlowCanvas;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Linq;

namespace Technoire.Dialog
{
    [System.Serializable, HideInInspector]
    public class Statement
    {
        [SerializeField, HideInInspector] 
        public string statementText;

        public Statement() { }

        public Statement(string statementText)
        {
            this.statementText = statementText;
        }
    }

}
