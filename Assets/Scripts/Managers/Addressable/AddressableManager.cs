using System.Collections.Generic;
using System.Linq;
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
		private readonly List<Component> components = new ();

		public async UniTask<T> GetObjectAsync<T>(string key)
		{
			AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(key);
			T component = await asyncOperationHandle.Task;
			return component;
		}

		public async UniTask<T> InstantiateObject<T>(string key, Transform parent = null) where T : class
		{
			if (components.Any(x => x.TryGetComponent(typeof(T), out _)))
			{
				return components.First(x => x.GetComponent(typeof(T))) as T;
			}

			AsyncOperationHandle<GameObject> operation = Addressables.InstantiateAsync(key, parent);
			GameObject obj = await operation;
			obj.TryGetComponent(typeof(T), out var component);
			components.Add(component);
			return component as T;
		}
	}
}