using UnityEngine;
using UnityEngine.UI;
using Managers.Sound.Interfaces;
using UnityEngine.Serialization;
using Zenject;

[RequireComponent(typeof(Toggle))]
public class ToggleScript : MonoBehaviour
{
	[Inject] private readonly ISoundManager soundManager;

	[SerializeField] private Sprite inactive;
	[SerializeField] private Toggle toggle;
	[SerializeField] private Image background;

	private Sprite backgroundActive;

	// void Start()
	// {
	// 	toggle = GetComponent<Toggle>();
	// 	backgroundActive = background.sprite;
	// 	if (gameObject.tag == "SoundButton")
	// 		soundManager.InitSound(toggle);
	// 	if (gameObject.tag == "MusicButton")
	// 		soundManager.InitMusic(toggle);
	// }
	//
	// public void ToggleSound()
	// {
	// 	if (toggle.isOn)
	// 	{
	// 		soundManager.Sound(false);
	// 		background.sprite = backgroundActive;
	// 		soundManager.SaveSoundStatus(true);
	// 	}
	// 	else
	// 	{
	// 		soundManager.Sound(true);
	// 		background.sprite = inactive;
	// 		soundManager.SaveSoundStatus(false);
	// 	}
	// }
	//
	// public void ToggleMusic()
	// {
	// 	if (toggle.isOn)
	// 	{
	// 		soundManager.Music(false);
	// 		background.sprite = backgroundActive;
	// 		soundManager.SaveMusicStatus(true);
	// 	}
	// 	else
	// 	{
	// 		soundManager.Music(true);
	// 		background.sprite = inactive;
	// 		soundManager.SaveMusicStatus(false);
	// 	}
	// }
}