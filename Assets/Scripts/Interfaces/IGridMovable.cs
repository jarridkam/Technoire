using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridMovable
{
    public List<Vector2Int> CheckAdjacentTiles(Vector2Int currentPosition, int maxMovement);
}
