using System;
using Managers.Sound.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour, ISoundManager
{
	[Range(0, 1)] public float soundVolume;
	[Range(0, 1)] public float musicVolume;

	[SerializeField] private AudioSource _greenPlatformSound;
	[SerializeField] private AudioSource _mainMusic;
	[SerializeField] private AudioSource _powerUpSound;
	[SerializeField] private AudioSource _deathSound;
	[SerializeField] private AudioSource _flashlightSound;

	[SerializeField] private AudioClip _redPlatformSoundClip;

#region publicFunctions

	public void OnLevelWasLoaded(int level)
	{
		if (level == 1)
		{
			_mainMusic.mute = true;
			_deathSound.mute = false;
		}
	}

	public void Init()
	{
		if (PlayerPrefs.HasKey("isSoundOn"))
			Sound(!Convert.ToBoolean(PlayerPrefs.GetInt("isSoundOn")));
		else
			Sound(false);
		if (PlayerPrefs.HasKey("isMusicOn"))
			Music(!Convert.ToBoolean(PlayerPrefs.GetInt("isMusicOn")));
		else
			Music(false);
	}

	public void InitSound(Toggle _Toggle)
	{
		_Toggle.isOn = !PlayerPrefs.HasKey("isSoundOn") || Convert.ToBoolean(PlayerPrefs.GetInt("isSoundOn"));
	}

	public void InitMusic(Toggle _Toggle)
	{
		_Toggle.isOn = !PlayerPrefs.HasKey("isMusicOn") || Convert.ToBoolean(PlayerPrefs.GetInt("isMusicOn"));
	}

	public void Sound(bool isOn = false)
	{
		_deathSound.mute = isOn;
		_greenPlatformSound.mute = isOn;
		_powerUpSound.mute = isOn;
	}

	public void Music(bool isOn = false)
	{
		_mainMusic.mute = isOn;
	}

	public bool isMuted()
	{
		return _deathSound.mute && _greenPlatformSound.mute && _powerUpSound.mute;
	}

	public void RedPlatformSoundPlay(Transform transform)
	{
		if (!isMuted())
			AudioSource.PlayClipAtPoint(_redPlatformSoundClip, transform.position, soundVolume);
	}

	public void GreenPlatformSoundPlay()
	{
		_greenPlatformSound.volume = soundVolume;
		_greenPlatformSound.Play();
	}

	public void MainMusicPlay()
	{
		_mainMusic.volume = musicVolume;
		_mainMusic.Play();
	}

	public void PowerUpSoundPlay()
	{
		_powerUpSound.volume = soundVolume;
		_powerUpSound.Play();
	}

	public void DeathSoundPlay()
	{
		_deathSound.volume = soundVolume;
		_deathSound.Play();
	}

	public void FlashlightOffOn()
	{
		_flashlightSound.volume = soundVolume;
		_flashlightSound.Play();
	}

	public void SaveSoundStatus(bool isSoundOn)
	{
		Debug.Log("Status sound: " + Convert.ToInt32(isSoundOn));
		PlayerPrefs.SetInt("isSoundOn", Convert.ToInt32(isSoundOn));
	}

	public void SaveMusicStatus(bool isMusicOn)
	{
		Debug.Log("Status music: " + Convert.ToInt32(isMusicOn));
		PlayerPrefs.SetInt("isMusicOn", Convert.ToInt32(isMusicOn));
	}

#endregion

#region privateFunctions

	private void SaveStatus()
	{
		PlayerPrefs.Save();
	}

#endregion
}