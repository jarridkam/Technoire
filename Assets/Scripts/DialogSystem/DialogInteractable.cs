using UnityEngine;
using System.Linq;
using SimpleJSON;

public class DialogInteractable : MonoBehaviour
{
    public TextAsset dialogJson; // The JSON file assigned in the Unity Editor
    private DialogData dialogData;

    public DialogManager dialogManager; // Reference to the DialogManager

    private void Start()
    {
        if (dialogJson != null)
        {
            var jsonNode = JSON.Parse(dialogJson.text);
            dialogData = new DialogData
            {
                character = new Character
                {
                    name = jsonNode["char"]["name"],
                    image = jsonNode["char"]["image"]
                },
                greetings = jsonNode["greetings"].Children.Select(g => new Greeting
                {
                    text = g["text"],
                    condition = g["condition"],
                    priority = g["priority"].AsInt,
                    singleUse = g["singleUse"].AsBool
                }).ToArray(),
                goodbyes = jsonNode["goodbyes"].Children.Select(g => new Goodbye
                {
                    text = g["text"],
                    condition = g["condition"],
                    priority = g["priority"].AsInt,
                    singleUse = g["singleUse"].AsBool
                }).ToArray(),
                topics = jsonNode["topics"].Children.Select(t => new Topic
                {
                    text = t["text"],
                    condition = t["condition"],
                    action = t["action"],
                    priority = t["priority"].AsInt,
                    singleUse = t["singleUse"].AsBool,
                    newOptions = t["newOptions"].Children.Select(no => new Topic
                    {
                        text = no["text"],
                        response = no["response"],
                        action = no["action"],
                        priority = no["priority"].AsInt,
                        singleUse = no["singleUse"].AsBool,
                        // If there were more fields in the nested topics, they would be parsed here.
                        // For example:
                        // anotherField = no["anotherField"]
                    }).ToArray()
                    // If there were more fields in the main topics, they would be parsed here.
                    // For example:
                    // anotherField = t["anotherField"]
                }).ToArray()
            };

            Debug.Log("Number of topics: " + (dialogData.topics != null ? dialogData.topics.Length.ToString() : "null"));

            dialogManager.StartDialog(dialogData);
        }
        else
        {
            Debug.LogError("No dialog JSON assigned to " + gameObject.name);
        }
    }
}







