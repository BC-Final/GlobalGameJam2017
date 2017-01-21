using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeatTestScript : MonoBehaviour {
	private float _time;
	private float _timer;

	void Start () {
		_time = 60.0f / (130f * 1f);
	}

	private bool pressed = false;

	void Update () {
		_timer += Time.deltaTime;

		if (_timer > _time) {
			_timer -= _time;

			if (Input.GetMouseButton(0) || pressed) {
				GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				sphere.AddComponent<Rigidbody>().AddForce(300.0f, 100.0f, 0.0f);
				sphere.transform.position = transform.position;
				pressed = false;
			}
		} else {
			if (Input.GetMouseButton(0)) {
				pressed = true;
			}
		}
	}
}
