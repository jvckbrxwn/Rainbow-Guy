using Audio.Scriptable.Base;
using UnityEngine;

namespace Audio.Scriptable
{
	public enum MusicType
	{
		Main, GameOver
	}

	[CreateAssetMenu(fileName = "AudioHolder", menuName = "Holders/Music", order = 10)]
	public class MusicHolderScriptable : BaseAddressableHolder<MusicType>
	{ }
}