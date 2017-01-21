using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveShooting : MonoBehaviour {
	[SerializeField]
	private GameObject _projectilePrefab;

	[SerializeField]
	private float _bpm;

	private float _time;
	private float _timer;

	private bool _pressed = false;

	private void Start () {
		_time = 60.0f / _bpm;
		_timer = 0.0f;
	}

	private void Update () {
		_timer += Time.deltaTime;

		if (_timer > _time) {
			_timer -= _time;

			if (Input.GetMouseButton(0) || _pressed) {
				GameObject.Instantiate(_projectilePrefab, transform.position, transform.rotation);
				_pressed = false;
			}
		} else {
			if (Input.GetMouseButton(0)) {
				_pressed = true;
			}
		}
	}
}
