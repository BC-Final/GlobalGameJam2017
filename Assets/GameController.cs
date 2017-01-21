﻿using System.Collections;
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

	[SerializeField]
	private float _deadHeight = -2.0f;

	private bool _starting;
	private float _releaseTime;

	private int _playerOnePoints;
	private int _playerTwoPoints;

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
		} else {
			if (_playerOneRef.position.y <= _deadHeight || _playerTwoRef.position.y <= _deadHeight) {
				if (_playerOneRef.position.y > _playerTwoRef.position.y) {
					_playerOnePoints++;
				} else {
					_playerTwoPoints++;
				}

				RestartLevel();
			}
		}
	}

	public void RestartLevel () {
		_starting = true;
		_playerOneRef.position = _playerOneSpawnPoint.position;
		_playerOneRef.rotation = _playerOneSpawnPoint.rotation;
		_playerTwoRef.position = _playerTwoSpawnPoint.position;
		_playerTwoRef.rotation = _playerTwoSpawnPoint.rotation;

		_playerOneRef.GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
		_playerTwoRef.GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
		//TODO Restrict players movement

		//SUGGESTION Maybe destroy the map by exploding it??
		UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("scn_map");
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("scn_map", UnityEngine.SceneManagement.LoadSceneMode.Additive);

		_releaseTime = Time.time + _respawnWaitTime;
	}
}
