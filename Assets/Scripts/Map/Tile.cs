using UnityEngine;

public class Tile
{
    private readonly Vector2 _gridPosition;
    private readonly Vector2[] _vertexPositions;
    private readonly Vector2 _edgeWPosition;
    private readonly Vector2 _edgeSPosition;

    public Tile(Vector2 gridPosition)
    {
        _gridPosition = gridPosition;

        _vertexPositions = new Vector2[4];
        _vertexPositions[0] = _gridPosition;
        _vertexPositions[1] = new Vector2(_gridPosition.x+1,_gridPosition.y);
        _vertexPositions[2] = new Vector2(_gridPosition.x,_gridPosition.y+1);
        _vertexPositions[3] = new Vector2(_gridPosition.x+1,_gridPosition.y+1);

        _edgeWPosition = _gridPosition;
        _edgeSPosition = _gridPosition;
    }

    public Vector2[] GetNeighbors()
    {
        Vector2[] neighbors = new Vector2[4];

        neighbors[0] = new Vector2(_gridPosition.x - 1, 0);
        neighbors[1] = new Vector2(0, _gridPosition.y - 1);
        neighbors[2] = new Vector2(_gridPosition.x + 1,0);
        neighbors[3] = new Vector2(0, _gridPosition.y + 1);

        return neighbors;
    }

    public Vector2[] GetVertexPositions()
    {
        return _vertexPositions;
    }

    public Vector2[] GetBorders()
    {
        Vector2[] borders = new Vector2[4];

        borders[0] = _edgeWPosition;
        borders[1] = _edgeSPosition;
        borders[2] = new Vector2(_edgeWPosition.x + 1, _edgeWPosition.y);
        borders[3] = new Vector2(_edgeSPosition.x, _edgeSPosition.y + 1);

        return borders;
    }
}
