using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {
	
	public float targetSize;
	public float animTime;
	public float colorFadeTime;
	public Material material;

	private float startSize;
	private float currentLerpTime;
	private float currentColorLerpTime;


	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer>().material;
		startSize = transform.localScale.x;
		GameObject.Destroy(this.gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		//reset when we press spacebar
		if (Input.GetKeyDown(KeyCode.Space))
		{
			currentLerpTime = 0f;
			currentColorLerpTime = 0f;
		}

		//increment timer once per frame
		currentLerpTime += Time.deltaTime;
		currentColorLerpTime += Time.deltaTime;

		if (currentLerpTime > animTime)
		{
			currentLerpTime = animTime;
		}
		if (currentColorLerpTime > colorFadeTime)
		{
			currentColorLerpTime = colorFadeTime;
		}

		//lerp!
		float perc = currentLerpTime / animTime;
		float colorPerc = currentColorLerpTime / colorFadeTime;
		float curScale = Mathf.Lerp(startSize, targetSize, perc);

		Color newColor = material.GetColor("_TintColor");
		newColor.a = 1-colorPerc;
		material.SetColor("_TintColor", newColor);
		transform.localScale = new Vector3(curScale, curScale, curScale);
	}
}
