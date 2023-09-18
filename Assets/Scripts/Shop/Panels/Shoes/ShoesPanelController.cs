using Shop.Panels.Abstract;

namespace Shop.Panels.Shoes
{
	public class ShoesPanelController : BaseViewShopController<ShoesContainer>
	{
		protected override void Init()
		{
			foreach (ShoeItem shoeItem in Items.Items)
			{
				BaseShopViewItem shopViewItem = Instantiate(ShopViewItem, ParentLayout.transform);
				shopViewItem.Setup(shoeItem);
			}
		}
	}
}