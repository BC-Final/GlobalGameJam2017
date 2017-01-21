using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public static List<MapCube> Cubes = new List<MapCube>();

	private void Start () {
		Cubes.AddRange(GetComponentsInChildren<MapCube>());
	}
}
