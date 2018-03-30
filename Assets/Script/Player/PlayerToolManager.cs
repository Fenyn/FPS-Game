using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolManager : MonoBehaviour {

    public int CurrentNumberOfTools;

    public PlayerToolManager instance;
    public Tool[] toolArray;
    public Tool activeTool;
    public PhysicsGun physGun;
    RaycastHit hit;

    GameObject[] toolPrefabArray;
    public CarryManager carryManager;

    // Use this for initialization
    void Start() {
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

        carryManager = GameObject.Find("CarryManager").GetComponent<CarryManager>();

        InitializeTools();
    }

    private void InitializeTools() {
        physGun = new PhysicsGun {
            spotToCarry = carryManager.spotToCarry
        };

        toolArray = new Tool[CurrentNumberOfTools];

        toolPrefabArray = new GameObject[CurrentNumberOfTools];


        toolArray[0] = physGun;
        SetActiveWeapon(0);

        ActiveTool = toolArray[0];

        Debug.Log("Active tool is now a " + ActiveTool);
    }

    //Takes a number and sets the weapon prefab associated with that value to be visible and all others to be invisible
    //a.k.a. weapon switching
    void SetActiveWeapon(int wepNum) {
        for (int i = 0; i < toolPrefabArray.Length; i++) {
            if (toolPrefabArray[i] != null) {
                if (i == wepNum) {
                    toolPrefabArray[i].SetActive(true);
                }
                else { toolPrefabArray[i].SetActive(false); }
            }
        }
    }


    public Tool ActiveTool {
        get {
            return activeTool;
        }

        set {
            activeTool = value;
        }
    }

    public void PerformPrimaryAction() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, ActiveTool.ToolDistance) && hit.transform.tag.Equals("item")) {
            carryManager.PickUpItem(hit);
        }
    }

    public void PerformSecondaryAction() {
        ActiveTool.ActivateSecondary();
    }
}
