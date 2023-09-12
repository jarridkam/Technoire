using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatGrid : MonoBehaviour
{
    public static CombatGrid MasterGrid { get; private set; }

    int x = 8;
    int y = 3;

    //public Vector2 playerPosition;
    public Vector2Int[] enemyPosition;

    private Vector2Int currentTile;
    private List<Vector2Int> coordinates = new List<Vector2Int>();

    public Dictionary<Vector2Int, TileState> tileStates = new Dictionary<Vector2Int, TileState>();

    [HideInInspector]
    public enum TileState
    {
        AVAILABLE,
        UNAVAILABLE,
        TRAP
    }
    public TileState tileState;

    //DebugTools debugTools = new DebugTools();

    private void Awake()
    {
        if (MasterGrid == null)
        {
            MasterGrid = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        CreateGrid();
        AssignStates();
    }

    private void CreateGrid()
    {
        for(int i=1; i<=x; i++)
        {
            for(int j=1; j<=y; j++)
            {
                coordinates.Add(new Vector2Int(i, j));
                //Debug.Log($"{i}, {j}");
            }
        }

        
    }
    private void AssignStates()
    {
        foreach (Vector2Int coordinate  in coordinates)
        {
            if (coordinate.x > 4)
            {
                tileState = enemyPosition.Any(ep => ep == coordinate) ? TileState.UNAVAILABLE : TileState.AVAILABLE;
                if (tileStates.ContainsKey(coordinate))
                {
                    tileStates[coordinate] = tileState;
                }
                else
                {
                    tileStates.Add(coordinate, tileState);
                }
            }
            else
                continue;
        }
        DebugTools.PrintDictionary(tileStates);
    }
}

//Decide actions:
    //Move//Attack//Heal//Do Nothing

