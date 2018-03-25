using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarryManager : MonoBehaviour {

    public Transform cameraPosition;
    public Transform spotToCarry;
    public float itemMoveSpeed;
    public float maxReach;

    Transform itemToCarry;
    Rigidbody itemToCarryRigidbody;
    bool itemIsBeingCarried;
    float grabDistance;

    public bool ItemIsBeingCarried {
        get {
            return itemIsBeingCarried;
        }
    }

    private void FixedUpdate() {
        if (ItemIsBeingCarried) {
            float step = itemMoveSpeed * Time.deltaTime;
            itemToCarry.position = Vector3.MoveTowards(itemToCarry.position, spotToCarry.position, step);
        }
    }

    private void Update() {
        if (ItemIsBeingCarried) {
            if (Vector3.Distance(cameraPosition.position, itemToCarry.position) > maxReach) {
                DropItem(0f);
            }
        }
    }

    public GameObject PickUpItem(RaycastHit hit) {
        itemIsBeingCarried = true;
        itemToCarry = hit.transform;
        itemToCarryRigidbody = hit.rigidbody;
        itemToCarryRigidbody.useGravity = false;
        //itemToCarryRigidbody.isKinematic = true;
        return itemToCarry.gameObject;
    }

    public void DropItem(float thrustForce) {
        itemIsBeingCarried = false;
        itemToCarry = null;
        itemToCarryRigidbody.useGravity = true;
        //itemToCarryRigidbody.isKinematic = false;
        itemToCarryRigidbody.AddForce(Camera.main.transform.forward * thrustForce, ForceMode.Impulse);
        itemToCarryRigidbody = null;
    }
}
