using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    string[] possiblePickupTypes = new string[] { "smallBag, bigChest"};
    public string currentItemType;
    CollectableManager collectableManager;

    //adjust this to change how fast it rotates
    public float rotateSpeed = 50f;
    //adjust this to change speed
    public float speed = 1f;
    //adjust this to change how high it goes
    public float height = 0.5f;
    //adjust this to change the minimum float height
    public float minFloatHeight = 1.5f;

    void Start () {
        collectableManager = GameObject.Find("CollectableManager").GetComponent<CollectableManager>();
	}

    private void Update() {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, minFloatHeight + newY * height, pos.z) ;
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other) {
        collectableManager.PickUpItem(currentItemType);
        Destroy(this.gameObject);
    }

    void OnMouseEnter() {
        //Set object to a layer where it will have an outline
        gameObject.layer = 8;
    }

    void OnMouseExit() {
        //Set object to a layer where it will no longer have an outline
        gameObject.layer = 0;
    }
}
