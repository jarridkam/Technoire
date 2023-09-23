using System;
using Unity;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogInteractable : MonoBehaviour
{
    public Dialog dialog; 

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter called.");

        if (other.CompareTag("Player")) 
        {
            SendDialogToManager();
        }
    }

    private void SendDialogToManager()
    {
        if (dialog != null)
            DialogLogicManager.dialogLogicManager.currentDialog = dialog;
    }
}

