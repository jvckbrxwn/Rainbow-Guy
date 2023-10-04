using Controllers.Abstract;
using Shop.Panels.Abstract;
using UI.Views;

namespace Controllers
{
	public class ShopUIController : BaseUIController<ShopUIView>
	{
		private IShopController previousShopController;

		public ShopUIController(string key) : base(key)
		{ }

		protected override void Init()
		{
			View.ShopViewWasOpened += OnShopViewWasOpened;
		}

		private void OnShopViewWasOpened(IShopController controller)
		{
			previousShopController?.Hide();
			previousShopController = controller;
			previousShopController.Show();
		}
	}
}