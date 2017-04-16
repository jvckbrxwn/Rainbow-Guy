using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour {

    [SerializeField] private Text _text;
    [SerializeField] private GameObject _hatsPanel;
    [SerializeField] private GameObject _jacketsPanel;
    [SerializeField] private GameObject _shoesPanel;
    [SerializeField] private ToggleGroup _hatToggleGroup;
    [SerializeField] private ToggleGroup _jacketToggleGroup;
    [SerializeField] private ToggleGroup _shoeToggleGroup;
    [SerializeField] private Toggle[] _toggleHats;
    [SerializeField] private Toggle[] _toggleJacket;
    [SerializeField] private Toggle[] _toggleShoe;
    [SerializeField] private GameObject _buyThisPanel;
    [SerializeField] private Image _buyImage;
    [SerializeField] private Text _buyCostText;
    [SerializeField] private Button _applyButton;
    [SerializeField] private Button _cancelButton;

    private int _price, selectedHat, selectedJacket, selectedShoe;
    private List<int> unlockHats = new List<int>();
    private List<int> unlockJackets = new List<int>();
    private List<int> unlockShoes = new List<int>();

    private void Start()
    {
        Init();
    }

    /*private void OnEnable()
    {
        Init();
    }*/

    private void Init()
    {
        GetHats();
        GetJackets();
        GetShoes();
        GetHatIsOn();
        CoinsManager.GetCoins();
        UpdateTextCoins();
    }

    #region Hats
    public void BuyHatOne(int item)
    {
        if (_toggleHats[item].isOn)
        {
            UnlockHat(item);
            Debug.Log("Clicked: ");
        }
    }

    private void GetHats()
    {
        try
        {
            unlockHats.AddRange(PlayerPrefsX.GetIntArray("UnlockHat"));
            for (int i = 0; i < _toggleHats.Length; i++)
            {
                if (unlockHats.Contains(i))
                    _toggleHats[i].GetComponentInChildren<Text>().text = "exist";
            }
        }
        catch { }
    }

    private void UnlockHat(int item)
    {
        if (!unlockHats.Contains(item))
        {
            OpenBuyThisHat(item);
        }
        else
        {
            SelectedHat = item;
            PlayerPrefs.SetInt("SelectedHat", SelectedHat);
        }
    }

    private void OpenBuyThisHat(int item)
    {
        _buyImage.sprite = _toggleHats[item].GetComponent<Image>().sprite;
        _buyCostText.text = "it costs " +Price+ " coins";
        _buyThisPanel.SetActive(true);
        _applyButton.onClick.AddListener(() =>
        {
            unlockHats.Add(item);
            PlayerPrefsX.SetIntArray("UnlockHat", unlockHats.ToArray());
            CoinsManager.SetCoins(-Price);
            UpdateTextCoins();
            SelectedHat = item;
            PlayerPrefs.SetInt("SelectedHat", SelectedHat);
            _toggleHats[item].GetComponentInChildren<Text>().text = "exist";
            _buyThisPanel.SetActive(false);
            Debug.Log(Price);
            _applyButton.onClick.RemoveAllListeners();
        });
        _cancelButton.onClick.RemoveAllListeners();
        _cancelButton.onClick.AddListener(() =>
        {
            GetHatIsOn();
            _buyThisPanel.SetActive(false);
            _cancelButton.onClick.RemoveAllListeners();
        });
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
            unlockJackets.Sort();
            for (int i = 0; i < _toggleJacket.Length; i++)
            {
                if (unlockJackets.Contains(i))
                    _toggleJacket[i].GetComponentInChildren<Text>().text = "exist";
            }
        }
        catch { }
    }

    private void UnlockJacket(int item)
    {
        if (!unlockJackets.Contains(item))
        {
            OpenBuyThisJacket(item);
        }
        else
        {
            SelectedJacket = item;
            PlayerPrefs.SetInt("SelectedJacket", SelectedJacket);
        }
    }

    private void OpenBuyThisJacket(int item)
    {
        _buyImage.sprite = _toggleJacket[item].GetComponent<Image>().sprite;
        _buyCostText.text = "it costs " + Price + " coins";
        _buyThisPanel.SetActive(true);
        _applyButton.onClick.AddListener(() =>
        {
            unlockJackets.Add(item);
            PlayerPrefsX.SetIntArray("UnlockJacket", unlockJackets.ToArray());
            CoinsManager.SetCoins(-Price);
            UpdateTextCoins();
            _toggleJacket[item].GetComponentInChildren<Text>().text = "exist";
            SelectedJacket = item;
            PlayerPrefs.SetInt("SelectedJacket", SelectedJacket);
            _buyThisPanel.SetActive(false);
        });
        _cancelButton.onClick.AddListener(() =>
        {
            GetJacketIsOn();
            _buyThisPanel.SetActive(false);
        });
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
            unlockShoes.Sort();
            for (int i = 0; i < _toggleShoe.Length; i++)
            {
                if (unlockShoes.Contains(i))
                    _toggleShoe[i].GetComponentInChildren<Text>().text = "exist";
            }
        }
        catch { }
    }

    private void UnlockShoe(int item)
    {
        if (!unlockShoes.Contains(item))
        {
            OpenBuyThisShoe(item);
        }
        else
        {
            SelectedShoe = item;
            PlayerPrefs.SetInt("SelectedShoe", SelectedShoe);
        }
    }

    private void OpenBuyThisShoe(int item)
    {
        _buyImage.sprite = _toggleShoe[item].GetComponent<Image>().sprite;
        _buyCostText.text = "it costs " + Price + " coins";
        _buyThisPanel.SetActive(true);
        _applyButton.onClick.AddListener(() =>
        {
            unlockShoes.Add(item);
            SelectedShoe = item;
            CoinsManager.SetCoins(-Price);
            UpdateTextCoins();
            _toggleShoe[item].GetComponentInChildren<Text>().text = "exist";
            PlayerPrefs.SetInt("SelectedShoe", SelectedShoe);
            PlayerPrefsX.SetIntArray("UnlockShoe", unlockShoes.ToArray());
            _buyThisPanel.SetActive(false);
        });
        _cancelButton.onClick.AddListener(() =>
        {
            GetShoeIsOn();
            _buyThisPanel.SetActive(false);
        });
    }
    #endregion

    #region ButtonsToOpen
    public void OpenHats()
    {
        GetHatIsOn();
        _hatsPanel.SetActive(true);
        if (_jacketsPanel.activeSelf)
            _jacketsPanel.SetActive(false);
        if (_shoesPanel.activeSelf)
            _shoesPanel.SetActive(false);
    }

    public void OpenJackets()
    {
        GetJacketIsOn();
        _jacketsPanel.SetActive(true);
        if (_hatsPanel.activeSelf)
            _hatsPanel.SetActive(false);
        if (_shoesPanel.activeSelf)
            _shoesPanel.SetActive(false);
    }

    public void OpenShoes()
    {
        GetShoeIsOn();
        _shoesPanel.SetActive(true);
        if (_hatsPanel.activeSelf)
            _hatsPanel.SetActive(false);
        if (_jacketsPanel.activeSelf)
            _jacketsPanel.SetActive(false);
    }
    #endregion

    #region Get PlayerPrefs Items To "Active" Toggle
    private void GetHatIsOn()
    {
        if (PlayerPrefs.HasKey("SelectedHat"))
        {
            _toggleHats[PlayerPrefs.GetInt("SelectedHat")].isOn = true;
        }
    }

    private void GetJacketIsOn()
    {
        if (PlayerPrefs.HasKey("SelectedJacket"))
        {
            _toggleJacket[PlayerPrefs.GetInt("SelectedJacket")].isOn = true;
        }
    }

    private void GetShoeIsOn()
    {
        if (PlayerPrefs.HasKey("SelectedShoe"))
        {
            _toggleShoe[PlayerPrefs.GetInt("SelectedShoe")].isOn = true;
        }
    }
    #endregion

    #region "Selected" Properties & Set Price
    public int SelectedHat
    {
        set
        {
            selectedHat = value;
        }
        get
        {
            return selectedHat;
        }
    }

    public int SelectedJacket
    {
        get
        {
            return selectedJacket;
        }
        set
        {
            selectedJacket = value;
        }
    }

    public int SelectedShoe
    {
        get
        {
            return selectedJacket;
        }
        set
        {
            selectedJacket = value;
        }
    }

    public int Price
    {
        set
        {
            _price = value;
        }
        get
        {
            return _price;
        }
    }
    #endregion

    private void UpdateTextCoins()
    {
        _text.text = "Coins: " + CoinsManager.Coins.ToString();
    }
}
