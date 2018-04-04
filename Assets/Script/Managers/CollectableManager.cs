using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour {

    int numOfApples = 0;
    int numOfBreadLoves = 0;
    int numOfWood = 0;
    int numOfMeat = 0;
    int numOfActiveCollectables = 0;

    CollectableManager instance;
    LevelManager levelManager;

    public int NumOfApples {
        get {
            return numOfApples;
        }
    }

    public int NumOfBreadLoves {
        get {
            return numOfBreadLoves;
        }
    }

    public int NumOfWood {
        get {
            return numOfWood;
        }
    }

    public int NumOfMeat {
        get {
            return numOfMeat;
        }
    }

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
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        InitializePickups();
    }

    private void Update() {
    }

    public void PickUpItem(string pickupType) {
        switch (pickupType.ToLower()) {
            case "apple":
                Debug.Log("Incrementing " + pickupType.ToLower());
                numOfApples++;
                break;
            case "bread":
                Debug.Log("Incrementing " + pickupType.ToLower());
                numOfBreadLoves++;
                break;
            case "meat":
                Debug.Log("Incrementing " + pickupType.ToLower());
                numOfMeat++;
                break;
            case "wood":
                Debug.Log("Incrementing " + pickupType.ToLower());
                numOfWood++;
                break;
            default:
                Debug.Log("Incrementing " + pickupType.ToLower());
                break;
        }

        DecrementCollectables();
    }

    void InitializePickups() {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("pickup");
        foreach (GameObject pickup in pickups) {
            numOfActiveCollectables++;
        }
    }

    public void DecrementCollectables() {
        numOfActiveCollectables--;
        Debug.Log(numOfActiveCollectables);
        if (numOfActiveCollectables <= 0) {
            Debug.Log("Ending level");
            //levelManager.CompleteLevel();
        }
    }
}
