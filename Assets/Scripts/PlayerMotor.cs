using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {
    NavMeshAgent navAgent;
    Transform target;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
	}

    private void Update()
    {
        if (target != null)
        {
            navAgent.SetDestination(target.position);
        }
    }
	
	public void MoveToPoint(Vector3 point)
    {
        navAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        target = null;
    }
}
