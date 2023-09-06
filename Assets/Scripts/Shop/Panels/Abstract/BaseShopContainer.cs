using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Panels.Abstract
{
	public class BaseShopContainer<T> : ScriptableObject where T : BaseShopItem
	{
		[SerializeField] private List<T> items;

		public List<T> Items => items;
	}

	[Serializable]
	public class BaseShopItem
	{
		public string name;
		public int price;
		public Sprite sprite;
		public bool isExist;
	}
}