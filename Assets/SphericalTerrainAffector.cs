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

	[SerializeField]
	private float _damagePerS;

	[SerializeField]
	private bool _notForce;

	private float _endTime;
	private Dictionary<MapCube, float> _affectedCubes = new Dictionary<MapCube, float>();

	private void Start () {
		_endTime = Time.time + _duration;
	}

	private void OnDrawGizmos () {
		Gizmos.DrawWireSphere(transform.position, _radius);
	}

	private void OnDestroy () {
		foreach (KeyValuePair<MapCube, float> c in _affectedCubes) {
			//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
			c.Key.FadeOut();
			//c.Key.RigidBody.position = pos;
		}
	}

	private void Update () {
		Dictionary<MapCube, float> temp = new Dictionary<MapCube, float>(_affectedCubes);
		_affectedCubes.Clear();

		if (_endTime - Time.time > 0.0f || _duration < 0) {
			if (LevelManager.Instance != null) {
				foreach (MapCube c in LevelManager.Instance.Cubes) {
					float dist = Vector3.Distance(c.ProbePosition.position, transform.position);

					if (dist < _radius) {
						float angle = Vector3.Angle(c.ProbePosition.position - transform.position, transform.forward);
						float sign = Mathf.Sign(Vector3.Dot(c.ProbePosition.position - transform.position, transform.right));
						float finalAngle = sign * angle;

						if ((finalAngle <= _angle / 2f && finalAngle >= -_angle / 2f)) {
							if (!_notForce || (_notForce && !c.Fade)) {
								_affectedCubes.Add(c, dist);
								c.StopFade();
							}
						}
					}
				}
			}


			foreach (KeyValuePair<MapCube, float> c in _affectedCubes) {
				//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
				c.Key.SetPosition(Mathf.Sin((((_moveInwards ? 1f : -1f) * Time.time) * _waveSpeed + c.Value) / _waveLength) * _waveHeight);
				c.Key.Damage(_damagePerS * Time.deltaTime);
				//c.Key.RigidBody.position = pos;
			}
		} else {
			foreach (KeyValuePair<MapCube, float> c in _affectedCubes) {
				//pos.y = Mathf.Sin((-Time.time * _waveSpeed + c.Value) / _waveLength) *_waveHeight / c.Value;
				c.Key.FadeOut();
				//c.Key.RigidBody.position = pos;
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
