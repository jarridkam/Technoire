using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Technoire.BattleSystem.Grid
{
    public class GridMovement : MonoBehaviour
    {
        public static GridMovement PlayerMovement { get; private set; }

        public Vector2Int currentPosition;

        private GameObject player => gameObject;
        private bool canMove;
      
        private int logicalPositionX = 3;
        private int logicalPositionY = 0;

        GridBounds boundries = new GridBounds(1, 4, 1, -1);

        private void Awake()
        {
            if (PlayerMovement == null)
            {
                PlayerMovement = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            canMove = true;
            Move();
        }

        public bool CheckIfCanMove(string direction)
        {
            if(direction == "up" && logicalPositionY != boundries.y_Boundry_Up)
            {
                return true; 
            }

            if (direction == "down" && logicalPositionY != boundries.y_Boundry_Down)
            {
                return true;
            }

            if (direction == "left" && logicalPositionX != boundries.x_Boundry_Left)
                return true;

            else if (direction == "right" && logicalPositionX != boundries.x_Boundry_Right)
                return true;

           
                return false;
        }

        public void Move()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { if(CheckIfCanMove("up")) { MoveTick("up"); } }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) { if (CheckIfCanMove("down")){ MoveTick("down"); } }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) { if (CheckIfCanMove("left")){ MoveTick("left"); } }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){ if (CheckIfCanMove("right")){ MoveTick("right"); } }
        }

        private void MoveTick(string direction)
        {

            if (direction.ToLower() == "up")
            {
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
                logicalPositionY++;
                currentPosition.y++;

            }
            else if (direction.ToLower() == "down")
            {
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                logicalPositionY--;
                currentPosition.y--;
            }
            else if (direction.ToLower() == "left")
            {
                gameObject.transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                logicalPositionX--;
                currentPosition.x--;
            }
            else if (direction.ToLower() == "right")
            {
                gameObject.transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                logicalPositionX++;
                currentPosition.x++;
            }

            //canMove = false;
        } 
    }

    public class GridBounds
    {
        public float x_Boundry_Left, x_Boundry_Right, y_Boundry_Up, y_Boundry_Down;

        public GridBounds(float xL, float xR, float yU, float yD)
        {
            this.x_Boundry_Left = xL;
            this.x_Boundry_Right = xR;
            this.y_Boundry_Up = yU;
            this.y_Boundry_Down = yD;
        }
    }
}




  