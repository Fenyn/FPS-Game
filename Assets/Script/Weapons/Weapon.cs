using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {

    int ammo;
    int maxAmmo;

    public GameObject bullet_prefab;

    private void Start() {
        ammo = maxAmmo;
    }

    public void Shoot() {

    }
}
