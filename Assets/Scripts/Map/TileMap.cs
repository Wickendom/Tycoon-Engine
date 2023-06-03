using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public Dictionary<Vector2, Tile> tileMap;

    public readonly float cellSize = 2;

    [SerializeField]
    private int gridMapSizeX = 20, gridMapSizeY = 20;
    
    
    public void GenerateTileMap()
    {
        for (int x = 0; x < gridMapSizeX; x++)
        {
            for (int y = 0; y < gridMapSizeY; y++)
            {
                tileMap.Add(new Vector2(x, y), new Tile(new Vector2(x,y)));
            }
        }
    }

    public Tile GetTile(Vector2 coords)
    {
        Tile tile = null;

        if(!tileMap.TryGetValue(coords,out tile))
        {
            Debug.LogWarning($"Tile not found at coordinates: {coords}");
            tile = tileMap[Vector2.zero];
        }

        return tile;
    }
}
