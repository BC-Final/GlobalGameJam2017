using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationTesting : MonoBehaviour {
	void Update () {
		transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Horizontal") * 5f);
	}
}
