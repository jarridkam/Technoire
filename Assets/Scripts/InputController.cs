using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputController 
{
    public const KeyCode INTERACTION_KEY = KeyCode.E;
    public const KeyCode ACCEPT_ACTION_KEY = KeyCode.Space;

    public static bool Pressed(KeyCode k)
    {
        return Input.GetKeyDown(k);
    }

    public static bool Interact()
    {
        return Input.GetKeyDown(INTERACTION_KEY);
    }
}
