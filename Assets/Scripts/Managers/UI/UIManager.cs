using System.Linq;
using Cysharp.Threading.Tasks;
using Managers.UI.Interfaces;
using Managers.Base;
using Controllers;
using Controllers.Abstract;
using UnityEngine;
using Zenject;

namespace Managers.UI
{
	public class UIManager : BaseMonoManager, IUIManager
	{
		[SerializeField] private Transform parent;
		[SerializeField] private Transform viewsParent;

		[Inject] private IUIController[] uiControllers;

		private async void Start()
		{
			await Show<MenuUIController>();
		}

		public async UniTask Show<T>()
		{
			await uiControllers.First(x => x.GetType() == typeof(T)).Show(viewsParent);
		}
	}
}