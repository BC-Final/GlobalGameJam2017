using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour {

	[SerializeField]
	public GameObject _basePrefab;

	public float _speed;
	public float _lifeTime;
	public float _explosionRange;

	private float _timer;

	void Start()
	{
	}

	void Update()
	{
		_timer += Time.deltaTime;
		if(_timer > _lifeTime)
		{
			GameObject.Instantiate(PrefabManager.GetInstance().Explosion, transform.position, Quaternion.identity);
			GameObject.Instantiate(_basePrefab, transform.position, transform.rotation);
			Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRange);
			foreach(Collider hit in hits)
			{
				if (hit.gameObject.GetComponent<Player>() != null)
				{
					
					Vector3 force = (hit.gameObject.transform.position - this.transform.position);
					
					float forcePerc = 1-(Mathf.Clamp(force.magnitude,0,_explosionRange) / _explosionRange);

					//force.y = force.y * 2;
					force.Normalize();
					Debug.Log(forcePerc);
					hit.gameObject.GetComponent<Rigidbody>().AddForce(force * 10000 * forcePerc);
				}
			}
			GameObject.Destroy(this.gameObject);
		}
		transform.Translate(0, 0, _speed * Time.deltaTime);
	}
}
