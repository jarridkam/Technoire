using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUIManager : MonoBehaviour
{
    public GameObject dialogPanel; // The main dialog UI panel
    public TextMeshProUGUI npcText; // The UI element for the NPC's text
    public Transform responseContainer; // The container for the response buttons
    public Button optionButtonPrefab; // The button prefab for response options
    public DialogLogicManager dialogLogicManager;

    private string[] splitText; // Split NPC text
    private int currentTextIndex = 0;

    private void Awake()
    {
        dialogPanel.SetActive(false); // Ensure the dialog panel is off at the start
    }

    private void OnEnable()
    {
        DialogEvents.OnUpdateResponse += UpdateNpcText;
        DialogEvents.OnUpdateOptions += UpdateOptionButtons;
    }

    private void OnDisable()
    {
        DialogEvents.OnUpdateResponse -= UpdateNpcText;
        DialogEvents.OnUpdateOptions -= UpdateOptionButtons;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogPanel.activeSelf)
        {
            ContinueDialog();
        }
    }

    public void UpdateNpcText(string response)
    {
        dialogPanel.SetActive(true);
        splitText = response.Split(new[] { "::" }, System.StringSplitOptions.None);
        currentTextIndex = 0;
        npcText.text = splitText[currentTextIndex];
    }

    public void ContinueDialog()
    {
        currentTextIndex++;
        if (currentTextIndex < splitText.Length)
        {
            npcText.text = splitText[currentTextIndex];
        }
        else
        {
            // Display response options
            npcText.text = ""; // Clear NPC text
            dialogLogicManager.ShowOptions(); // Assuming you'll fetch the options from the DialogLogicManager
        }
    }

    public void UpdateOptionButtons(List<DialogOption> options)
    {
        if (options == null)
        {
            Debug.LogError("Options list is null!");
            return;
        }
        // Clear existing buttons
        foreach (Transform child in responseContainer)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new buttons
        foreach (DialogOption option in options)
        {
            Button btn = Instantiate(optionButtonPrefab, responseContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = option.text;
            btn.onClick.AddListener(() => DialogEvents.OptionChosen(options.IndexOf(option)));
        }
    }
}
