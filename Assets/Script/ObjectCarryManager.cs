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



    private void FixedUpdate() {
        if (itemIsBeingCarried) {
            float step = itemMoveSpeed * Time.deltaTime;
            itemToCarry.position = Vector3.MoveTowards(itemToCarry.position, spotToCarry.position, step);
        }
    }

    private void Update() {
        if (itemIsBeingCarried) {
            if (Vector3.Distance(cameraPosition.position, itemToCarry.position) > maxReach) {
                DropItem();
            }
        }
    }

    public GameObject PickUpItem(RaycastHit hit) {
        itemIsBeingCarried = true;
        itemToCarry = hit.transform;
        itemToCarryRigidbody = hit.rigidbody;
        itemToCarryRigidbody.useGravity = false;
        return itemToCarry.gameObject;
    }

    public void DropItem() {
        itemIsBeingCarried = false;
        itemToCarry = null;
        itemToCarryRigidbody.useGravity = true;
        itemToCarryRigidbody = null;
    }
}
