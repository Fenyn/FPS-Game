using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TerrainSetter : MonoBehaviour {

    public float treeDistance;
    public float objectDistance;
    public Terrain terrain;

	// Use this for initialization
	void Update () {
        terrain.treeDistance = treeDistance;
        terrain.detailObjectDistance = objectDistance;
	}
	
}
