using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Toggle))]
public class ToggleScript : MonoBehaviour
{
	[SerializeField] private SoundManager _soundManager;
	public Sprite Inactive = null;

	private Toggle _Toggle = null;
	private Image _Background = null;
	private Sprite _BackgroundActive = null;

	void Awake()
	{
		_soundManager = GameObject.FindObjectOfType<SoundManager>();
		_Toggle = GetComponent<Toggle>();
		_Background = transform.GetComponentInChildren<Image>();
		_BackgroundActive = _Background.sprite;
		if(PlayerPrefs.HasKey("isSoundOn"))
			_Toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("isSoundOn"));
		else
			_Toggle.isOn = true;
		Toggle();
	}

	public void Toggle()
	{
		if(_Toggle.isOn)
		{
			_soundManager.SoundPlay();
			_Background.sprite = _BackgroundActive;
			_soundManager.SaveSoundStatus(true);
		}
		else
		{
			_soundManager.SoundMute();
			_Background.sprite = Inactive;
			_soundManager.SaveSoundStatus(false);
		}
	}
}