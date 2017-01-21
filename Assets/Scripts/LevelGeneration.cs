using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
	[SerializeField]
	private GameObject _prefab;

	[SerializeField]
	private int _numberOfRows;

	[SerializeField]
	private float _verticalDistance;

	[SerializeField]
	private float _horizontalDistance;

	[SerializeField]
	private float _rowOffset;

	[SerializeField]
	private int _numberOfColums;

	[SerializeField]
	private int _islandDistance;

	public static List<MapCube> Tiles = new List<MapCube>();

	private void Awake() {
		for (int p = -1; p <= 1; p += 2) {
			for (int i = 0; i < _numberOfRows; ++i) {
				for (int j = 0; j < _numberOfColums; ++j) {
					/*
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
					*/

					Vector3 pos = new Vector3(
						p * (i * _verticalDistance + _islandDistance),
						0,
						j * _horizontalDistance + (i % 2 == 0 ? _rowOffset : 0)
						);

					GameObject go = GameObject.Instantiate(_prefab, pos, Quaternion.identity, transform);

					Tiles.Add(go.GetComponentInChildren<MapCube>());
				}
			}
		}
	}
}
