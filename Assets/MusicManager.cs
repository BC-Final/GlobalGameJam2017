using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	private static MusicManager _instance;

	public static MusicManager Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<MusicManager>();
			}

			return _instance;
		}
	}

	[FMODUnity.EventRef]
	FMOD.Studio.EventInstance _musicEvent;

	FMOD.Studio.ParameterInstance _shotParam;
	FMOD.Studio.ParameterInstance _deathParam;

	public int _shooters;

	private void Start () {
		_musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/music");

		_musicEvent.getParameter("shots", out _shotParam);
		_musicEvent.getParameter("death", out _deathParam);

		_musicEvent.start();
	}

	public void StartDeath () {
		_deathParam.setValue(1.0f);
	}

	public void StopDeath () {
		_deathParam.setValue(0.0f);
	}

	public void StartShot () {
		_shooters++;
		_shotParam.setValue(1.0f);
		Debug.Log("Start");
	}

	public void StopShot () {
		_shooters--;
		//Restart sound delay 3.69 turn down to zero
		if (_shooters == 0) {
			Debug.Log("Stop");
			_shotParam.setValue(0.0f);
		}
	}
}