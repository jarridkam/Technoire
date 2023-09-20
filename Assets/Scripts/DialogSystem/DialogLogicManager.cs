using System.Collections.Generic;
using UnityEngine;

public class DialogLogicManager : MonoBehaviour
{
    public DialogData currentDialog;
    private List<DialogOption> currentOptions;

    private void OnEnable()
    {
        DialogEvents.OnOptionChosen += OnOptionSelected;
    }

    private void OnDisable()
    {
        DialogEvents.OnOptionChosen -= OnOptionSelected;
    }


    private void Start()
    {
        // Assuming you start the dialog when the game starts
        //StartDialog(currentDialog);
    }

    public void StartDialog(DialogData dialogData)
    {
        Debug.Log("Starting dialog. DialogData: " + (dialogData == null ? "NULL" : "Exists"));

        currentDialog = dialogData;

        // Display the greeting with the highest priority
        if (currentDialog.greetings != null && currentDialog.greetings.Count > 0)
        {
            DialogOption highestPriorityGreeting = currentDialog.greetings[0];
            foreach (var greeting in currentDialog.greetings)
            {
                if (greeting.priority > highestPriorityGreeting.priority)
                {
                    highestPriorityGreeting = greeting;
                }
            }
            DialogEvents.UpdateResponse(highestPriorityGreeting.text);
        }
        else
        {
            // If no greetings, display options directly
            ShowOptions();
        }

        Debug.Log("Received topics count in DialogLogicManager: " + (currentDialog.topics != null ? currentDialog.topics.Count.ToString() : "NULL"));

    }


    public List<DialogOption> GetCurrentOptions()
    {
        // Assuming currentDialog is the active dialog data
        return currentDialog.topics;
    }


    public void ShowOptions()
    {
        Debug.Log("Showing options. Topics count: " + (currentDialog.topics != null ? currentDialog.topics.Count.ToString() : "NULL"));

        if (currentDialog == null || currentDialog.topics == null || currentDialog.topics.Count == 0)
        {
            Debug.LogError("No dialog or topics to show!");
            return;
        }

        DialogEvents.UpdateOptions(currentDialog.topics);
    }



    public void OnOptionSelected(int index)
    {
        if (index < 0 || index >= currentOptions.Count)
            return;

        DialogOption selectedOption = currentOptions[index];
        DialogEvents.UpdateResponse(selectedOption.response);

        // Handle action
        switch (selectedOption.action)
        {
            case "set new options":
                if (selectedOption.newOption != null)
                {
                    currentDialog.topics.Add(selectedOption.newOption);
                }
                ShowOptions();
                break;
            case "remove option":
                currentDialog.topics.RemoveAt(index);
                ShowOptions();
                break;
            case "replace option":
                if (selectedOption.newOption != null)
                {
                    currentDialog.topics[index] = selectedOption.newOption;
                }
                ShowOptions();
                break;
            case "goodbye":
                // Handle ending the conversation, e.g., hide the dialog UI
                break;
                // ... Handle other actions as needed
        }
    }

    private List<DialogOption> FilterOptionsBasedOnConditions(List<DialogOption> options)
    {
        // Here, you'd check conditions like "stats.intelligence >= 5" and filter the options accordingly.
        // For now, we'll return all options, but you should implement the condition checks based on your game's logic.
        return options;
    }
}
