using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform[] spawnPoints;         // valid places for things to spawn
    public GameObject enemyPrefab;          // prefab to spawn
    public float spawnTime = 6f;            // how long between each spawn
    private Vector3 spawnPosition;


    SpawnManager instance;

    //Awake is always called before any Start functions
    void Awake() {
        //Check if instance already exists
        if (instance == null) {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this) {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("SpawnAtPoint", spawnTime, spawnTime);
    }

    void Spawn() {
        spawnPosition.x = Random.Range(-17, 17);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-17, 17);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnAtPoint() {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Debug.Log("Spawning at index: " + spawnIndex);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
