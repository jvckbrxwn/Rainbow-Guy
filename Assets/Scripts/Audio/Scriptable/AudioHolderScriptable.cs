using Audio.Scriptable.Base;
using UnityEngine;

namespace Audio.Scriptable
{
	public enum AudioType
	{
		Dead, RedPlatform, GreenPlatform, BluePlatform, LightsOff
	}

	[CreateAssetMenu(fileName = "AudioHolder", menuName = "Holders/Audio", order = 10)]
	public class AudioHolderScriptable : BaseAddressableHolder<AudioType>
	{ }
}