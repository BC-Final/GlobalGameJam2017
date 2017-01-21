using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour {
	[SerializeField]
	private float _health = 100.0f;

	public Transform ProbePosition;
	private Rigidbody _rigidbody;

	private float _fadeTime = 1.5f;
	private float _timer;

	private bool _fade;
	private float _startHeight;

	private void Start () {
		ProbePosition = transform.parent.transform;
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update () {
		if (_fade && _health > 0.0f) {
			_timer += Time.deltaTime;
			if (_timer > _fadeTime) {
				_timer = _fadeTime;
				_fade = false;
			}

			float perc = _timer / _fadeTime;
			float currentHeight = _startHeight * (1.0f - perc);

			Vector3 pos = _rigidbody.position;
			//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
			pos.y = Mathf.Sin(Time.time * 10) * currentHeight;
			_rigidbody.position = pos;

			//transform.position = Vector3.Lerp(_startHeight, 0.0f, perc);
		}
	}

	public void StopFade () {
		_fade = false;
	}

	public void FadeOut () {
		_fade = true;
		_timer = 0.0f;
		_startHeight = _rigidbody.position.y;
	}

	public void Damage (float pDamage) {
		_health -= pDamage;

		if (_health <= 0.0f) {
			_rigidbody.isKinematic = false;
			_rigidbody.useGravity = true;

			if (_rigidbody.velocity.y > 0.0f) {
				_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, -_rigidbody.velocity.y, _rigidbody.velocity.z);
			}
		}
	}

	public void SetPosition (float pY) {
		if (_health > 0.0f) {
			_rigidbody.MovePosition(new Vector3(_rigidbody.position.x, pY, _rigidbody.position.z));
		}
	}
}
