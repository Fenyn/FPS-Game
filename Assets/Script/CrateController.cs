using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

    public static GameObject WalkedOverObject;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter entered on crate");
        if (other.tag == "Player") {
            Debug.Log("Setting WalkedOverObject to" + this.gameObject);
            WalkedOverObject = this.gameObject;
            Debug.Log("WalkedOverObject = " + WalkedOverObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("WalkedOverObject cleared");
        WalkedOverObject = null;
        Debug.Log("WalkedOverObject = " + WalkedOverObject);
    }
}
