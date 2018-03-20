using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon {

    float shotCooldown = .1f;
    float maxRange = 80f;
    int bulletDamage = 10;
    int maxAmmo = 41;

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

    public override float MaxRange {
        get {
            return maxRange;
        }
    }

    public override int BulletDamage {
        get {
            return bulletDamage;
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
