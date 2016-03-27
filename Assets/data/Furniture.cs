using UnityEngine;
using System.Collections.Generic;
using System;

public class Furniture {

    Tile tile;
    string furnitureType;
    float movementCost;
    Action<Furniture> onUpdate;

    public Dictionary<string, System.Object> variables = new Dictionary<string, System.Object>();
    public void update(){
        if(onUpdate != null)
            onUpdate(this);
    }

    public Furniture(string furnitureType, float movementCost, Action<Furniture> onUpdate) {
        this.furnitureType = furnitureType;
        this.movementCost = movementCost;
        this.onUpdate = onUpdate;
    }

    public Furniture(Furniture prefab, Tile tile) {
        this.tile = tile;
        this.furnitureType = prefab.furnitureType;
        this.movementCost = prefab.movementCost;
        this.onUpdate = prefab.onUpdate;
    }

}
