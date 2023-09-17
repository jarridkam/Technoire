using System;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Assertions;

namespace YourNamespace
{
    public class JsonProcessor :MonoBehaviour
    {
        Dictionary<string, Dialog> dialogData = new Dictionary<string, Dialog>();

        private void Start()
        {
            processJason("/Users/jarridkamphenkel/Technoire/Assets/Scripts/DialogSystem/txt/dialog.json");
            if (dialogData != null)
                DebugTools.PrintDictionary(dialogData);
            
        }

        public void processJason(string filePath)
        {
            var jsonContent = File.ReadAllText(filePath);
            this.dialogData = JsonConvert.DeserializeObject<Dictionary<string, Dialog>>(jsonContent);
        }
    }

    public class DialogChoice
    {
        public int ChoiceId { get; set; }
        public string Text { get; set; }
        public string Response { get; set; }
        public bool EndDialog { get; set; }
    }

    public class DialogTopic
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Response { get; set; }
        public int? Followup { get; set; }
        public List<DialogChoice> Choices { get; set; }
    }

    public class Dialog
    {
        public string Greeting { get; set; }
        public List<DialogTopic> Topics { get; set; }
    }

}



