using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonPlayerController : MonoBehaviour {

    public Transform goal;
    NavMeshAgent agent;

    public bool isPassive = true;

    // Use this for initialization
    void Start () {
        goal = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if we have line of sight and aggression towards player
        if (!isPassive) {
            //enable the chasing behavior
            agent.isStopped = false;
            agent.destination = goal.position;

            //check if we lost line of sight and passify agent if so
            if (Physics.Linecast(transform.position, goal.position)) {
                Debug.Log("Line of sight lost");
                isPassive = true;
                agent.isStopped = true;
            }
        }
        else {
        }
    }

    public void CheckVisibility(Collider target) {
        //check if we have line of sight to target
        if (Physics.Linecast(transform.position, target.transform.position)) {
        }
        else {
            Debug.Log("Activating aggression");
            isPassive = false;
        }
    }
}
