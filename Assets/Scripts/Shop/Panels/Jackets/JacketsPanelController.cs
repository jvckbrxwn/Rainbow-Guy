using Shop.Panels.Abstract;

namespace Shop.Panels.Jackets
{
	public class JacketsPanelController : BaseViewShopController<JacketsContainer>
	{
		protected override void Init()
		{
			foreach (JacketItem jacketItem in Items.Items)
			{
				BaseShopViewItem shopViewItem = Instantiate(ShopViewItem, ParentLayout.transform);
				shopViewItem.Setup(jacketItem);
			}
		}
	}
}