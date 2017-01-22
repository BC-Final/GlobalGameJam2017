using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveShooting : PlayerAbility {

	[SerializeField]
	private GameObject _projectilePrefab;
	[SerializeField]
	public float force;
	[SerializeField]
	public float speed;

	[SerializeField]
	private float _bpm;

	FMOD.Studio.EventInstance projectileInst;

	private float _time;
	private float _timer;

	//private bool _pressed = false;

	private void Start () {
		_time = 60.0f / _bpm;
		_timer = 0.0f;
	}

	bool holding;

	protected void Update () {
		base.Update();
		_timer += Time.deltaTime;

		if (_timer > _time && ammo > 0) {
			_timer -= _time;

			if (Input.GetButton(fireButton)/* || _pressed*/) {
				GetComponentInChildren<Animator>().SetBool("Shooting", true);

				if (!holding)
					MusicManager.Instance.StartShot();

				holding = true;
				Shoot();
				//_pressed = false;
			}
		} else if(ammo > 0){
			if (Input.GetButton(fireButton)) {
				//_pressed = true;
			}
		}

		if (Input.GetButtonUp(fireButton) && holding) {
			holding = false;
			GetComponentInChildren<Animator>().SetBool("Shooting", false);
			MusicManager.Instance.StopShot();
		}
	}

	public override void Shoot()
	{
		base.Shoot();
		GameObject go = GameObject.Instantiate(_projectilePrefab, transform.position + transform.TransformDirection(_shotOffset), transform.rotation);
		Projectile bullet = go.GetComponent<Projectile>();
		bullet.owner = GetComponentInParent<Player>();
		bullet._force = force;
		bullet._speed = speed;
	}
}
/*
using UnityEngine;
using System.Collections;


public class fmodScript : MonoBehaviour {




	[FMODUnity.EventRef]                        // make a public fmod event reference
	FMOD.Studio.EventInstance music;     // call an event
	FMOD.Studio.ParameterInstance quake;       // call a parameter
	FMOD.Studio.ParameterInstance bomb;       // call a parameter
	FMOD.Studio.EventInstance projectile;

	void Start () {


		music = FMODUnity.RuntimeManager.CreateInstance("event:/music");  // define that <input name> is specified fmod event
		music.getParameter("death", out death);
		music.getParameter("shots", out shots);
		music.getParameter("drums", out drums);

		music.start();

		quake = FMODUnity.RuntimeManager.CreateInstance("event:/quake");
		bomb = FMODUnity.RuntimeManager.CreateInstance("event:/bomb");
		projectile = FMODUnity.RuntimeManager.CreateInstance("event:/projectile");

	}

	// void idunnowhatsgoingonhere {

		if death then:
		death.setValue (1f);

		while shootkey pressed
			shots.setValue (1f);

		if you want drus to fade out:
			drums.setValue (0f);

		if you want drus to fade in:
			drums.setValue (1f);


	} */
