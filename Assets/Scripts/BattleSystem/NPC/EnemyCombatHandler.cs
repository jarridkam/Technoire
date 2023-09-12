using UnityEngine;
using Combat.Utilites;
using System.Collections.Generic;

public class EnemyCombatHandler : MonoBehaviour
{
    public CombatTileHandler masterTileHandler;

    private Vector3Int currentTilePosition;
    //private DebugTools tileTools = new DebugTools();
    private Vector3Int[] adjacentOffsets = {
        new Vector3Int(0, -1, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(-1, -1, 0),
        new Vector3Int(1, -1, 0),
        new Vector3Int(-1, 1, 0),
        new Vector3Int(1, 1, 0)
    };

    private void Start()
    {
        currentTilePosition = UpdateCurrentTilePosition();

        GatherAdjacentTileStates();
    }

    private void Update()
    {
        Vector3Int changedTile = currentTilePosition;
        
        currentTilePosition = UpdateCurrentTilePosition();

        if (changedTile != currentTilePosition)
        {
            masterTileHandler.ProcessAllTiles();
            Debug.Log("Tile Changed");
        }
    }

    private void GatherAdjacentTileStates()
    {
        foreach (Vector3Int offset in adjacentOffsets)
        {
            Vector3Int adjacentTile = currentTilePosition + offset;

            if (masterTileHandler.GetTileState(adjacentTile) == CombatTileHandler.TileState.AVAILABLE)
            {
                masterTileHandler.availableTiles.Add(adjacentTile);
            }
        }
    }

    private Vector3Int UpdateCurrentTilePosition()
    {
        Vector3 worldPosition = transform.position;
        currentTilePosition = masterTileHandler.gridMap.WorldToCell(worldPosition);
        return currentTilePosition;
    }    
}

//Get Current position
//Take in motivation Factors


