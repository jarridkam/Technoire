using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Technoire.BattleSystem.Grid
{
    public class EnemyCombatController : MonoBehaviour
    {
        public Vector2Int objectPosition;

        //[SerializeField]
        public List<Vector2Int> availableTiles = new List<Vector2Int>();

        private void Start()
        {
            if(objectPosition != null)
            {
                CheckAdjacentTiles(objectPosition, 1);
                DebugTools.PrintList<Vector2Int>(availableTiles);
            }
            
            
        }

        private void Update()
        {

        }

        //Fix This
        public void CheckAdjacentTiles(Vector2Int currentPosition, int maxMovement)
        {
            for (int x = -maxMovement; x <= maxMovement; x++)
            {
                for (int y = -maxMovement; y <= maxMovement; y++)
                {
                    // Skip the center tile (current position)
                    if (x == 0 && y == 0) continue;

                    // Optional: Skip diagonal tiles for maxMovement of 1 for a more "cross" shape
                    //if (maxMovement == 1 && Math.Abs(x) == 1 && Math.Abs(y) == 1) continue;

                    Vector2Int adjacentTile = new Vector2Int(currentPosition.x + x, currentPosition.y + y);

                    if (CombatGrid.MasterGrid.tileStates != null && CombatGrid.MasterGrid.tileStates[adjacentTile]  == CombatGrid.TileState.AVAILABLE)
                    {
                        availableTiles.Add(adjacentTile);
                    }
                }
            }
        }
    }
}


