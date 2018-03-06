using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformsAttack : MonoBehaviour {

    public float timeBetweenShots = 0.5f;
    public float gunRange = 100f;

    float cooldownRemaining = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cooldownRemaining -= Time.deltaTime;
        if (Input.GetMouseButton(0) && cooldownRemaining <= 0) {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, gunRange)) {
                Vector3 hitPoint = hitInfo.point;
            }
        }
	}
}
