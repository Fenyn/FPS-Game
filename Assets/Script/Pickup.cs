using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    CollectableManager collectableManager;
    public string[] possiblePickupTypes = new string[] { "Apple", "Bread", "Meat", "Wood"};
    public string currentItemType;

	// Use this for initialization
	void Start () {
        collectableManager = GameObject.Find("CollectableManager").GetComponent<CollectableManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger entered. Other object: " + other.gameObject);
        collectableManager.PickUpItem(currentItemType);
        Destroy(this.gameObject);
    }
}
