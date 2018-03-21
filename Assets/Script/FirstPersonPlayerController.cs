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
    public int maxNumOfJumps = 2;

    float verticalRotation = 0f;
    float moveSpeed;
    int numOfJumps = 0;

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

    }
}
