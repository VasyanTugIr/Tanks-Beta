﻿using UnityEngine;
using System.Collections;

public class RearWheelDrive : MonoBehaviour {

	private WheelCollider[] wheelsColliders;
	public Transform[] wheels;

	public float maxAngle = 30;
	public float maxTorque = 300;
	public float velocity ;
	public Transform wheelShape;
	public Rigidbody body;
	private float moveTortuge;

	// here we find all the WheelColliders down in the hierarchy
	public void Start()
	{
		wheelsColliders = GetComponentsInChildren<WheelCollider>();
		for (int i = 0; i < wheelsColliders.Length; ++i) 
		{
			var wheel = wheelsColliders [i];

			// create wheel shapes only when needed
			if (wheelShape != null)
			{
				var ws = GameObject.Instantiate (wheelShape);
				ws.transform.parent = wheel.transform;
			}
		}
	}

	// this is a really simple approach to updating wheels
	// here we simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero
	// this helps us to figure our which wheels are front ones and which are rear
	public void Update()
	{
		float angle = maxAngle * Input.GetAxis("Horizontal");
		velocity = body.velocity.magnitude;
		float torque = maxTorque * Input.GetAxis("Vertical");
		if (torque != 0)
		{
			moveTortuge = torque;
		}
		foreach (WheelCollider wheel in wheelsColliders)
		{
			// a simple car where front wheels steer while rear ones drive
			if (wheel.transform.localPosition.z > 0)
				wheel.steerAngle = angle;

			if (wheel.transform.localPosition.z < 0)
				wheel.motorTorque = torque;

			// update visual wheels if any
			if (wheelShape) 
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose (out p, out q);
							
				// assume that the only child of the wheelcollider is the wheel shape
				Transform shapeTransform = wheel.transform.GetChild (0);
				shapeTransform.position = p;
				shapeTransform.rotation =new Quaternion(shapeTransform.rotation.x,q.y,q.z,q.w) ;
				shapeTransform.localScale = new Vector3(1, 1, 1);
			}

		}
		if (wheels == null)
        {
			return;
        }
		if (velocity > 0.5f)
		{
			foreach (Transform wheel in wheels)
			{
				wheel.Rotate(new Vector3(moveTortuge, 0, 0));
			}
		}
	}
}
