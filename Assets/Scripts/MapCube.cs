using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour {
	public Transform ProbePosition;
	public Rigidbody RigidBody;

	private float _fadeTime = 1.5f;
	private float _timer;

	private bool _fade;
	private float _startHeight;

	private void Start () {
		ProbePosition = transform.parent.transform;
		RigidBody = GetComponent<Rigidbody>();
	}

	private void Update () {
		if (_fade) {
			_timer += Time.deltaTime;
			if (_timer > _fadeTime) {
				_timer = _fadeTime;
				_fade = false;
			}

			float perc = _timer / _fadeTime;
			float currentHeight = _startHeight * (1.0f - perc);

			Vector3 pos = RigidBody.position;
			//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
			pos.y = Mathf.Sin(Time.time * 10) * currentHeight;
			RigidBody.position = pos;

			//transform.position = Vector3.Lerp(_startHeight, 0.0f, perc);
		}
	}

	public void StopFade () {
		_fade = false;
	}

	public void FadeOut () {
		_fade = true;
		_timer = 0.0f;
		_startHeight = RigidBody.position.y;
	}
}
