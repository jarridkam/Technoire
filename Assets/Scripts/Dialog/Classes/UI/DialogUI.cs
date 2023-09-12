using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : MonoBehaviour
{
    public GameObject dialogCanvas;             
    public GameObject actionCanvas;

    public TextMeshProUGUI uiText;

    private void OnEnable()
    {
        DialogController.DialogInteractionAvailable += ActivateActionCanvas;
        DialogController.NoDialogAvailable += DeactivateActionCanvas;

        DialogController.InitiateDialog += ActivateDialogCanvas;
    }

    private void OnDisable()
    {
        DialogController.DialogInteractionAvailable -= ActivateActionCanvas;
        DialogController.NoDialogAvailable -= DeactivateActionCanvas;

        DialogController.InitiateDialog -= ActivateDialogCanvas;
    }

    private void Update()
    {
        PrintToUI(DialogController.chosenGreeting.text[0]);
        
    }

    private void PrintToUI(string print)
    {
        //Debug.Log(print);
        if (uiText != null)
            uiText.text = print;
    }

    private void ActivateDialogCanvas()
    {
        actionCanvas.SetActive(false);
        dialogCanvas.SetActive(true);
    }
    private void DeactivateDialogCanvas()
    {
        dialogCanvas.SetActive(false);
    }

    private void ActivateActionCanvas()
    {
        actionCanvas.SetActive(true);
    }
    private void DeactivateActionCanvas()
    {
        if (actionCanvas != null && actionCanvas.activeSelf)
            actionCanvas.SetActive(false);
    }
}
