using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingOutlineManager : MonoBehaviour {

    public GameObject currentlyHighlightedBuilding;
    public float highlightDistance = 10f;

    // Update is called once per frame
    void Update() {
        //Raycast out to find a hit, then spawn a bullet object to mark the location
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;


        if (Physics.Raycast(ray, out hitInfo)) {
            //de-highlight our currently highlighted building if we hit an object other than it
            if ((hitInfo.collider.gameObject != currentlyHighlightedBuilding || hitInfo.distance > highlightDistance) && currentlyHighlightedBuilding != null) {
                currentlyHighlightedBuilding.GetComponent<EnterableBuilding>().HighlightBuilding(false);
                currentlyHighlightedBuilding = null;
            }

            //if we get a hit, check that it is a building within our highlight range
            //then highlight it
            if (hitInfo.collider.tag.Equals("Enterable Building") && hitInfo.distance <= highlightDistance) {
                currentlyHighlightedBuilding = hitInfo.collider.gameObject;
                currentlyHighlightedBuilding.GetComponent<EnterableBuilding>().HighlightBuilding(true);
            }
        }
        //de-highlight our highlighted building if we hit nothing
        //(like when we look at the sky)
        else if (currentlyHighlightedBuilding != null) {
            currentlyHighlightedBuilding.GetComponent<EnterableBuilding>().HighlightBuilding(false);
            currentlyHighlightedBuilding = null;
        }
    }
}
