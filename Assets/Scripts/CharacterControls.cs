using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharacterControls : MonoBehaviour
{

	[SerializeField]
	public string LeftStickHorizontal;
	[SerializeField]
	public string LeftStickVertical;

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	[Range(0.0f, 100.0f)]
	public float airControlPercent;
	public float airControlThreshold;
	[Range(0.0f, 1.0f)]
	public float airControlLowCap;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	[SerializeField]
	private bool grounded = false;



	void Awake()
	{
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
	}

	void FixedUpdate()
	{
		//Ground Control
		if (grounded)
		{
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis(LeftStickHorizontal), 0, Input.GetAxis(LeftStickVertical));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (canJump && Input.GetButton("Jump"))
			{
				GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}
		else
		{
			////Air Control
			//
			//// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis(LeftStickHorizontal), 0, Input.GetAxis(LeftStickVertical));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;
			//
			//// Apply a force that attempts to reach our target velocity
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			//velocityChange.x = Mathf.Clamp(velocityChange.x, -airControlPercent * airControlPercent / 100 * Mathf.Clamp(velocity.magnitude / airControlThreshold, 0, 1), airControlPercent * airControlPercent / 100 * Mathf.Clamp(velocity.magnitude / airControlThreshold, 0, 1));
			//velocityChange.z = Mathf.Clamp(velocityChange.z, -airControlPercent * airControlPercent / 100 * Mathf.Clamp(velocity.magnitude / airControlThreshold, 0, 1), airControlPercent * airControlPercent / 100 * Mathf.Clamp(velocity.magnitude / airControlThreshold, 0, 1));
			velocityChange.x = Mathf.Clamp(velocityChange.x * (Mathf.Clamp(1 - Mathf.Clamp(velocity.magnitude / airControlThreshold, 0, 1), airControlLowCap, 1)), -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z * (Mathf.Clamp(1 - Mathf.Clamp(velocity.magnitude / airControlThreshold, 0, 1), airControlLowCap, 1)), -maxVelocityChange, maxVelocityChange);
			if(velocity.y > 5)
			{
				velocityChange.y = Mathf.Clamp(velocityChange.y ,-maxVelocityChange, maxVelocityChange);
			}else{
				velocityChange.y = 0;
			}
			GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

		}

		// We apply gravity manually for more tuning control
		GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

		grounded = false;
	}

	void OnCollisionStay()
	{
		grounded = true;
	}

	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}