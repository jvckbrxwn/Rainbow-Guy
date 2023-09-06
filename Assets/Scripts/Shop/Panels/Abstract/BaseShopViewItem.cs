using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Panels.Abstract
{
	public abstract class BaseShopViewItem : MonoBehaviour
	{
		[SerializeField] private Image itemImage;
		[SerializeField] private TMP_Text itemPriceText;
		[SerializeField] private Button buyButton;

		public event Action BuyClicked;

		private void Start()
		{
			buyButton.onClick.AddListener(OnBuyClicked);
		}

		private void OnBuyClicked()
		{
			Debug.Log($"Bought {gameObject.name} with price {itemPriceText.text}");
			BuyClicked?.Invoke();
		}

		public void Setup(BaseShopItem item)
		{
			gameObject.name = item.name;
			itemImage.sprite = item.sprite;
			itemPriceText.text = item.price.ToString();
		}
	}
}