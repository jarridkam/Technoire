using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Technoire.BattleSystem.Attacks;

namespace Technoire.BattleSystem
{
    public class PlayerCombatManager : MonoBehaviour
    {
        public static System.Action FireAnimation;

        GameObject player => gameObject;
        public GameObject logicalShootObject;
        public AttackContainter attackContainter;
        Vector2 shootSpot;

        AttackObject primaryAttack;
        AttackObject secondaryAttack;

        public bool fireAttack1;
        public bool fireAttack2;

        //for ui whe we have to make it 
        string primaryAttackName => primaryAttack.attackName;
        string secondaryAttackName => secondaryAttack.attackName;

        private void OnEnable()
        {
            CombatEvents.UsePrimaryAttack += UseAttack;
            CombatEvents.UseSecondaryAttack += UseAttack;
            SetAttacks();
        }

        private void OnDisable()
        {
            CombatEvents.UsePrimaryAttack -= UseAttack;
            CombatEvents.UseSecondaryAttack -= UseAttack;
        }

        private void Update()
        {
            shootSpot = logicalShootObject.transform.position;
            SetAttackBool();
        }


        private void SetAttacks()
        {
            primaryAttack = attackContainter.attackList[0];
            secondaryAttack = attackContainter.attackList[1];
        }

        private void SetAttackBool()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fireAttack1 = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space) || !Input.GetKeyDown(KeyCode.Space))
            {
                fireAttack1 = false;
            };
            if (Input.GetKeyDown(KeyCode.E))
            {
                fireAttack2 = true;
            }
            else if (Input.GetKeyUp(KeyCode.E) || !Input.GetKeyDown(KeyCode.E))
            {
                fireAttack2 = false;
            };

        }

        void UseAttack()
        {
            if (fireAttack1)
            {
                Debug.Log(primaryAttack.attackName + " used"!);
                if (primaryAttack.isRanged) { RangedAttack(); }
                else { MeleeAttack(); }

            }
            else if (fireAttack2)
            {
                Debug.Log(secondaryAttack.attackName + " used"!);
                if (secondaryAttack.isRanged) { RangedAttack(); }
                else { MeleeAttack(); }
            }

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

            FireAnimation?.Invoke();
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
    }
}


