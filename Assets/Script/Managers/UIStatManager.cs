using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatManager : MonoBehaviour {

    public GameObject ammoCounterUIObject;
    public GameObject healthCounterUIObject;

    public WeaponManager wepManager;
    public StatisticsManager statMan;
    int ammo = 0;
    int maxAmmo = 0;
    int currentHealth = 100;

    // Use this for initialization
    void Start() {
        statMan = transform.root.GetComponent<StatisticsManager>();
        wepManager = transform.root.GetComponent<WeaponManager>();

        if (wepManager != null) {
            ammo = wepManager.ActiveWep.Ammo;
            maxAmmo = wepManager.ActiveWep.MaxAmmo;
        }

        updateAmmo();
        updateHealth();
    }

    // Update is called once per frame
    void Update() {
        updateAmmo();
        updateHealth();
    }

    void updateAmmo() {
        ammoCounterUIObject.GetComponent<Text>().text = ammo.ToString() + " / " + maxAmmo.ToString();
    }

    void updateHealth() {
        //currentHealth = statMan.CurrentHealth;
        healthCounterUIObject.GetComponent<Text>().text = currentHealth.ToString();
    }

}
