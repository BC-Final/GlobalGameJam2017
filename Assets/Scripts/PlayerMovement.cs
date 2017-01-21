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

	private Vector3 movement;
	//public float tilt;
	public float tilt;
	//public Boundary boundary;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal") * speed;
		float moveVertical = Input.GetAxis("Vertical") * speed;

		Vector3 targetSpeed = new Vector3(moveHorizontal, 0.0f, moveVertical);
		movement = Vector3.Lerp(movement, targetSpeed, Time.deltaTime * grip);
		movement = Vector3.ClampMagnitude(movement , maxSpeed);

		GetComponent<Rigidbody>().velocity = movement;

		//GetComponent<Rigidbody>().position = new Vector3
		//(
		//	Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
		//	0.0f,
		//	Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		//);
		//GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}


