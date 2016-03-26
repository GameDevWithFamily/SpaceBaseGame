using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour {

    public static SpriteController instance;
    Dictionary<Tile, GameObject> gameObjects;
    public Dictionary<string, Sprite> sprites;

	// Use this for initialization
	void Start () {
        sprites = new Dictionary<string, Sprite>();
        Sprite[] localSprites = Resources.LoadAll<Sprite>("Tiles/");
        foreach (Sprite s in localSprites) {
            sprites.Add(s.name, s);
        }
        instance = this;
        gameObjects = new Dictionary<Tile, GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InitializeTile(Tile t) {
        GameObject tileGO = new GameObject();
        gameObjects.Add(t, tileGO);
        SpriteRenderer tileSR = tileGO.AddComponent<SpriteRenderer>();
        tileSR.sprite = null;
        tileGO.transform.position = new Vector3(t.x, t.y, 0);
        tileGO.transform.SetParent(this.transform, true);
    }

    public void onTileChanged(Tile t) {
        GameObject tileGO = gameObjects[t];
        SpriteRenderer tileSR = tileGO.GetComponent<SpriteRenderer>();
        if (sprites.ContainsKey(t.Type.ToString()))
        {
            tileSR.sprite = sprites[t.Type.ToString()];
        }
        else {
            tileSR.sprite = sprites["Missing"];
        }
    }
}
