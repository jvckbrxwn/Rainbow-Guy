using Shop.Panels.Abstract;

namespace Shop.Panels.Jackets
{
	public class JacketsPanelController : BaseShopController<JacketsContainer>
	{
		public override void Init()
		{
			foreach (JacketItem jacketItem in Items.Items)
			{
				BaseShopViewItem shopViewItem = Instantiate(ShopViewItem, ParentLayout.transform);
				shopViewItem.Setup(jacketItem);
			}
		}
	}
}