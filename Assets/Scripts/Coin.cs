using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text playersCoins;

    public static int WhiteCoins { get; set; }
    public static int BlackCoins { get; set; }

    void Update()
    {
        playersCoins.text = "Coins \n\t\t" + WhiteCoins + "\n\t\t" + BlackCoins;
    }

    public static void AddCoin(bool isWhiteTurn)
    {
        if (isWhiteTurn)
            WhiteCoins++;
        else
            BlackCoins++;
    }

    public static void RemoveCoins(bool isWhiteTurn, int numCoins)
    {
        if (isWhiteTurn)
            WhiteCoins -= numCoins;
        else
            BlackCoins -= numCoins;
    }
}
