using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryManager : MonoBehaviour {

    public Transform cameraPosition;
    public Transform spotToCarry;
    public float itemMoveSpeed;
    public float rotationSpeed;
    public float maxReach;

    public Transform itemToCarry;
    Rigidbody itemToCarryRigidbody;
    public bool itemIsBeingCarried;

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
                //DropItem();
            } else {
                RotateObject();
            }
        }
    }

    public GameObject PickUpItem(RaycastHit hit) {
        itemIsBeingCarried = true;
        itemToCarry = hit.transform;
        itemToCarryRigidbody = hit.rigidbody;
        itemToCarryRigidbody.useGravity = false;
        itemToCarryRigidbody.freezeRotation = true;
        //itemToCarryRigidbody.isKinematic = true;
        return itemToCarry.gameObject;
    }

    //Releases item using a given force, force dictates how much outward momentum an object will get
    public void DropItem(float thrustForce = 1f) {
        itemIsBeingCarried = false;
        itemToCarry = null;
        itemToCarryRigidbody.useGravity = true;
        itemToCarryRigidbody.freezeRotation = false;
        //itemToCarryRigidbody.isKinematic = false;
        itemToCarryRigidbody.AddForce(Camera.main.transform.forward * thrustForce, ForceMode.Impulse);
        itemToCarryRigidbody = null;
    }

    public void RotateObject() {
        Camera cam = Camera.main;
        //Get mouse position
        Vector3 mousePos = Input.mousePosition;

        //Adjust mouse z position
        mousePos.z = cam.transform.position.y - itemToCarry.position.y;

        //Get a world position for the mouse
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos);

        //Get the angle to rotate and rotate
        float angle = -Mathf.Atan2(itemToCarry.position.z - mouseWorldPos.z, itemToCarry.position.x - mouseWorldPos.x) * Mathf.Rad2Deg;
        itemToCarry.rotation = Quaternion.Slerp(itemToCarry.rotation, Quaternion.Euler(0, angle, 0), rotationSpeed * Time.deltaTime);
    }
}
