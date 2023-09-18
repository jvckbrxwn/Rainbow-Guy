using Cysharp.Threading.Tasks;
using Managers.Interfaces;
using UI.Views.Abstract;
using UnityEngine;
using Zenject;

namespace Controllers.Abstract
{
	public abstract class BaseUIController<T> : IUIController where T : BaseUIView
	{
		[Inject] private IAddressableManager addressableManager;

		private readonly string key;
		protected T View;

		protected BaseUIController(string key)
		{
			this.key = key;
		}

		public virtual async UniTask Show(Transform parent)
		{
			if (!View)
			{
				View = await addressableManager.InstantiateObject<T>(key, parent);
			}

			View.Show();
		}

		public virtual async UniTask Hide()
		{
			View.Hide();
		}
	}

	public interface IUIController
	{
		UniTask Show(Transform parent);
		UniTask Hide();
	}
}