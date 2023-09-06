using System;
using Shop.Panels.Abstract;
using UnityEngine;

namespace Shop.Panels.Hats
{
	[CreateAssetMenu(fileName = "Hats", menuName = "Shop/Objects/Hats", order = 0)]
	public class HatsContainer : BaseShopContainer<HatItem>
	{ }

	[Serializable]
	public class HatItem : BaseShopItem
	{ }
}