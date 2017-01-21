using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {
	private static PrefabManager _instance;
	[SerializeField]
	public GameObject Explosion;

	public static PrefabManager GetInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<PrefabManager>();
		}
		return _instance;
	}
}
