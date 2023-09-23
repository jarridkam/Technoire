using UnityEngine;

public class DialogLogicManager : MonoBehaviour
{
    [HideInInspector]
    public static DialogLogicManager dialogLogicManager;

    private Topic currentTopic;
    private Greeting currentGreeting;
    private Goodbye currentGoodbye;

    [HideInInspector]
    public Dialog currentDialog;

    private void Awake()
    {
        if (dialogLogicManager == null)
        {
            dialogLogicManager = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (dialogLogicManager != this)
        {
            Destroy(gameObject); 
        }
    }

    private void Update()
    {
        
    }
}


