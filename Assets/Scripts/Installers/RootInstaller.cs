using Managers.UI;
using Managers.UI.Interfaces;
using Managers;
using Managers.Application;
using Managers.Application.Interfaces;
using Managers.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class RootInstaller : MonoInstaller
	{
		[SerializeField] private UIManager uiManager;
		[SerializeField] private ShopManager shopManager;

		public override void InstallBindings()
		{
			Container.Bind<IAddressableManager>().To<AddressableManager>().AsSingle().Lazy();
			Container.Bind<IUIManager>().To<UIManager>().FromComponentInNewPrefab(uiManager).AsSingle().NonLazy();
			Container.Bind<IApplicationManager>().To<ApplicationManager>().AsSingle().NonLazy();
			//Container.Bind<IShopManager>().To<ShopManager>().FromComponentInNewPrefab(shopManager).AsSingle().NonLazy();
		}
	}
}