using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
	[SerializeField]
	private int _numberOfRows;

	[SerializeField]
	private int _numberOfColums;

	[SerializeField]
	private int _islandDistance;

	public static List<MapCube> Tiles = new List<MapCube>();

	private void Awake() {
		for (int p = -1; p <= 1; p += 2) {
			for (int i = 0; i < _numberOfRows; ++i) {
				for (int j = 0; j < _numberOfColums; ++j) {
					GameObject probe = new GameObject("Probe");
					probe.transform.parent = transform;
					probe.transform.localPosition =  new Vector3(p * (i + _islandDistance), 0, j);
					
					GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
					go.transform.parent = probe.transform;
					go.transform.localPosition = new Vector3(0, 0, 0);
					go.transform.localScale = new Vector3(1, 3, 1);
					go.AddComponent<MapCube>();
					go.AddComponent<Rigidbody>().isKinematic = true;
					go.GetComponent<Rigidbody>().useGravity = false;

					Tiles.Add(go.GetComponent<MapCube>());
				}
			}
		}
	}
}
