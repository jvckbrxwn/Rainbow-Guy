using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    [SerializeField] private Text _text;
    [SerializeField] private GameObject _hatsPanel;
    [SerializeField] private GameObject _jacketsPanel;
    [SerializeField] private GameObject _shoesPanel;

    private int _price;
    private List<int> unlockHats = new List<int>();
    private List<int> unlockJackets = new List<int>();
    private List<int> unlockShoes = new List<int>();

    private void Start()
    {
        GetHats();
        GetJackets();
        GetShoes();
        CoinsManager.GetCoins();
        UpdateTextCoins();
    } 

    #region Hats
    public void BuyHatOne(int item)
    {
        UnlockHat(item);
    }

    private void GetHats()
    {
        try
        {
            unlockHats.AddRange(PlayerPrefsX.GetIntArray("UnlockHat"));
        }
        catch { }
    }

    private void UnlockHat(int item)
    {
        if (!unlockHats.Contains(item))
        {
            unlockHats.Add(item);
            PlayerPrefsX.SetIntArray("UnlockHat", unlockHats.ToArray());
            CoinsManager.SetCoins(-_price);
            UpdateTextCoins();
            Debug.Log("Click Hat " + item.ToString());
        }
    }
    #endregion

    #region Jackets
    public void BuyJacketOne(int item)
    {
        UnlockJacket(item);
    }

    private void GetJackets()
    {
        try
        {
            unlockJackets.AddRange(PlayerPrefsX.GetIntArray("UnlockJacket"));
        }
        catch { }
    }

    private void UnlockJacket(int item)
    {
        if (!unlockJackets.Contains(item))
        {
            unlockJackets.Add(item);
            PlayerPrefsX.SetIntArray("UnlockJacket", unlockJackets.ToArray());
            CoinsManager.SetCoins(-_price);
            UpdateTextCoins();
            Debug.Log("Click Jacket " + item.ToString());
        }
    }
    #endregion

    #region Shoe
    public void BuyShoesOne(int item)
    {
        UnlockShoe(item);
    }

    private void GetShoes()
    {
        try
        {
            unlockShoes.AddRange(PlayerPrefsX.GetIntArray("UnlockShoe"));
        }
        catch { }
    }

    private void UnlockShoe(int item)
    {
        if (!unlockShoes.Contains(item))
        {
            unlockShoes.Add(item);
            PlayerPrefsX.SetIntArray("UnlockShoe", unlockShoes.ToArray());
            CoinsManager.SetCoins(-_price);
            UpdateTextCoins();
            Debug.Log("Click Shoe " + item.ToString());
        }
    }
    #endregion

    #region ButtonsToOpen
    public void OpenHats()
    {
        _hatsPanel.SetActive(true);
        if (_jacketsPanel.activeSelf)
            _jacketsPanel.SetActive(false);
        if (_shoesPanel.activeSelf)
            _shoesPanel.SetActive(false);
    }

    public void OpenJackets()
    {
        _jacketsPanel.SetActive(true);
        if (_hatsPanel.activeSelf)
            _hatsPanel.SetActive(false);
        if (_shoesPanel.activeSelf)
            _shoesPanel.SetActive(false);
    }

    public void OpenShoes()
    {
        _shoesPanel.SetActive(true);
        if (_hatsPanel.activeSelf)
            _hatsPanel.SetActive(false);
        if (_jacketsPanel.activeSelf)
            _jacketsPanel.SetActive(false);
    }
    #endregion

    private void UpdateTextCoins()
    {
        _text.text = "Coins: " + CoinsManager.Coins.ToString();
    }

    public static int SelectedHat
    {
        get
        {
            return 0;
        }
        set
        {

        }
    }

    public static int SelectedJacket
    {
        get
        {
            return 0;
        }
        set
        {

        }
    }

    public static int SelectedShoe
    {
        get
        {
            return 0;
        }
        set
        {

        }
    }

    public int SetPrice
    {
        set
        {
            _price = value;
        }
    }
}
