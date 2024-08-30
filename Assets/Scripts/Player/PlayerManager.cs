using Controllers.Player;
using Cysharp.Threading.Tasks;
using Managers.Base;
using Managers.Interfaces;
using Managers.UI.Interfaces;
using Zenject;

namespace Managers.Player
{
	public class PlayerManager : BaseManager, IPlayerManager
	{
		[Inject] private IUIManager uiManager;
		[Inject] private IAddressableManager addressableManager;

		private readonly string playerKey;
		private PlayerController playerController;

		protected PlayerManager(string playerKey)
		{
			this.playerKey = playerKey;
		}

		public float JumpSpeed { get; set; }

		public override void Initialize()
		{
			CreatePlayer(playerKey).Forget();
		}

		private async UniTask CreatePlayer(string playerKey)
		{
			playerController = await addressableManager.InstantiateObject<PlayerController>(playerKey);
		}
	}

	public interface IPlayerManager
	{ }
}