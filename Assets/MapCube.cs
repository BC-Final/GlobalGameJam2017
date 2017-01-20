using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour {
	public Transform ProbePosition;

	private void Start () {
		ProbePosition = GetComponentInChildren<Transform>();
	}
}
