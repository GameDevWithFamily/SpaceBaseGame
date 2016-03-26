using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

    World world;
    bool init = false;

	// Use this for initialization
	void Start () {
        
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
