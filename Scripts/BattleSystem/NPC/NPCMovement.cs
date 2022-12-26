using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Technoire.BattleSystem.Attacks;

namespace Technoire.BattleSystem
{
    public class NPCMovement : MonoBehaviour
    {
        GameObject NPC => gameObject;
        GridBounds npcBounds = new GridBounds(1, 4, 1, -1);

        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        public GameObject emptySquareChecker;
        public Vector2 currentNpcPosition;
        public Vector2 rayOrigin;

        public bool canMove;
        public int logicalX_NPC, logicalY_NPC;


        private void Update()
        {
            //currentNpcPosition = transform.position;
            rayOrigin = emptySquareChecker.transform.position;
            GetDirection();
            
        }

        void GetDirection()
        {
            
            int randomIndex = Random.Range(0, 3);
            Vector2 direction = directions[randomIndex];
            var hit = Physics2D.Raycast(rayOrigin, direction, 2f);
            CheckIfCanMove(direction, hit);

           
        }

        void CheckIfCanMove(Vector2 direction, RaycastHit2D hit)
        {
           
            if(direction == Vector2.up)
            {
                Debug.Log("entered");
                if (hit.collider == null && logicalY_NPC != npcBounds.y_Boundry_Up)
                {
                    Debug.Log("chose up");
                    transform.position = new Vector2(transform.position.x, transform.position.y + 2f);
                    logicalY_NPC++;
                }
            }
            else if(direction == Vector2.down)
            {
                if (hit.collider == null && logicalY_NPC != -1)
                {
                    NPC.transform.position = new Vector2(currentNpcPosition.x, currentNpcPosition.y - 2f);
                    logicalY_NPC--;
                }
            }
            else if (direction == Vector2.left)
            {
                if (hit.collider == null && logicalX_NPC != 4)
                {
                    transform.position = new Vector2(currentNpcPosition.x -2, currentNpcPosition.y);
                    logicalX_NPC--;
                }
            }
            else if (direction == Vector2.right)
            {
                if (hit.collider == null && logicalX_NPC != -1)
                {
                    transform.position = new Vector2(currentNpcPosition.x +2, currentNpcPosition.y);
                    logicalX_NPC++;
                }
            }
        }

       

    }
}

