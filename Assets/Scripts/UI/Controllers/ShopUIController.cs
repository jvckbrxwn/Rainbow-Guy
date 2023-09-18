using Controllers.Abstract;
using Cysharp.Threading.Tasks;
using Shop.Panels.Abstract;
using UI.Views;
using UnityEngine;

namespace Controllers
{
	public class ShopUIController : BaseUIController<ShopUIView>
	{
		private IShopController previousShopController;

		public ShopUIController(string key) : base(key)
		{ }

		public override async UniTask Show(Transform parent)
		{
			await base.Show(parent);
			View.ShopViewWasOpened += OnShopViewWasOpened;
		}

		public override async UniTask Hide()
		{
			await base.Hide();
			View.ShopViewWasOpened -= OnShopViewWasOpened;
		}

		private void OnShopViewWasOpened(IShopController controller)
		{
			previousShopController?.Hide();
			previousShopController = controller;
			previousShopController.Show();
		}
	}
}