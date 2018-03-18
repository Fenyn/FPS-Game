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
       
	}
}
