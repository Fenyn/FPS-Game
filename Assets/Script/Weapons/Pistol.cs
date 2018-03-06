using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

    float bulletImpulse = 30f;
    float shotCooldown = 1f;

	void Shoot() {
        if (Input.GetButtonDown("Fire1") && shotCooldown <= Time.deltaTime) {
            Debug.Log("shoot bullet here");
            //Camera camera = Camera.main;
            //GameObject bullet = Instantiate(bullet_prefab, camera.transform.position + camera.transform.forward, camera.transform.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(camera.transform.forward * bulletImpulse, ForceMode.Impulse);
        }
    }
}
