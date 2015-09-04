using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	bool onGround;
	public float Speed = 5;
	public float RunSpeed = 3;
	public float JumpHeight = 150;
	public float MaxVelocityChange = 4;


	void FixedUpdate()
	{
		GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);

		var targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = Camera.main.transform.TransformDirection(targetVelocity);
		targetVelocity *= Speed;

		var v = GetComponent<Rigidbody>().velocity;
		var velocityChange = (targetVelocity-v);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocityChange, MaxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocityChange, MaxVelocityChange);
		velocityChange.y = 0;

        GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
		//if(Input.GetButtonDown("Jump") && onGround)
		//{
		//	GetComponent<Rigidbody>().AddForce(transform.up * JumpHeight);
		//}

		onGround = false;
	}

	void OnCollisionStay(Collision col)
	{
		if(col.transform.tag != "Not Ground")
		{
			onGround = true;
		}
	}
}
