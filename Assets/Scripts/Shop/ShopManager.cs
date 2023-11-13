using Managers.Base;
using UnityEngine;
using TMPro;

public class ShopManager : BaseMonoManager, IShopManager
{
	[SerializeField] private TMP_Text _text;

	private int _price, selectedHat, selectedJacket, selectedShoe;

	private void Start()
	{
		//UpdateTextCoins();
	}

	private void UpdateTextCoins()
	{
		_text.text = "Coins: " + CoinsManager.Coins;
	}
}

public interface IShopManager
{ }