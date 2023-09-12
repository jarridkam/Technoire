using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using UnityEngine.Events;

public class DialogController : MonoBehaviour
{
    public delegate void DialogEvent();

    public static DialogEvent DialogInteractionAvailable; //makes 'press E' canvas activate in ui script when evoked
    public static DialogEvent NoDialogAvailable; // called when leaving the range of a dialog mostly to ui script
    public static DialogEvent InitiateDialog; // called to movement and ui scripts when evoked

    public static Dialog currentDialog;
    public static Greeting chosenGreeting;

    public bool canTalk;

    private void Update()
    {
        if (canTalk && InputController.Interact())
        {
            chosenGreeting = ChooseGreeting(currentDialog.greetings);
            RaiseDialogEvent(InitiateDialog);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (collision.GetComponent<Dialog>())
        {
            currentDialog = collision.GetComponent<Dialog>();

            if(currentDialog.greetings.Length > 0 && HasPossibleGreetings())
            {
                canTalk = true;
                Debug.Log("invoked");
                RaiseDialogEvent(DialogInteractionAvailable);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
        RaiseDialogEvent(NoDialogAvailable);
    }

    public void RaiseDialogEvent(DialogEvent e)
    {
        e?.Invoke();
    }

    public static Greeting ChooseGreeting(Greeting[] dialogComponents)
    {
        Greeting chosenGreeting = null;
        List<Greeting> possibleGreetings = new List<Greeting>();

        if (currentDialog.greetings.Length > 1)
        {
            foreach (Greeting g in currentDialog.greetings)
            {
                if (AllConditionsMet(g))
                {
                    possibleGreetings.Add(g);
                }
            }

            // Sort greetings by importance in descending order and select the first
            if (possibleGreetings.Count > 0)
            {
                chosenGreeting = possibleGreetings.OrderByDescending(g => g.importance).First();
            }
        }
        else if (currentDialog.greetings.Length == 1)
        {
            chosenGreeting = currentDialog.greetings[0];
        }
        return chosenGreeting;
    }

    private static bool AllConditionsMet(DialogComponent dialogComponent)
    {
        return !dialogComponent.conditions.Contains(false);
    }

    private bool HasPossibleGreetings()
    {
        List<Greeting> possibleGreetings = new List<Greeting>();
        if (currentDialog.greetings.Length > 0)
        {
            foreach (Greeting g in currentDialog.greetings)
            {
                if (AllConditionsMet(g)) { possibleGreetings.Add(g); }
            }                       
        }
        return possibleGreetings.Count > 0 ? true : false;
    }
}
