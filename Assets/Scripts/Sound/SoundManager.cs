using System.Linq;
using Audio.Scriptable;
using Cysharp.Threading.Tasks;
using Managers.Interfaces;
using Managers.Sound.Interfaces;
using UnityEngine;
using Zenject;
using AudioType = Audio.Scriptable.AudioType;

public class SoundManager : MonoBehaviour, ISoundManager
{
	[Inject] private IAddressableManager addressableManager;

	[Range(0, 1), SerializeField] private float soundVolume;
	[Range(0, 1), SerializeField] private float musicVolume;

	[SerializeField] private MusicHolderScriptable musicHolder;
	[SerializeField] private AudioHolderScriptable soundHolder;

	public async UniTask PlaySound(AudioType type)
	{
		var key = soundHolder.Holder.First(x => x.type == type).address;
		var sound = await RetrieveFile(key);
		AudioSource.PlayClipAtPoint(sound, Vector3.zero, soundVolume);
	}

	public async UniTask PlayMusic(MusicType type)
	{
		//TODO: Vector3.zero replace to Player current position
		var key = musicHolder.Holder.First(x => x.type == type).address;
		var sound = await RetrieveFile(key);
		AudioSource.PlayClipAtPoint(sound, Vector3.zero, musicVolume);
	}

	private async UniTask<AudioClip> RetrieveFile(string id)
	{
		return await addressableManager.GetObjectAsync<AudioClip>(id);
	}
}