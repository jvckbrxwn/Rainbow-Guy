using UnityEngine;
using Zenject;

namespace Installers
{
	public class MenuSceneInstaller : MonoInstaller
	{
		[SerializeField] private ShopManager shopManager;
		
		public override void InstallBindings()
		{
			Container.Bind<IShopManager>().To<ShopManager>().FromComponentInNewPrefab(shopManager).AsSingle().NonLazy();
		}
	}
}