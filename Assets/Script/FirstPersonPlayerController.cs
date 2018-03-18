using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
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
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        statManager = GameObject.Find("Player").GetComponent<StatisticsManager>();
        moveSpeed = statManager.moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

        //Camera Rotation
        float rotLR = Input.GetAxis("Mouse X");
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivityUD;
        verticalRotation = Mathf.Clamp(verticalRotation, -cameraRotationLimit, cameraRotationLimit);

        transform.Rotate(0, rotLR*mouseSensitivityLR, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);

        //Character Movement
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime * 2;
        if (cc.isGrounded) {
            verticalVelocity = 0;
        }

        if (Input.GetButton("Jump") && (cc.isGrounded || numOfJumps< maxNumOfJumps)) {
            verticalVelocity = jumpHeight;
            if(numOfJumps < maxNumOfJumps) {
                numOfJumps++;
                Debug.Log(numOfJumps);
            }
        }

        //if(Input.GetButton("Jump") && numOfJumps < maxNumOfJumps) {
        //    verticalVelocity = jumpHeight;
        //    numOfJumps++;
        //}

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity,forwardSpeed);

        speed = transform.rotation * speed;


        //cc.SimpleMove(speed*moveSpeed);

        cc.Move(speed * Time.deltaTime);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 50);
	}
}
