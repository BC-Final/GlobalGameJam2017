using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveShooting : PlayerAbility {

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

	protected void Update () {
		base.Update();
		_timer += Time.deltaTime;

		if (_timer > _time && ammo > 0) {
			_timer -= _time;

			if (Input.GetButton(fireButton) || _pressed) {
				Shoot();
				_pressed = false;
			}
		} else if(ammo > 0){
			if (Input.GetButton(fireButton)) {
				_pressed = true;
			}
		}
	}

	public override void Shoot()
	{
		base.Shoot();
		GameObject.Instantiate(_projectilePrefab, transform.position + _shotOffset, transform.rotation);
	}
}
