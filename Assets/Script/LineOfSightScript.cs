using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightScript : MonoBehaviour {

    NonPlayerController parentController;

    void Start() {
        parentController = GetComponentInParent<NonPlayerController>();
    }

    //pass collision trigger on to parent
    private void OnTriggerStay(Collider other) {
        if (parentController.isPassive) {
            parentController.CheckVisibility(other);
        }

    }
}
