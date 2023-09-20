using UnityEngine;

public class DialogInteractable : MonoBehaviour
{
    public TextAsset jsonFile; // Drag and drop your JSON file here in the inspector
    public GameObject interactionPrompt; // Assign the UI prompt in the inspector
    public KeyCode interactionKey = KeyCode.E; // Key to interact

    public DialogData dialogData; // This will store the dialog data for this NPC

    private DialogLogicManager dialogLogicManager;
    private bool isPlayerInRange = false;

    private void Awake()
    {
        // Parse the JSON once and store it in dialogData
        if (jsonFile != null)
        {
            DialogData dialogData = JsonUtility.FromJson<DialogData>(jsonFile.text);
            Debug.Log("Parsed character name: " + dialogData.character);
            Debug.Log("Parsed topics count: " + (dialogData.topics != null ? dialogData.topics.Count.ToString() : "NULL"));
            if (dialogData.topics != null && dialogData.topics.Count > 0)
            {
                Debug.Log("First topic text: " + dialogData.topics[0].text);
            }

        }
    }

    private void Start()
    {
        dialogLogicManager = FindObjectOfType<DialogLogicManager>();
        if (dialogLogicManager == null)
        {
            Debug.LogError("DialogLogicManager not found in the scene.");
        }

        interactionPrompt.SetActive(false); // Ensure the prompt is hidden at start
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered interaction range."); // Debug
            isPlayerInRange = true;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited interaction range."); // Debug
            isPlayerInRange = false;
            interactionPrompt.SetActive(false);
        }
    }

    public void Interact()
    {
        if (dialogData == null)
        {
            Debug.LogError("Dialog data not loaded.");
            return;
        }

        interactionPrompt.SetActive(false); // Hide the prompt
        Debug.Log("Interacting with NPC. DialogData: " + (dialogData == null ? "NULL" : "Exists"));
        dialogLogicManager.StartDialog(dialogData);
    }
}
