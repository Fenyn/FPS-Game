using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Shooter : MonoBehaviour {

    public GameObject bullet_prefab;
    public WeaponManager wepManager;

    // Use this for initialization
    private void Start() {
        wepManager = GameObject.FindObjectOfType<WeaponManager>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            wepManager.Shoot();
        }
	}
}
