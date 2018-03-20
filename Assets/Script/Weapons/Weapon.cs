using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon {

    float maxRange;
    float shotCooldown;
    int bulletDamage;
    int ammo;
    int maxAmmo;


    /*
     ***********************
     * Getters and Setters * 
     ***********************
     */

    public virtual int Ammo {
        get {
            return ammo;
        }

        set {
            ammo = value;
        }
    }

    public virtual float MaxAmmo {
        get {
            return maxAmmo;
        }
    }

    public virtual float ShotCooldown {
        get {
            return shotCooldown;
        }
    }

    public virtual float MaxRange {
        get {
            return maxRange;
        }
    }

    public virtual int BulletDamage {
        get {
            return bulletDamage;
        }
    }


    /*
     **********************
     * Functional Methods * 
     **********************
     */

    public virtual void Reload() {
        ammo = maxAmmo;
    }
}
