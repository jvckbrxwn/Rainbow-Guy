using System;
using Shop.Panels.Abstract;
using UnityEngine;

namespace Shop.Panels.Jackets
{
	[CreateAssetMenu(fileName = "Jackets", menuName = "Shop/Objects/Jackets", order = 0)]
	public class JacketsContainer : BaseShopContainer<JacketItem>
	{ }

	[Serializable]
	public class JacketItem : BaseShopItem
	{ }
}