using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
	private void Start () {
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("scn_deco", UnityEngine.SceneManagement.LoadSceneMode.Additive);
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("scn_map", UnityEngine.SceneManagement.LoadSceneMode.Additive);
	}

	private void Update () {
		if (Input.anyKeyDown) {
			UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("scn_menu");
		}
	}
}
