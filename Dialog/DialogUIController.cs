using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlowCanvas;
using FlowCanvas.Nodes;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Technoire.Dialog;
using TMPro;


public class DialogUIController : MonoBehaviour
{

    public GameObject dialogCanvas;

    public GameObject interactText;

    public string greetingText;
    public TMP_Text currentDisplayedText;

    private bool dialogActive;

    private void OnEnable()
    {
        DialogController.DialogAvailable += ShowInteractPrompt;
        DialogController.InitiateDialog += ActivateDialogCanvas; // when initiate dialog is called, it will call this
        DialogController.DialogActivated += DisplayGreeting;
    }

    public void ActivateDialogCanvas()
    {
        dialogCanvas.SetActive(true);
       
    }

    public void ShowInteractPrompt()
    {
        if (!dialogActive)
            interactText.SetActive(true);
        else
            interactText.SetActive(false);
    }

    public void TurnOffDialogUI()
    {
        dialogCanvas.SetActive(false);
    }

   

    public void DisplayGreeting()
    {
        greetingText = DialogController.transferString;

        currentDisplayedText.text = greetingText;
    }
}
