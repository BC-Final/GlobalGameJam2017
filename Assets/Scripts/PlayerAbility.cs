using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour {

	[SerializeField]
	protected string fireButton;

	[SerializeField]
	public Vector3 _shotOffset;

	public int ammo;
	public int maxAmmo = 1;

	public float cooldown = 2f;
	private float _cooldownTimer;

	[SerializeField]
	private SkillIcon _icon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
		_cooldownTimer += Time.deltaTime;
		_icon.Step(_cooldownTimer, cooldown, ammo, maxAmmo);
		if(_cooldownTimer > cooldown)
		{
			AddAmmo();
			_cooldownTimer -= cooldown;
		}
	}

	public virtual void Shoot()
	{
		ammo--;
		OnShoot();
	}

	private void AddAmmo()
	{
		if(ammo < maxAmmo)
		{
			ammo++;
			OnAmmoAdd();
		}
	}

	private void OnAmmoAdd()
	{
		//do flashy visual stuff
	}

	private void OnShoot()
	{
		//do other flashy stuff
	}
}
