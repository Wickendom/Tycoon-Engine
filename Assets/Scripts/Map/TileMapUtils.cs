using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapUtils
{
    private readonly float _cellSize;
    private readonly int _floorLayerMask;
    public TileMapUtils(float cellSize, int layerMask)
    {
        _cellSize = cellSize;
        _floorLayerMask = layerMask;
    }

    public Vector3 GetTileWorldPosition(Vector2 coords)
    {
        return new Vector3(coords.x * _cellSize, 0.5f, coords.y * _cellSize); ;
    }

    public Vector2 GetNearestTileCoordsFromMousePosition()
    {
        Vector3 hitPoint = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, Mathf.Infinity, _floorLayerMask))
        {
            hitPoint = hit.point;
        }
        else
        {
            return Vector2.zero;
        }

        return new Vector2((int)hitPoint.x, (int)hitPoint.y);
    }

    public Vector2 GetNearestVertexFromMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, _floorLayerMask))
        {
            return Vector2.zero;
        }

        Vector2[] verticies = new Tile(new Vector2((int)hit.point.x,(int)hit.point.y)).GetVertexPositions();

        Vector2 nearestVertex = Vector2.zero;
        for (int i = 0; i < verticies.Length - 1; i++)
        {
            if(nearestVertex == Vector2.zero || 
                Vector2.Distance(hit.point, verticies[i]) < 
                Vector2.Distance(hit.point, nearestVertex))
            {
                nearestVertex = verticies[i];
            }
        }

        return nearestVertex;
    }

    public Vector2 GetNearestEdgeCoordsFromMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, _floorLayerMask))
        {
            return Vector2.zero;
        }

        Vector2[] borders = new Tile(new Vector2((int)hit.point.x, (int)hit.point.y)).GetBorders();

        Vector2 nearestBorder = Vector2.zero;
        for (int i = 0; i < borders.Length - 1; i++)
        {
            if (nearestBorder == Vector2.zero ||
                Vector2.Distance(hit.point, borders[i]) <
                Vector2.Distance(hit.point, nearestBorder))
            {
                nearestBorder = borders[i];
            }
        }

        return nearestBorder;
    }
}
