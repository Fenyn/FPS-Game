using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour {

    public Transform[] enemySpawnPoints;         // valid places for things to spawn
    public GameObject enemyPrefab;          // prefab to spawn
    public GameObject[] pickupPrefabs;
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
        InvokeRepeating("SpawnEnemyAtPoint", spawnTime, spawnTime);

        InvokeRepeating("SpawnPickupsRandomly", spawnTime, spawnTime);

    }

    void Spawn() {
        spawnPosition.x = Random.Range(-17, 17);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-17, 17);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnEnemyAtPoint() {
        int spawnIndex = Random.Range(0, enemySpawnPoints.Length);
        Debug.Log("Spawning at index: " + spawnIndex);
        Instantiate(enemyPrefab, enemySpawnPoints[spawnIndex].position, enemySpawnPoints[spawnIndex].rotation);
    }

    void SpawnPickupsRandomly() {
        Debug.Log("Spawning pickup");
        Instantiate(pickupPrefabs[0], RandomNavmeshLocation(40f), Quaternion.identity);
    }

    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
