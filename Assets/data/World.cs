using UnityEngine;
using System.Collections;
using System;

public class World {

    Tile[,] tiles;
    int width, height;

    public World(int width = 100, int height = 100){
        this.width = width;
        this.height = height;
        tiles = new Tile[width, height];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Tile t = new Tile(x, y, this);
                tiles[x, y] = t;
                SpriteController.instance.InitializeTile(t);
                t.registerOnTileChangedCallback(SpriteController.instance.onTileChanged);
            }
        }
    }

    public void randomizeTiles() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                int rand = UnityEngine.Random.Range(0,Enum.GetNames(typeof(TileType)).Length);
                tiles[x, y].Type = (TileType)Enum.GetValues(typeof(TileType)).GetValue(rand);
            }
        }
    }

    public void initializeTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y].Type = TileType.Space;
            }
        }
    }

}
