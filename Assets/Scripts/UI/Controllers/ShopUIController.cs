using Controllers.Abstract;
using UI.Views;

namespace Controllers
{
	public class ShopUIController : BaseUIController<ShopUIView>
	{
		public ShopUIController(string key) : base(key)
		{ }
	}
}