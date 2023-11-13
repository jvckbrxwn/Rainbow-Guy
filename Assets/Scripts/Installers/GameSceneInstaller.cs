using Managers.Sound.Interfaces;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
	[SerializeField] private SoundManager soundManager;

	public override void InstallBindings()
	{
		Container.Bind<ISoundManager>().To<SoundManager>().FromComponentInNewPrefab(soundManager).AsSingle().NonLazy();
	}
}