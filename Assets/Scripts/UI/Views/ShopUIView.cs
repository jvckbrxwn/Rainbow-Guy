using UI.Views.Abstract;

namespace UI.Views
{
	public class ShopUIView : BaseUIView
	{
		public override void Show()
		{
			gameObject.SetActive(true);
		}

		public override void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}