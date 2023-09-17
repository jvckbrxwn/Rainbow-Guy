using Controllers;
using Controllers.Abstract;
using Zenject;

namespace Installers
{
	public class ViewControllersInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IUIController>().To<AchievementsUIController>().AsSingle().WithArguments("Achievements").Lazy();
			Container.Bind<IUIController>().To<ShopUIController>().AsSingle().WithArguments("Shop").Lazy();
			Container.Bind<IUIController>().To<SettingsUIController>().AsSingle().WithArguments("Settings").Lazy();
			Container.Bind<IUIController>().To<MenuUIController>().AsSingle().WithArguments("Menu").Lazy();
		}
	}
}