using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    // UI references
    public static DialogManager dialogManager;

    public GameObject dialogCanvas;
    public TMP_Text npcResponseText;
    public Transform topicsPanelTransform;
    public Button dialogOptionButtonPrefab;

    private DialogData currentDialogData;

    private void Start()
    {
        
    }

    public void StartDialog(DialogData dialogData)
    {
        currentDialogData = dialogData;
        DisplayGreeting();
        DisplayDialogOptions();
    }

    private void DisplayGreeting()
    {
        if (currentDialogData.greetings != null && currentDialogData.greetings.Length > 0)
        {
            // For simplicity, we'll just display the first greeting.
            // Later, you can add logic to select a greeting based on conditions.
            npcResponseText.text = currentDialogData.greetings[0].text;
            dialogCanvas.SetActive(true);
        }
    }

    // ... (other parts of the DialogManager script)

    private void DisplayDialogOptions()
    {
        // Ensure references are set
        if (dialogOptionButtonPrefab == null)
        {
            Debug.LogError("Dialog Option Button Prefab is not set in the DialogManager!");
            return;
        }

        if (topicsPanelTransform == null)
        {
            Debug.LogError("Topics Panel Transform is not set in the DialogManager!");
            return;
        }

        // Clear any existing buttons
        foreach (Transform child in topicsPanelTransform)
        {
            Destroy(child.gameObject);
        }

        if (currentDialogData == null)
        {
            Debug.LogError("Current Dialog Data is null!");
            return;
        }

        if (currentDialogData.topics == null || currentDialogData.topics.Length == 0)
        {
            Debug.LogError("No topics available in the current dialog data!");
            return;
        }

        // Sort topics based on priority
        List<Topic> sortedTopics = new List<Topic>(currentDialogData.topics);
        sortedTopics.Sort((a, b) => b.priority.CompareTo(a.priority)); // Sort in descending order of priority

        // Create a button for each dialog topic
        foreach (var topic in sortedTopics)
        {
            Debug.Log("Processing topic: " + topic.text);

            // For testing, let's skip the condition check. Uncomment this later.
            // if (string.IsNullOrEmpty(topic.condition) || EvaluateCondition(topic.condition))
            // {
            Button optionButton = Instantiate(dialogOptionButtonPrefab, topicsPanelTransform);
            TMP_Text buttonText = optionButton.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = topic.text;
            }
            else
            {
                Debug.LogError("No TMP_Text component found in the button prefab!");
            }

            // Add a listener to handle the button click
            optionButton.onClick.AddListener(() => OnDialogOptionSelected(topic));
            // }
        }
    }


    // ... (rest of the DialogManager script)



    private void OnDialogOptionSelected(Topic topic)
    {
        npcResponseText.text = topic.response;

        if (topic.newOptions != null && topic.newOptions.Length > 0)
        {
            currentDialogData.topics = topic.newOptions;
            DisplayDialogOptions();
            return;
        }

        if (topic.singleUse)
        {
            // Remove the topic from the list
            List<Topic> topicsList = new List<Topic>(currentDialogData.topics);
            topicsList.Remove(topic);
            currentDialogData.topics = topicsList.ToArray();

            // Refresh the displayed dialog options
            DisplayDialogOptions();
        }
    }

    private bool EvaluateCondition(string condition)
    {
        // Here, you can evaluate the condition based on the player's stats.
        // For example, if condition is "stats.health > 50", you can check the player's health.
        // This is a simplified approach; you might need a more complex parser for intricate conditions.
        // Return true if the condition is met, false otherwise.

        // For now, just returning true as a placeholder.
        return true;
    }
}
