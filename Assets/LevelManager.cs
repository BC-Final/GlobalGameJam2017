using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour {
	public static List<MapCube> Cubes = new List<MapCube>();
	public static bool Building = false;

	[SerializeField]
	private float _minMoveUpTime;

	[SerializeField]
	private float _maxMoveUpTime;

	private void Start () {
		Cubes.AddRange(GetComponentsInChildren<MapCube>());
		Building = true;
		Cubes.ForEach(x => x.transform.position = new Vector3(x.transform.position.x, -5.0f, x.transform.position.z));
		Cubes.ForEach(x => x.transform.DOMoveY(0.0f, Random.Range(_minMoveUpTime, _maxMoveUpTime)));
	}
}
