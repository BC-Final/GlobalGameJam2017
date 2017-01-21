using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour {

	[SerializeField]
	private Image _image;
	[SerializeField]
	private Color _colorReady;
	[SerializeField]
	private Color _colorCooldown;

	[SerializeField]
	private Image _clock;
	[SerializeField]
	private Text _ammoCount;

	private void Awake()
	{
		_image = GetComponent<Image>();
		_clock = GetComponentInChildren<UIClock>().GetComponent<Image>();
		_ammoCount = GetComponentInChildren<Text>();
	}

	public void Step(float val, float maxVal, int ammo, int maxAmmo)
	{
		if(ammo > 0)
		{
			_image.color = _colorReady;
		}else{
			_image.color = _colorCooldown;
		}

		if(ammo == maxAmmo)
		{
			_clock.fillAmount = 0;
		}else{
			_clock.fillAmount = val / maxVal;
		}

		if(ammo > 1)
		{
			_ammoCount.text = ammo.ToString();
		}else{
			_ammoCount.text = "";
		}
	}
}
