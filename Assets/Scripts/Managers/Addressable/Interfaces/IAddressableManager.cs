using Cysharp.Threading.Tasks;

namespace Managers.Interfaces
{
	public interface IAddressableManager
	{
		UniTask<T> GetObject<T>(string key);
	}
}