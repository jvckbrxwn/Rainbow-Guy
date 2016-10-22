using System;
using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Range(0, 1)] public float soundVolume;
    [Range(0, 1)] public float musicVolume;

    [SerializeField] private AudioSource _greenPlatformSound;
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _powerUpSound;
    [SerializeField] private AudioSource _deathSound;

    [SerializeField] private AudioClip _redPlatformSoundClip;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

	#region publicFunctions
	public void OnLevelWasLoaded(int level)
	{
		if(level == 1)
			_mainMusic.mute = true;
		else
			_mainMusic.mute = false;
	}

    public void SoundMute(bool isOn = true)
    {
        _deathSound.mute = isOn;
        _greenPlatformSound.mute = isOn;
        _mainMusic.mute = isOn;
        _powerUpSound.mute = isOn;
	}

    public void SoundPlay(bool isOn = false)
    {
        _deathSound.mute = isOn;
        _greenPlatformSound.mute = isOn;
        _mainMusic.mute = isOn;
        _powerUpSound.mute = isOn;
    }

    public bool isMuted()
    {
        return _mainMusic.mute && _deathSound.mute && _greenPlatformSound.mute && _powerUpSound.mute;
    }

    public void RedPlatformSoundPlay(Transform transform)
    {
        if(!isMuted())
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

	public void SaveSoundStatus(bool isSoundOn)
	{
		Debug.Log("Status sound: " + Convert.ToInt32(isSoundOn));
		PlayerPrefs.SetInt("isSoundOn", Convert.ToInt32(isSoundOn));
	}
	#endregion

	#region privateFunctions

	#endregion
}
