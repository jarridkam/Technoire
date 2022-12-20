using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Technoire.BattleSystem
{
    public class NpcGridMovement : MonoBehaviour
    {
        GameObject NPC => gameObject;
        public bool canMove;
        static Vector2 currentPosition;

        GridBounds boundries = new GridBounds(1, 4, 1, 1);
        public int logicalPositionX, logicalPositionY;


        private void Update()
        {
            currentPosition = transform.position;

            
        }

        void ChooseRandomDirection()
        {

        }



    }
}

