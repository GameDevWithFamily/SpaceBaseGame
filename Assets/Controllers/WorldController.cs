using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

    public World world;
    bool init = false;
    public static WorldController instance;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (!init) {
            world = new World();
            world.initializeTiles();
            init = true;
        }
	}
}
