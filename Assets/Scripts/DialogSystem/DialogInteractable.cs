using UnityEngine;

public class DialogInteractable : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject interactionPrompt;
    public KeyCode interactionKey = KeyCode.E;

    private DialogLogicManager dialogLogicManager;

    private void Awake()
    {
        dialogLogicManager = FindObjectOfType<DialogLogicManager>();
        interactionPrompt.SetActive(false);
    }

    private void Update()
    {
        if (interactionPrompt.activeSelf && Input.GetKeyDown(interactionKey))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPrompt.SetActive(false);
        }
    }

    private void Interact()
    {
        DialogData dialogData = JsonUtility.FromJson<DialogData>(jsonFile.text);
        dialogLogicManager.StartDialog(dialogData);
    }
}
