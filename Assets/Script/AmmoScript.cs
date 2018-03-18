using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour {

    public GameObject ammoCounterUIObject;
    public WeaponManager wepManager;

    int ammo;

    // Use this for initialization
    void Start() {
        updateAmmo();
    }

    // Update is called once per frame
    void Update() {
        updateAmmo();
    }

    void updateAmmo() {
        ammo = wepManager.ActiveWep.Ammo;
        ammoCounterUIObject.GetComponent<Text>().text = ammo.ToString();
    }
}
