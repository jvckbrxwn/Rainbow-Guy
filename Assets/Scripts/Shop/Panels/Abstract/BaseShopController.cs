using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Panels.Abstract
{
	public abstract class BaseShopController<T> : MonoBehaviour
	{
		[SerializeField] private GridLayoutGroup gridLayout;
		[SerializeField] private BaseShopViewItem shopViewItem;
		[SerializeField] private T items;

		protected T Items => items;
		protected GridLayoutGroup ParentLayout => gridLayout;
		protected BaseShopViewItem ShopViewItem => shopViewItem;

		public abstract void Init();

		protected void OnEnable()
		{
			Init();
		}

		//TODO: create pool to reuse items
		protected void OnDisable()
		{
			foreach (Transform item in gridLayout.transform)
			{
				Destroy(item.gameObject);
			}
		}
	}
}