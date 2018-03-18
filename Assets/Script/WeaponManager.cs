using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    Pistol pistol;
    Rifle rifle;
    WeaponManager instance;
    Weapon[] weaponArray;

    public GameObject bulletPrefab;
    public float timeSinceFired;
    public Weapon activeWep;


    public Weapon ActiveWep {
        get {
            return activeWep;
        }

        set {
            activeWep = value;
        }
    }

    //Awake is always called before any Start functions
    void Awake() {
        //Check if instance already exists
        if (instance == null) {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this) {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        InitializeWeapons();
    }

    private void Start() {
        InitializeWeapons();
    }

    private void InitializeWeapons() {
        pistol = new Pistol();
        rifle = new Rifle();
        weaponArray = new Weapon[4];
        pistol.Reload();
        rifle.Reload();
        weaponArray[0] = pistol;
        weaponArray[1] = rifle;
        ActiveWep = weaponArray[0];
        Debug.Log("Active weapon is now a " + ActiveWep);
        timeSinceFired = 0;
    }

    private void Update() {
        timeSinceFired += Time.deltaTime;

        //Weapon Switching
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ActiveWep = weaponArray[0];
            Debug.Log("Active weapon is now a " + ActiveWep);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            ActiveWep = weaponArray[1];
            Debug.Log("Active weapon is now a " + ActiveWep);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            ActiveWep = weaponArray[2];
            Debug.Log("Active weapon is now a " + ActiveWep);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            ActiveWep = weaponArray[3];
            Debug.Log("Active weapon is now a " + ActiveWep);
        }

        //Fire weapon
        if (Input.GetButton("Fire1")) {
            Shoot();
        }

        //Reload Weapon
        if (Input.GetKeyDown(KeyCode.R)) {
            ActiveWep.Reload();
        }

    }

    public void Shoot() {
        if (timeSinceFired >= ActiveWep.ShotCooldown && ActiveWep.Ammo > 0) {
            ActiveWep.Ammo--;

            //Raycast out to find a hit, then spawn a bullet object to mark the location
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f)) {
                Vector3 hitPoint = hitInfo.point;
                Instantiate(bulletPrefab, hitPoint, Quaternion.identity);
            }
            timeSinceFired = 0f;
        }


    }
}