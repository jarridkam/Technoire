using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public bool InteractionTrigger
    {
        get { return interactionTrigger; }
        set { interactionTrigger = value; }
    }
    private bool interactionTrigger;

    public void OnTriggerEnter2D(Collider2D collider)
    {

        interactionTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactionTrigger = false;
    }

    private void Update()
    {
        
    }
}
