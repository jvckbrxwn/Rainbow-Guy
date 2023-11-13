using Managers;
using Managers.Application;
using Managers.Application.Interfaces;
using Managers.Interfaces;
using Managers.Sound.Interfaces;
using Managers.UI;
using Managers.UI.Interfaces;
using Managers.User;
using Managers.User.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class GlobalServicesInstaller : MonoInstaller
	{
		[SerializeField] private UIManager uiManager;
		[SerializeField] private SoundManager soundManager;
		
		public override void InstallBindings()
		{
			Container.Bind<IAddressableManager>().To<AddressableManager>().AsSingle().Lazy();
			Container.Bind<IUserManager>().To<UserManager>().AsSingle().NonLazy();
			Container.Bind<IUIManager>().To<UIManager>().FromComponentInNewPrefab(uiManager).AsSingle().NonLazy();
			Container.Bind<IApplicationManager>().To<ApplicationManager>().AsSingle().NonLazy();
			Container.Bind<ISoundManager>().To<SoundManager>().FromComponentInNewPrefab(soundManager).AsSingle().NonLazy();
		}
	}
}