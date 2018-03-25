using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonPlayerController : MonoBehaviour {

    public StatisticsManager statManager;
    public float mouseSensitivityLR = 2f;
    public float mouseSensitivityUD = 2f;
    public float cameraRotationLimit = 60.0f;
    public float jumpHeight = 5.0f;
    public float verticalVelocity = 0f;
    public float pushPower = 2.0f;
    public int maxNumOfJumps = 2;

    float verticalRotation = 0f;
    float moveSpeed;
    int numOfJumps = 0;
    bool holdingItem = false;
    GameObject heldItem;

    CharacterController cc;

    // Use this for initialization
    void Start() {
        /* Following code provided by  Martin "quill18" Glaude */
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        statManager = GameObject.Find("Player").GetComponent<StatisticsManager>();
        moveSpeed = statManager.MoveSpeed;
        /* End code provided by  Martin "quill18" Glaude */
    }

    // Update is called once per frame
    void Update() {

        /* Following code provided by  Martin "quill18" Glaude */
        //Camera Rotation
        float rotLR = Input.GetAxis("Mouse X");
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivityUD;
        verticalRotation = Mathf.Clamp(verticalRotation, -cameraRotationLimit, cameraRotationLimit);

        transform.Rotate(0, rotLR * mouseSensitivityLR, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Character Movement
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        /* End code provided by  Martin "quill18" Glaude */

        //Reset relevant parameters when character hits the ground
        if (cc.isGrounded) {
            verticalVelocity = 0;
            numOfJumps = 0;
        }

        //Character Jumping
        if (Input.GetButtonDown("Jump") && (cc.isGrounded || numOfJumps < maxNumOfJumps)) {
            verticalVelocity = jumpHeight;
            numOfJumps++;
        }

        //Basic gravity simulation, doubled the gravitic constant to provide for more responsive falling
        verticalVelocity += Physics.gravity.y * Time.deltaTime * 2;


        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;


        //cc.SimpleMove(speed*moveSpeed);

        cc.Move(speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E) && !holdingItem) {
            Debug.Log("Entering !holdingItem brackets");
            heldItem = CrateController.WalkedOverObject;
            Debug.Log("Attempted to hold item. HeldItem: " + heldItem);
            if (heldItem) {
                Debug.Log("heldItem was true");
                heldItem.transform.parent = this.gameObject.transform;
                Debug.Log("Attempted to set parent of held item");
                holdingItem = true;
            }
        } else if (Input.GetKeyDown(KeyCode.E) && holdingItem) {
            Debug.Log("Clearing held item");
            heldItem.transform.parent = null;
            heldItem = null;
            holdingItem = false;
        }
    }


    
    /* Following code taken from stack overflow */
    // this script pushes all rigidbodies that the character touches
    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic) { return; }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3) {
            return;
        }
        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.
        // Apply the push
        body.velocity = pushDir * pushPower;

    }

}
