using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoader : MonoBehaviour {
	private void Start () {
		UnityEngine.SceneManagement.SceneManager.LoadScene("scn_menu", UnityEngine.SceneManagement.LoadSceneMode.Additive);
	}
}
