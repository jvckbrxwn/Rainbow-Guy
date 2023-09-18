using Shop.Panels.Abstract;

namespace Shop.Panels.Hats
{
	public class HatsPanelController : BaseViewShopController<HatsContainer>
	{
		protected override void Init()
		{
			foreach (HatItem hatItem in Items.Items)
			{
				BaseShopViewItem shopViewItem = Instantiate(ShopViewItem, ParentLayout.transform);
				shopViewItem.Setup(hatItem);
			}
		}
	}
}