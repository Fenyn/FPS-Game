using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon {

    float shotCooldown = .1f;

    int ammo;
    int maxAmmo = 41;

    /*
     ***********************
     * Getters and Setters * 
     ***********************
     */

    public override int Ammo {
        get {
            return ammo;
        }

        set {
            ammo = value;
        }
    }

    public override float MaxAmmo {
        get {
            return maxAmmo;
        }
    }

    public override float ShotCooldown {
        get {
            return shotCooldown;
        }
    }


    /*
     **********************
     * Functional Methods * 
     **********************
     */

    public override void Reload() {
        ammo = maxAmmo;
    }
}
