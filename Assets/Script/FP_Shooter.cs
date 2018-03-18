using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Shooter : MonoBehaviour {

    //CLASS NOT CURRENTLY USED

    public GameObject bullet_prefab;
    public WeaponManager wepManager;

    // Use this for initialization
    private void Start() {
        wepManager = GameObject.FindObjectOfType<WeaponManager>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1")) {
            wepManager.Shoot();
        }
	}
}
