using Cysharp.Threading.Tasks;
using Managers.Base;
using Managers.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
	public class AddressableManager : BaseManager, IAddressableManager
	{
		public async UniTask<T> GetObject<T>(string key)
		{
			AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(key);
			GameObject obj = await asyncOperationHandle.Task;
			obj.TryGetComponent(out T component);
			return component;
		}
	}
}