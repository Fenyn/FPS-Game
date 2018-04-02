using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterableBuilding : MonoBehaviour {

    bool isEnterable;

    private void Start() {
        gameObject.layer = 0;
    }

    public void HighlightBuilding(bool highlighted) {
        if (highlighted) {
            ChangeLayersRecursively(transform, "EnterableBuilding");
        }
        else {
            ChangeLayersRecursively(transform, "Default");
        }
    }

    public static void ChangeLayersRecursively(Transform trans, string name) {
        if(LayerMask.LayerToName(trans.gameObject.layer) != "IgnoreLayerChange") {
            trans.gameObject.layer = LayerMask.NameToLayer(name);
            foreach (Transform child in trans) {
                ChangeLayersRecursively(child, name);
            }
        }        
    }
}
