using System;
using Shop.Panels.Abstract;
using UnityEngine;

namespace Shop.Panels.Shoes
{
	[CreateAssetMenu(fileName = "Shoes", menuName = "Shop/Objects/Shoes", order = 0)]
	public class ShoesContainer : BaseShopContainer<ShoeItem>
	{ }
	
	[Serializable]
	public class ShoeItem: BaseShopItem{}
}