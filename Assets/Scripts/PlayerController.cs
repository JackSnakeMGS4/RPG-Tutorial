using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;

            if(Physics.Raycast(ray, out rh, 100, movementMask))
            {
                motor.MoveToPoint(rh.point);

                //stop focusing on GOs
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;

            if (Physics.Raycast(ray, out rh, 100))
            {
                //check if ray hit interactable
            }
        }
    }
}
