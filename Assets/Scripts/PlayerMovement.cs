using UnityEngine;
using System.Collections;

[System.Serializable]
//public class Boundary
//{
//	public float xMin, xMax, zMin, zMax;
//}

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	public float maxSpeed;
	public float grip;
	public float xzInertia;

	private Vector3 movement;
	//public float tilt;
	public float tilt;
	//public Boundary boundary;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal") * speed;
		float moveVertical = Input.GetAxis("Vertical") * speed;

		Vector3 targetSpeed = new Vector3(moveHorizontal, 0, moveVertical);

		Rigidbody rb = GetComponent<Rigidbody>();
		float y = rb.velocity.y;
		

		movement = Vector3.Lerp(movement, targetSpeed, Time.deltaTime * grip);

		//movement = Vector3.ClampMagnitude(movement , maxSpeed);

		//movement.y = y;

		GetComponent<Rigidbody>().velocity += movement;

		//inertia
		float newX = GetComponent<Rigidbody>().velocity.x;
		float newZ = GetComponent<Rigidbody>().velocity.z;

		Debug.Log(GetComponent<Rigidbody>().velocity);
		if (newX > maxSpeed || newX < -maxSpeed)
		{
			newX *= 0.9f;
		}
		float newY = GetComponent<Rigidbody>().velocity.y * 1f;
		if (newZ > maxSpeed || newZ < -maxSpeed)
		{
			newZ *= 0.9f;
		}

		GetComponent<Rigidbody>().velocity = new Vector3(newX, newY, newZ);

		//GetComponent<Rigidbody>().position = new Vector3
		//(
		//	Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
		//	0.0f,
		//	Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		//);
		//GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}


