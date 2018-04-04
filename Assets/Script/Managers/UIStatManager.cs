using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatManager : MonoBehaviour {

    public GameObject ammoCounterUIObject;
    public GameObject healthCounterUIObject;
    public GameObject appleCounterUIObject;
    public GameObject meatCounterUIObject;
    public GameObject breadCounterUIObject;
    public GameObject woodCounterUIObject;

    public StatisticsManager statManager;
    public WeaponManager wepManager;
    public CollectableManager collectableManager;
    UIStatManager instance;

    int ammo = 0;
    int maxAmmo = 0;
    int currentHealth = 100;

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
    }

        // Use this for initialization
        void Start() {
        statManager = transform.root.GetComponent<StatisticsManager>();

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
        updateCounters();
    }

    void updateAmmo() {
        ammoCounterUIObject.GetComponent<Text>().text = wepManager.ActiveWep.Ammo.ToString() + " / " + wepManager.ActiveWep.MaxAmmo.ToString();
    }

    void updateHealth() {
        //currentHealth = statMan.CurrentHealth;
        healthCounterUIObject.GetComponent<Text>().text = currentHealth.ToString();
    }

    void updateCounters() {
        appleCounterUIObject.GetComponent<Text>().text = "Apples: " + collectableManager.NumOfApples.ToString();
        breadCounterUIObject.GetComponent<Text>().text = "Bread: " + collectableManager.NumOfBreadLoves.ToString();
        meatCounterUIObject.GetComponent<Text>().text = "Meat: " + collectableManager.NumOfMeat.ToString();
        woodCounterUIObject.GetComponent<Text>().text = "Wood: " + collectableManager.NumOfWood.ToString();
    }

}
