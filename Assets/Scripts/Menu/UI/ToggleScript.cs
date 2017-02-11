using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Toggle))]
public class ToggleScript : MonoBehaviour
{
	private SoundManager _soundManager;
	public Sprite Inactive = null;
	private Toggle _Toggle = null;
	[SerializeField] private Image _Background = null;
	private Sprite _BackgroundActive = null;

	void Start()
	{
		_soundManager = GameObject.FindObjectOfType<SoundManager>();
		_Toggle = GetComponent<Toggle>();
		_BackgroundActive = _Background.sprite;
        if (gameObject.tag == "SoundButton")
            _soundManager.InitSound(_Toggle);
        if (gameObject.tag == "MusicButton")
            _soundManager.InitMusic(_Toggle);
	}

	public void ToggleSound()
	{
		if(_Toggle.isOn)
		{
			_soundManager.Sound(false);
			_Background.sprite = _BackgroundActive;
			_soundManager.SaveSoundStatus(true);
		}
		else
		{
			_soundManager.Sound(true);
			_Background.sprite = Inactive;
			_soundManager.SaveSoundStatus(false);
		}
	}

    public void ToggleMusic()
    {
        if (_Toggle.isOn)
        {
            _soundManager.Music(false);
            _Background.sprite = _BackgroundActive;
            _soundManager.SaveMusicStatus(true);
        }
        else
        {
            _soundManager.Music(true);
            _Background.sprite = Inactive;
            _soundManager.SaveMusicStatus(false);
        }
    }
}