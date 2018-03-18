using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

    float shotCooldown = 1f;
    int maxAmmo = 18;

    int ammo;


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
