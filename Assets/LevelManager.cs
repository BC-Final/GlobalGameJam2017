using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour {
	private static LevelManager _instance;

	public static LevelManager Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<LevelManager>();
			}

			return _instance;
		}
	}

	public List<MapCube> Cubes = new List<MapCube>();
	public bool Building = false;

	[SerializeField]
	private float _minMoveUpTime;

	[SerializeField]
	private float _maxMoveUpTime;

	[SerializeField]
	public GameObject RespawnWave;

	private void Start () {
		Cubes.AddRange(GetComponentsInChildren<MapCube>());
		Building = true;
		Cubes.ForEach(x => x.ProbePosition.position = new Vector3(x.ProbePosition.position.x, -5.0f, x.ProbePosition.position.z));
		Cubes.ForEach(x => x.ProbePosition.DOMoveY(0.0f, Random.Range(_minMoveUpTime, _maxMoveUpTime)).OnComplete(() => Callback()));
	}

	private int counter = 0;
	private void Callback () {
		counter++;

		if (counter == Cubes.Count) {
			Building = false;
		}
	}
}
