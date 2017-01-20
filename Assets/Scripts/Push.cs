using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//Vector3 point = ray.origin + (ray.direction * distance);
		//Debug.Log("World point " + point);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			GameObject.FindObjectOfType<Player>();
		}
	}
}
