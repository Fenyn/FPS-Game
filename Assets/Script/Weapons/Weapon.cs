using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon {

    int ammo;
    int maxAmmo;
    float shotCooldown;

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

    public virtual void Reload() {
        ammo = maxAmmo;
    }
}
