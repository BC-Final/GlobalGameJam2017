using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDrop : PlayerAbility
{
	[SerializeField]
	private GameObject _projectilePrefab;
	[SerializeField]
	private GameObject _projectileSpawnPrefab;

	[SerializeField]
	private float _bpm;

	[SerializeField]
	private float _speed;
	[SerializeField]
	private float _lifeTime;


	private float _time;
	private float _timer;

	private bool _pressed = false;

	private void Start()
	{
		_time = 60.0f / _bpm;
		_timer = 0.0f;
	}

	protected void Update()
	{
		base.Update();
		_timer += Time.deltaTime;

		if (_timer > _time && ammo > 0)
		{
			_timer -= _time;

			if (Input.GetButton(fireButton) || _pressed)
			{
				Shoot();
				_pressed = false;
			}
		}
		else if (ammo > 0)
		{
			if (Input.GetButton(fireButton))
			{
				_pressed = true;
			}
		}
	}

	public override void Shoot()
	{
		FMODUnity.RuntimeManager.PlayOneShot("event:/projectile");
		base.Shoot();
		GameObject go = GameObject.Instantiate(_projectilePrefab, transform.position + _shotOffset, transform.rotation);
		BaseProjectile bullet = go.GetComponent<BaseProjectile>();
		bullet._lifeTime = _lifeTime;
		bullet._speed = _speed;
		bullet._basePrefab = _projectileSpawnPrefab;
	}
}
