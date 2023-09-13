using Cysharp.Threading.Tasks;
using Managers.Base;
using Managers.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
	public class AddressableManager : BaseManager, IAddressableManager
	{
		public async UniTask<T> GetObject<T>(string key)
		{
			AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(key);
			T obj = await asyncOperationHandle.Task;
			return obj;
		}
	}
}