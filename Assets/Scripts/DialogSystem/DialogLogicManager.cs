using System.Collections.Generic;
using UnityEngine;

public class DialogLogicManager : MonoBehaviour
{
    private DialogData currentDialog;
    private int currentResponseIndex = 0;
    private List<string> splitResponses;

    private void OnEnable()
    {
        DialogEvents.OnOptionChosen += OnOptionSelected;
    }

    private void OnDisable()
    {
        DialogEvents.OnOptionChosen -= OnOptionSelected;
    }

    public void StartDialog(DialogData dialogData)
    {
        currentDialog = dialogData;
        ShowGreeting();
    }

    private void ShowGreeting()
    {
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
            DisplayResponse(highestPriorityGreeting.response);
        }
        else
        {
            ShowOptions();
        }
    }

    public void ShowOptions()
    {
        if (currentDialog.topics != null && currentDialog.topics.Count > 0)
        {
            DialogEvents.UpdateOptions(currentDialog.topics);
        }
        else
        {
            Debug.LogError("No topics to show!");
        }
    }

    private void OnOptionSelected(int index)
    {
        if (index < 0 || index >= currentDialog.topics.Count)
            return;

        DialogOption selectedOption = currentDialog.topics[index];
        DisplayResponse(selectedOption.response);

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

    private void DisplayResponse(string response)
    {
        splitResponses = new List<string>(response.Split(new string[] { "::" }, System.StringSplitOptions.None));
        currentResponseIndex = 0;
        UpdateResponseText();
    }

    private void UpdateResponseText()
    {
        if (currentResponseIndex < splitResponses.Count)
        {
            DialogEvents.UpdateResponse(splitResponses[currentResponseIndex]);
            currentResponseIndex++;
        }
        else
        {
            ShowOptions();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateResponseText();
        }
    }
}
