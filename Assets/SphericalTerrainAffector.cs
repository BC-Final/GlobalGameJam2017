using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalTerrainAffector : MonoBehaviour {
	[SerializeField]
	private float _radius;

	[SerializeField]
	private float _angle;

	[SerializeField]
	private float _duration;

	[SerializeField]
	private float _waveSpeed;

	[SerializeField]
	private float _waveHeight;

	[SerializeField]
	private float _waveLength;

	[SerializeField]
	private bool _moveInwards;

	private float _endTime;
	private Dictionary<MapCube, float> _affectedCubes = new Dictionary<MapCube, float>();

	private void Start () {

		_endTime = Time.time + _duration;
	}

	private void Update () {
		/*
		foreach (KeyValuePair<MapCube, float> c in _affectedCubes) {
			Vector3 pos = c.Key.transform.position;
			//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
			pos.y = 0f;
			c.Key.transform.position = pos;
		}
		*/

		Dictionary<MapCube, float> temp = new Dictionary<MapCube, float>(_affectedCubes);
		_affectedCubes.Clear();

		if (_endTime - Time.time > 0.0f) {
			foreach (MapCube c in LevelGeneration.Tiles) {
				float dist = Vector3.Distance(c.ProbePosition.position, transform.position);

				if (dist < _radius) {
					float angle = Vector3.Angle(c.transform.position - transform.position, transform.forward);
					float sign = Mathf.Sign(Vector3.Dot(c.transform.position - transform.position, transform.right));
					float finalAngle = sign * angle;

					if ((finalAngle <= _angle / 2f && finalAngle >= -_angle / 2f)) {
						_affectedCubes.Add(c, dist);
						c.StopFade();
					}
				}
			}

			foreach (KeyValuePair<MapCube, float> c in _affectedCubes) {
				Vector3 pos = c.Key.transform.position;
				//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
				pos.y = Mathf.Sin((((_moveInwards ? 1f : -1f) * Time.time) * _waveSpeed + c.Value) / _waveLength) * _waveHeight;
				c.Key.transform.position = pos;
			}
		} else {
			foreach (KeyValuePair<MapCube, float> c in _affectedCubes) {
				Vector3 pos = c.Key.transform.position;
				//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
				pos.y = 0.0f;
				c.Key.transform.position = pos;
			}

			GameObject.Destroy(gameObject);
			//TODO Make it fade out;
		}

		foreach (KeyValuePair<MapCube, float> pair in temp) {
			if (!_affectedCubes.ContainsKey(pair.Key)) {
				pair.Key.FadeOut();
			}
		}
	}
}
