using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonPlayerController : MonoBehaviour {

    public Transform goal;
    NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        goal = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        agent.destination = goal.position;
    }
}
