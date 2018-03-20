using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatManager : MonoBehaviour {

    public GameObject ammoCounterUIObject;
    public GameObject healthCounterUIObject;
    public WeaponManager wepManager;

    int ammo;
    int currentHealth = 100;

    // Use this for initialization
    void Start() {
        updateAmmo();
        updateHealth();
    }

    // Update is called once per frame
    void Update() {
        updateAmmo();
        updateHealth();
    }

    void updateAmmo() {
        ammo = wepManager.ActiveWep.Ammo;
        ammoCounterUIObject.GetComponent<Text>().text = ammo.ToString();
    }

    void updateHealth() {
        StatisticsManager statMan = GetComponent<StatisticsManager>();
        //currentHealth = statMan.CurrentHealth;
        healthCounterUIObject.GetComponent<Text>().text = currentHealth.ToString();
    }
    
}
