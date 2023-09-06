using Shop.Panels.Abstract;

namespace Shop.Panels.Hats
{
	public class HatsPanelController : BaseShopController<HatsContainer>
	{
		public override void Init()
		{
			foreach (HatItem hatItem in Items.Items)
			{
				BaseShopViewItem shopViewItem = Instantiate(ShopViewItem, ParentLayout.transform);
				shopViewItem.Setup(hatItem);
			}
		}
	}
}