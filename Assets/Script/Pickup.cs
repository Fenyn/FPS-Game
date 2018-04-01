using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    CollectableManager collectableManager;
    string[] possiblePickupTypes = new string[] { "Apple", "Bread", "Meat", "Wood"};

    public string currentItemType;
    public float rotateSpeed = 50f;

    //adjust this to change speed
    public float speed = 1f;
    //adjust this to change how high it goes
    public float height = 0.5f;

    // Use this for initialization
    void Start () {
        collectableManager = GameObject.Find("CollectableManager").GetComponent<CollectableManager>();
	}

    private void Update() {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, 1.5f + newY * height, pos.z) ;
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger entered. Other object: " + other.gameObject);
        collectableManager.PickUpItem(currentItemType);
        //Destroy(this.gameObject);
    }

    void OnMouseEnter() {
        gameObject.layer = 8;
    }

    void OnMouseExit() {
        gameObject.layer = 0;
    }
}
