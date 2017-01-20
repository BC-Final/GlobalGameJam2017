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

	private List<MapCube> frstPlayerIsland = new List<MapCube>();
	private List<MapCube> scndPlayerIsland = new List<MapCube>();

	private void Start() {
		for (int p = -1; p <= 1; p += 2) {
			for (int i = 0; i < _numberOfRows; ++i) {
				for (int j = 0; j < _numberOfColums; ++j) {
					GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
					go.transform.position = new Vector3(p * (i + _islandDistance), 0, j);
					go.transform.localScale = new Vector3(1, 3, 1);
					go.transform.parent = transform;
					go.AddComponent<MapCube>();
					new GameObject("Probe").transform.parent = go.transform;
					if (p < 0) {
						frstPlayerIsland.Add(go.GetComponent<MapCube>());
					} else {
						scndPlayerIsland.Add(go.GetComponent<MapCube>());
					}
				}
			}
		}
	}

	void Update () {
		foreach (MapCube go in frstPlayerIsland) {
			float dist = Vector3.Distance(go.transform.position, new Vector3(15, 0, 15));
			if (dist < 10.0f) {
				float angle = Vector3.Angle(go.transform.position -new Vector3(15, 0, 15), Vector3.forward);
				float sign = Mathf.Sign(Vector3.Dot(go.transform.position - new Vector3(15, 0, 15), Vector3.right));
				float finalAngle = sign * angle;

				if (!(finalAngle <= 360f / 2f && finalAngle >= -360f / 2f)) {
					Vector3 pos = go.transform.position;
					pos.y = 0;
					go.transform.position = pos;
				} else {
					Vector3 pos = go.transform.position;
					pos.y = Mathf.Sin(-Time.time * 10 + dist);
					go.transform.position = pos;
				}

			} else {
				Vector3 pos = go.transform.position;
				pos.y = 0;
				go.transform.position = pos;
			}
		}
	}
}
