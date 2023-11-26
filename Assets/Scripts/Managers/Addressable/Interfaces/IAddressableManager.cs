using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Managers.Interfaces
{
	public interface IAddressableManager
	{
		UniTask<T> GetObjectAsync<T>(string key);
		UniTask<T> InstantiateObject<T>(string key, Transform parent = null) where T : class;
	}
}