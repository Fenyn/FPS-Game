using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject enemyPrefab;          // prefab to spawn
	public float spawnTime = 6f;            // how long between each spawn
    private Vector3 spawnPosition;

    // Use this for initialization
    void Start() {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn() {
        spawnPosition.x = Random.Range(-17, 17);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-17, 17);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
