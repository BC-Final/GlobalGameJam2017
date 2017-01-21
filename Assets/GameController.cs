using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[SerializeField]
	private GameObject _playerOnePrefab;
	private Transform _playerOneRef;

	[SerializeField]
	private GameObject _playerTwoPrefab;
	private Transform _playerTwoRef;

	[SerializeField]
	private Transform _playerOneSpawnPoint;

	[SerializeField]
	private Transform _playerTwoSpawnPoint;

	[SerializeField]
	private float _initialWaitTime;

	[SerializeField]
	private float _respawnWaitTime;

	private bool _starting;
	private float _releaseTime;

	private void Start () {
		//TODO Start the music
		_releaseTime = Time.time + _initialWaitTime;
		_starting = true;

		_playerOneRef = GameObject.Instantiate(_playerOnePrefab, _playerOneSpawnPoint.position, _playerOneSpawnPoint.rotation).transform;
		_playerTwoRef = GameObject.Instantiate(_playerTwoPrefab, _playerTwoSpawnPoint.position, _playerTwoSpawnPoint.rotation).transform;
		//TODO Players should not be able to move when spawned
	}

	private void Update () {
		if (_starting && _releaseTime - Time.time <= 0.0f) {
			_starting = false;
			//TODO Release Player Controllers
		}
	}

	public void RestartLevel () {
		_starting = true;
		_playerOneRef.position = _playerOneSpawnPoint.position;
		_playerOneRef.rotation = _playerOneSpawnPoint.rotation;
		_playerTwoRef.position = _playerTwoSpawnPoint.position;
		_playerTwoRef.rotation = _playerTwoSpawnPoint.rotation;
		//TODO Restrict players movement

		UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("scn_map");
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("scn_map", UnityEngine.SceneManagement.LoadSceneMode.Additive);
		//TODO Unload and load the map scene
		//TODO Release players after given time
	}
}
