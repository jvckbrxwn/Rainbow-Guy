using Audio.Scriptable;
using Cysharp.Threading.Tasks;

namespace Managers.Sound.Interfaces
{
	public interface ISoundManager
	{
		UniTask PlaySound(AudioType type);
		UniTask PlayMusic(MusicType type);
	}
}