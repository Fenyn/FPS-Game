using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonPlayerController : MonoBehaviour {

    public Transform goal;
    NavMeshAgent agent;

    public bool isPassive = false;

    // Use this for initialization
    void Start () {
        goal = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isPassive) {
            agent.destination = goal.position;
        }
    }
}
