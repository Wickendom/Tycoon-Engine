using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance;

    public TileMap TileMap { get; private set; }
    public TileMapUtils TileMapUtils { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }

        TileMap = GetComponentInChildren<TileMap>();
        TileMapUtils = new TileMapUtils(TileMap.cellSize,LayerMask.NameToLayer("Floor"));
    }
}