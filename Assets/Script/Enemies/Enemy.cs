using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float moveSpeed;
    public float rotateSpeed;

    Quaternion rotation;
    Vector3 radius;
    float currentRotation;

    // Use this for initialization
    void Start () {
    
	}
	

    void Update() {
        transform.Translate(0, 0, Time.deltaTime * moveSpeed);
        transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }
}
