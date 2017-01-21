using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float _speed;
	public float _lifeTime;
	public float _force;
	public Player owner;

	void Start () {
		Destroy(gameObject, _lifeTime);
	}

	void Update () {
		transform.Translate(0, 0, _speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Player>() && other.GetComponent<Player>() != owner)
		{
			Vector3 targetVector = (other.transform.position - this.transform.position);
			other.GetComponent<Rigidbody>().AddForce(targetVector * _force);
			GameObject.Destroy(this.gameObject);
		}
	}
}
