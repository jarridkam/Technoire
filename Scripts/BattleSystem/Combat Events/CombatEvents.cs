using System;
using System.Collections;
using System.Collections.Generic;
using Technoire.BattleSystem.Attacks;
using UnityEngine;

public class CombatEvents : MonoBehaviour
{
    public static Action UsePrimaryAttack;
    public static Action UseSecondaryAttack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            UsePrimaryAttack?.Invoke();  
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSecondaryAttack?.Invoke();

        }
   }
}


