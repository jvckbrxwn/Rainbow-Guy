using Shop.Panels.Abstract;

namespace Shop.Panels.Shoes
{
	public class ShoesPanelController : BaseShopController<ShoesContainer>
	{
		public override void Init()
		{
			foreach (ShoeItem shoeItem in Items.Items)
			{
				BaseShopViewItem shopViewItem = Instantiate(ShopViewItem, ParentLayout.transform);
				shopViewItem.Setup(shoeItem);
			}
		}
	}
}