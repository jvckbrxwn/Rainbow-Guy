using UnityEngine;

public class CoinsManager
{
    private static int coins;

    public static void GetCoins()
    {
        Coins = (PlayerPrefs.HasKey("Coins")) ? PlayerPrefs.GetInt("Coins") : 10000;
    }

    public static void SaveCoins()
    {
        PlayerPrefs.Save();
    }

    public static void SetCoins(int value)
    {
        Coins += value;
        PlayerPrefs.SetInt("Coins", Coins);
    }

    public static int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
        }
    }
}
