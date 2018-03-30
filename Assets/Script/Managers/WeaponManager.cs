using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    Pistol pistol;
    Rifle rifle;
    WeaponManager instance;
    Weapon[] weaponArray;

    public GameObject[] weaponPrefabArray;
    public GameObject bulletPrefab;
    public float timeSinceFired;
    public Weapon activeWep;

    private const int PullGun = 0;
    private const int PushGun = 1;

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
    }

    private void InitializeWeapons() {

        pistol = new Pistol();
        rifle = new Rifle();

        
        weaponArray = new Weapon[2];
        weaponArray[0] = pistol;
        weaponArray[1] = rifle;

        pistol.Reload();        
        rifle.Reload();

        ActiveWep = weaponArray[0];
        setActiveWeapon(0);
        Debug.Log("Active weapon is now a " + ActiveWep);
        timeSinceFired = 0;
    }

    //Takes a number and sets the weapon prefab associated with that value to be visible and all others to be invisible
    //a.k.a. weapon switching
    void setActiveWeapon(int wepNum) {
        for(int i = 0; i < weaponPrefabArray.Length; i++) {
            if(i == wepNum) {
                weaponPrefabArray[i].SetActive(true);
            }
            else { weaponPrefabArray[i].SetActive(false); }
        }
    }

    private void Update() {
        timeSinceFired += Time.deltaTime;

        //Weapon Switching
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            setActiveWeapon(PullGun);
            ActiveWep = weaponArray[PullGun];
            Debug.Log("Active weapon is now a " + ActiveWep);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            setActiveWeapon(PushGun);
            ActiveWep = weaponArray[PushGun];
            Debug.Log("Active weapon is now a " + ActiveWep);
        }
        //else if (Input.GetKeyDown(KeyCode.Alpha3)) {
        //    ActiveWep = weaponArray[2];
        //    Debug.Log("Active weapon is now a " + ActiveWep);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4)) {
        //    ActiveWep = weaponArray[3];
        //    Debug.Log("Active weapon is now a " + ActiveWep);
        //}

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
            //Decrease ammo count
            ActiveWep.Ammo--;

            //reset fire counter
            timeSinceFired = 0f;

            //Raycast out to find a hit, then spawn a bullet object to mark the location
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, ActiveWep.MaxRange)) {
                //make sure we hit something that can take damage
                if (hitInfo.collider.gameObject.GetComponent<StatisticsManager>() != null) {
                    //deal damage to the object we collided with equal to the current weapon's bullet damage
                    hitInfo.collider.gameObject.GetComponent<StatisticsManager>().DealDamageToObject(ActiveWep.BulletDamage);
                    Debug.Log("Ray hit " + hitInfo.collider.tag);
                }

                Vector3 hitPoint = hitInfo.point;
                Instantiate(bulletPrefab, hitPoint, Quaternion.identity);
            }
        }
    }



    //[UnityEditor.CustomEditor(typeof(WeaponManager))]
    //public class InspectorCustomizer : UnityEditor.Editor {
    //    public void ShowArrayProperty(UnityEditor.SerializedProperty list) {
    //        UnityEditor.EditorGUI.indentLevel += 1;
    //        UnityEditor.EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(1), new UnityEngine.GUIContent("Pistol"));
    //        UnityEditor.EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(2), new UnityEngine.GUIContent("Rifle"));
    //        UnityEditor.EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(3), new UnityEngine.GUIContent("Shotgun"));
    //        UnityEditor.EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(4), new UnityEngine.GUIContent("Knife"));

    //        UnityEditor.EditorGUI.indentLevel -= 1;
    //    }

    //    public override void OnInspectorGUI() {
    //        ShowArrayProperty(serializedObject.FindProperty("Weapon Prefab Array"));
    //    }
    //}
}