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
            FaceTarget();
        }
    }
	
	public void MoveToPoint(Vector3 point)
    {
        navAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        navAgent.stoppingDistance = newTarget.radius * 0.8f;
        navAgent.updateRotation = false;
        target = newTarget.interactionWillOnlyHappenHere;
    }

    public void StopFollowingTarget()
    {
        navAgent.stoppingDistance = 0.0f;
        navAgent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }
}
