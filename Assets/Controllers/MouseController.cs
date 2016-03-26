using UnityEngine;
using System.Collections;
using System;

public class MouseController : MonoBehaviour {

    Vector2 lastPos;
    Sprite previewSprite = null;
    public GameObject previewGO;
    int mode = 0; // 0 = nothing, 1 = tile, 2 = furnature
    TileType type = TileType.Space;

	// Use this for initialization
	void Start () {
	
	}

    public void modeNothing() {
        mode = 0;
        previewSprite = null;
    }

    public void setTileType(string name)
    {
        mode = 1;
        type = (TileType)Enum.Parse(typeof(TileType), name);
        if (SpriteController.instance.sprites.ContainsKey(name))
        {
            previewSprite = SpriteController.instance.sprites[name];
        }
        else {
            previewSprite = SpriteController.instance.sprites["Missing"];
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            lastPos = currentPos;
        }

        if (Input.GetMouseButton(1) || Input.GetMouseButton(2)) {
            Camera.main.gameObject.transform.Translate(lastPos - currentPos);
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 3, 20);

        //if (previewSprite != null) {
            previewGO.GetComponent<SpriteRenderer>().sprite = previewSprite;
            previewGO.transform.position = new Vector3(Mathf.FloorToInt(currentPos.x), Mathf.FloorToInt(currentPos.y));
        //}
        if (Input.GetMouseButtonDown(0))
        {
            if (mode == 1)
            {
                int x = Mathf.FloorToInt(currentPos.x);
                int y = Mathf.FloorToInt(currentPos.y);
                Tile t = WorldController.instance.world.getTileAt(x, y);
                if (t != null)
                    t.Type = type;
            }
        }

	}
}
