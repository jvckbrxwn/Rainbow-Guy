using Managers.UI;
using Managers.UI.Interfaces;
using Managers;
using Managers.Interfaces;
using Zenject;

namespace Root
{
	public class Root : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IAddressableManager>().To<AddressableManager>().AsSingle().NonLazy();
			Container.Bind<IUIManager>().To<UIManager>().AsSingle().NonLazy();
		}
	}
}