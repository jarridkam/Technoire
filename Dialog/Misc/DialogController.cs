using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlowCanvas;
using FlowCanvas.Nodes;
using ParadoxNotion.Design;
using NodeCanvas.Framework;

//Logically starts, ends and controls dialog

namespace Technoire.Dialog
{
    public class DialogController : MonoBehaviour
    {
        public Dialog currentDialog;
        public DialogInteractable currentInteraction;
        public Collider2D dialogTrigger;

        public static string transferString;
        public bool dialogAvailable;
        public bool pressingE;
        public bool dialogActivated;

        public static Action DialogAvailable;
        public static Action InitiateDialog;
        public static Action DialogActivated;

        //private FlowGraph graph;


        private void Update()
        {

            if (dialogAvailable)
            {
                DialogAvailable?.Invoke();
                DialogActivated?.Invoke();
            }

            if(dialogAvailable && IsPressingE() && !dialogActivated)
            {
                InitiateDialog?.Invoke();
                dialogActivated = true;
                GetDialog();
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (dialogTrigger)
            {
                if (collider.gameObject.GetComponent<DialogInteractable>())
                {
                    DialogInteractable currentInteraction = collider.gameObject.GetComponent<DialogInteractable>();
                    this.currentInteraction = currentInteraction;
                    if (currentInteraction.graph != null)
                        dialogAvailable = true;
                };
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            dialogAvailable = false;
            
        }

        private bool IsPressingE()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed");
                return true;
               
            }
            return false;
        }

        private void GetDialog()
        {
            currentDialog = new Dialog(currentInteraction.graph);
            transferString = currentDialog.greetings[0].statement.statementText.ToString();
                
        }

       

    }

}
