using Controllers;
using Controllers.Abstract;
using Zenject;

namespace Installers
{
	public class ViewControllersInstaller : MonoInstaller
	{
		//arguments here needed as a name fom addressables loading
		public override void InstallBindings()
		{
			Container.Bind<IUIController>().To<AchievementsUIController>().AsSingle().WithArguments("Achievements").Lazy();
			Container.Bind<IUIController>().To<ShopUIController>().AsSingle().WithArguments("Shop").Lazy();
			Container.Bind<IUIController>().To<SettingsUIController>().AsSingle().WithArguments("Settings").Lazy();
			Container.Bind<IUIController>().To<MenuUIController>().AsSingle().WithArguments("Menu").Lazy();
			Container.Bind<IUIController>().To<PauseUIController>().AsSingle().WithArguments("Pause").Lazy();
			Container.Bind<IUIController>().To<GameOverUIController>().AsSingle().WithArguments("GameOver").Lazy();
			Container.Bind<IUIController>().To<GameUIController>().AsSingle().WithArguments("Game").Lazy();
		}
	}
}