using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    float timeSinceSpawn = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= 5f){
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Explode() {
        Destroy(this.gameObject);
    }
}
