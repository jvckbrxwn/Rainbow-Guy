using Controllers.Abstract;
using Cysharp.Threading.Tasks;
using Managers.UI.Interfaces;
using UI.Views;
using UnityEngine;
using Zenject;

namespace Controllers
{
	public class MenuUIController : BaseUIController<MenuUIView>
	{
		[Inject] private IUIManager uiManager;

		public MenuUIController(string key) : base(key)
		{ }

		public override async UniTask Show(Transform parent)
		{
			await base.Show(parent);
			View.ShopClicked += OnShopClicked;
			View.SettingsClicked += OnSettingsClicked;
			View.AchievementsClicked += OnAchievementsClicked;
		}

		public override async UniTask Hide()
		{
			await base.Hide();
			View.ShopClicked -= OnShopClicked;
			View.SettingsClicked -= OnShopClicked;
			View.AchievementsClicked -= OnShopClicked;
		}

		private async void OnShopClicked()
		{
			await uiManager.Show<ShopUIController>();
		}

		private async void OnAchievementsClicked()
		{
			await uiManager.Show<AchievementsUIController>();
		}

		private async void OnSettingsClicked()
		{
			await uiManager.Show<SettingsUIController>();
		}
	}
}