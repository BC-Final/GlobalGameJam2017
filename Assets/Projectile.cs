using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float _speed;
	public float _lifeTime;

	void Start () {
		Destroy(gameObject, _lifeTime);
	}

	void Update () {
		transform.Translate(0, 0, _speed * Time.deltaTime);
	}
}
