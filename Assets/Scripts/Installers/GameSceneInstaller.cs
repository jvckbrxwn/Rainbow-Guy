using Managers.Player;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSceneInstaller", menuName = "Installers/GameSceneInstaller")]
public class GameSceneInstaller : ScriptableObjectInstaller<GameSceneInstaller>
{
	public override void InstallBindings()
	{
		//Player
		Container.BindInterfacesAndSelfTo<PlayerManager>().AsSingle()
			.WithArguments("Player");
	}
}