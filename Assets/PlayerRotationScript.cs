using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationScript : MonoBehaviour
{
	[SerializeField]
	string rightStickHorizontal;
	[SerializeField]
	string rightStickVertical;

	Rigidbody _rigidBody;
	private float angle = 0;
	// Use this for initialization
	void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float x = Input.GetAxis(rightStickHorizontal);
		float y = Input.GetAxis(rightStickVertical);
		

		if (x != 0.0f || y != 0.0f)
		{
			angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
		}

		transform.rotation = Quaternion.Euler(0, angle + 90, 0);
	}
}