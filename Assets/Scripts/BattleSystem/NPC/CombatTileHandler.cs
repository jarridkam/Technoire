
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using TMPro;

namespace Combat.Utilites
{
    public class CombatTileHandler : MonoBehaviour
    {
        public static CombatTileHandler MasterTileHandler { get; private set; }

        public Tilemap gridMap;
        public LayerMask npcLayer;
        public bool visualize;

        public List<Vector3Int> availableTiles = new List<Vector3Int>();
        [HideInInspector]
        public Dictionary<Vector3Int, TileState> enemyTiles = new Dictionary<Vector3Int, TileState>();

        public enum TileState
        {
            AVAILABLE,
            UNAVAILABLE,
            TRAP,
            UNKNOWN
        }

        //private DebugTools tileTools = new DebugTools();

        private void Awake()
        {
            if (MasterTileHandler == null)
            {
                MasterTileHandler = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            ProcessAllTiles();
            Debug.Log("Ran Awake");
        }

        void Start()
        {
            //ProcessAllTiles();
        }

        public void ProcessAllTiles()
        {
            enemyTiles.Clear();

            for (int x = gridMap.cellBounds.min.x; x < gridMap.cellBounds.max.x; x++)
            {
                for (int y = gridMap.cellBounds.min.y; y < gridMap.cellBounds.max.y; y++)
                {
                    Vector3Int position = new Vector3Int(x,y,0);
                    TileBase tile = gridMap.GetTile(position);
                    HandleTile(tile, position);
                    
                }
            }

            foreach(KeyValuePair<Vector3Int, TileState> kv in enemyTiles)
            {
                Debug.Log($"{kv.Key} : {kv.Value}");
            }
        }

        private void HandleTile(TileBase tile, Vector3Int position)
        {
            TileState tileState = ClassifyTile(tile, position);
            if (tile != null && tile.name == "Battle field_1"){enemyTiles.Add(position, tileState);}
            if (visualize) { VisualizeTiles(tile, position); }
        }

        private TileState ClassifyTile(TileBase tile, Vector3Int position)
        {
            if (tile == null)
                return TileState.UNKNOWN;

            switch (tile.name)
            {
                case "Battle field_1":
                    if (IsTileOccupied(position))
                    {
                        DebugTools.DrawSquare(position, gridMap.cellSize, Color.blue, 10f);
                        return TileState.UNAVAILABLE;
                    }
                    return TileState.AVAILABLE;
                case "Battle field_0":
                    return TileState.UNAVAILABLE;
                default:
                    return TileState.UNKNOWN;
            }
        }

        private bool IsTileOccupied(Vector3Int cellPosition)
        {
            Vector3 worldPos = gridMap.GetCellCenterWorld(cellPosition);
            Collider2D collider = Physics2D.OverlapBox(worldPos, gridMap.cellSize, 0, npcLayer);
            return collider != null;
        }

        private void VisualizeTiles(TileBase tile, Vector3Int cellPosition)
        {
            if (tile != null)
            {
                Vector3 worldPosition = gridMap.GetCellCenterWorld(cellPosition);

                GameObject textObj = new GameObject("TileText");
                textObj.transform.position = worldPosition;

                TextMeshPro text = textObj.AddComponent<TextMeshPro>();
                text.text = cellPosition.ToString();
                text.fontSize = 2;
                text.alignment = TextAlignmentOptions.Center;
                text.sortingOrder = 3;

                if (tile.name == "Battle field_0")
                {
                    DebugTools.DrawSquare(worldPosition, gridMap.cellSize, Color.blue, 3f);
                }

                //Debug.Log($"Tile name: {tile.name}, World Position: ({worldPosition.x}, {worldPosition.y})");
            }
        }

        public TileState GetTileState(Vector3Int position)
        {
            if (enemyTiles.ContainsKey(position))
            {
                Debug.Log(enemyTiles[position]);
                return enemyTiles[position];
            }
            Debug.Log("UNKNOWN");
            return TileState.UNKNOWN;
        }

        public Vector3 CellToWorldPosition(Vector3Int cellPosition)
        {
            Vector3 worldPosition = gridMap.CellToWorld(cellPosition);

            worldPosition += new Vector3(gridMap.cellSize.x / 2, gridMap.cellSize.y / 2, 0);

            return worldPosition;
        }
    }

}


