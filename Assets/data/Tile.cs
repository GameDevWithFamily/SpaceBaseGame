using UnityEngine;
using System.Collections;
using System;

public enum TileType { Space, Floor }

public class Tile {

    public int x, y;
    World world;
    Action<Tile> cbTileChanged;

    public TileType Type {
        get {
            return type;
        }
        set {
            type = value;
            if (cbTileChanged != null)
                cbTileChanged(this);
        }
    }

    TileType type;

    public Tile(int x, int y, World world) {
        this.x = x;
        this.y = y;
        this.world = world;
    }

    public void registerOnTileChangedCallback(Action<Tile> cb) {
        cbTileChanged += cb;
    }

    public void unregisterOnTileChangedCallback(Action<Tile> cb)
    {
        cbTileChanged -= cb;
    }

}
