using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float lifetime = 1f;

    // Use this for initialization
    void Start() {
        Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void Update() {
        
    }

}
