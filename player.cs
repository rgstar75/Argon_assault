using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class player : MonoBehaviour {
	[Header("speed")]
	
	[Tooltip("ms^-1")][SerializeField] float xspeedmultiplier = 150f;
	[Tooltip("ms^-1")] [SerializeField] float yspeedmultiplier = 150f;
	
	[Header("clamp")]

	[Tooltip("m")] [SerializeField] float xclampmeasurement = 180f;
	[Tooltip("m")] [SerializeField] float yclampmeasurement = 70f;
	
	[Header("pitch")]
	
	[SerializeField] float positionpitchfactor = -0.2f;
	[SerializeField] float controlpitchfactor = 5f;
	
	[Header("yaw,roll")]
	
	[SerializeField] float yawfactor = 0.31f;
	[SerializeField] float rollfactor = 15f;

	[SerializeField] GameObject[] guns;
	
	float xmovement, ymovement;
	bool controlsenabled =true;
	
	void Update ()
	{
		if (controlsenabled)
		{
			positionmovement();
			rotationprocess();
			activateguns();
		}
		
	}
	public void DEATHFUNCTION()
	{
		controlsenabled = false;
	}

	private void rotationprocess()
	{
		float pitchduetoposition = transform.localPosition.y * positionpitchfactor;
		float pitchduetocontrol = ymovement * controlpitchfactor;
		float pitch = pitchduetocontrol + pitchduetoposition;
		float yaw = transform.localPosition.x*yawfactor;
		float roll = xmovement * rollfactor;
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void positionmovement()
	{
		 xmovement = CrossPlatformInputManager.GetAxis("Horizontal");
		 ymovement = CrossPlatformInputManager.GetAxis("Vertical");

		float xMovementInthisFrame = xmovement * xspeedmultiplier * Time.deltaTime;
		float yMovementInthisFrame = ymovement * yspeedmultiplier * Time.deltaTime;

		float xcoordinateMov = -xMovementInthisFrame + transform.localPosition.x;
		float ycoordinateMov = -yMovementInthisFrame + transform.localPosition.y;

		float movementrangeX = Mathf.Clamp(xcoordinateMov, -xclampmeasurement, xclampmeasurement);
		float movementrangeY = Mathf.Clamp(ycoordinateMov, -yclampmeasurement, yclampmeasurement);

		transform.localPosition = new Vector3(movementrangeX, transform.localPosition.y, transform.localPosition.z);
		transform.localPosition = new Vector3(transform.localPosition.x, movementrangeY, transform.localPosition.z);
	}
	private void activateguns()
	{
		if (CrossPlatformInputManager.GetButton("Fire"))
		{
			foreach(GameObject gun in guns)
			{
				var emissionactivation = gun.GetComponent<ParticleSystem>().emission;
				emissionactivation.enabled = true;
			}
		}
		else
		{
			foreach(GameObject gun in guns)
			{
				var emissionactivation = gun.GetComponent<ParticleSystem>().emission;
				emissionactivation.enabled = false;
			}
		}
	}
}
