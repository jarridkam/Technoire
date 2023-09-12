using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Technoire.BattleSystem.Attacks;
using System;

namespace Technoire.BattleSystem
{
    public class PlayerCombatManager : MonoBehaviour
    {
        public static System.Action FireAnimation;

        GameObject player => gameObject;
        public GameObject logicalShootObject;
        Vector2 shootSpot;

        public AttackData primaryAttack;
        public AttackData secondaryAttack;
      
        //for ui we have to make it 
        string primaryAttackName => primaryAttack.attackName;
        string secondaryAttackName => secondaryAttack.attackName;

        private void OnEnable()
        {
            CombatEvents.UsePrimaryAttack += UsePrimaryAttack; //event listener
            CombatEvents.UseSecondaryAttack += UseSecondaryAttack; //event listener
        }

        private void OnDisable()
        {
            CombatEvents.UsePrimaryAttack -= UsePrimaryAttack;
            CombatEvents.UseSecondaryAttack -= UseSecondaryAttack;
        }

        private void Update()
        {
            shootSpot = logicalShootObject.transform.position;
        }

        void UsePrimaryAttack()
        {
            Debug.Log(primaryAttack.attackName + " used"!);
            if (primaryAttack.isRanged) { RangedAttack(); }
            else { MeleeAttack(); } 
        }

        void UseSecondaryAttack()
        {
            Debug.Log(secondaryAttack.attackName + " used"!);
            if (secondaryAttack.isRanged) { RangedAttack(); }
            else { MeleeAttack(); }
        }

        void RangedAttack()
        {

            RaycastHit2D shoot = Physics2D.Raycast(shootSpot, Vector2.right, 30);

            Debug.DrawRay(shootSpot, Vector2.right * 20f, Color.red, 3);
            Debug.DrawLine(shootSpot, shootSpot + Vector2.right * 25, Color.white);

            if (shoot.collider != null)
            {
                Debug.Log(shoot.collider.gameObject.name);  
            }
            else
            {
                Debug.Log(shoot + "is null");
            }
        }

        void MeleeAttack()
        {
            RaycastHit2D slash = Physics2D.Raycast(shootSpot, Vector2.right, 2);

            Debug.DrawRay(shootSpot, Vector2.right * 2, Color.red, 3);
            

            if (slash.collider != null)
            {
                Debug.Log(slash.collider.gameObject.name);
               
            }
            else
            {
                Debug.Log(slash + "is null");
            }
        }

        public class CombatEvents 
        {
            public static Action UsePrimaryAttack;
            public static Action UseSecondaryAttack;

            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    UsePrimaryAttack?.Invoke(); //event sender
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    UseSecondaryAttack?.Invoke(); //event sender
                }
            }
        }
    }
}


