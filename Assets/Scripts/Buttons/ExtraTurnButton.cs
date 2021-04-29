using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraTurnButton : MonoBehaviour
{
    public GameObject Quarter;
    public Button button;
    public int Cost;

    public bool showCoin = true;

    void Update()
    {
        BoardManager board = BoardManager.Instance;

        if (board.isWhiteTurn)
        {
            if (Coin.WhiteCoins < Cost || CoinFlip.whitePurchased == true)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(255, 100, 100, 255);
                button.colors = colors;
            }
            else
            {
                ColorBlock colors = button.colors;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(60, 200, 50, 255);
                button.colors = colors;
            }
        }
        else
        {
            if (Coin.BlackCoins < Cost || CoinFlip.blackPurchased == true)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(255, 100, 100, 255);
                button.colors = colors;
            }
            else
            {
                ColorBlock colors = button.colors;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(60, 200, 50, 255);
                button.colors = colors;
            }
        }
    }

    public void PurchaseExtraTurn()
    {
        BoardManager board = BoardManager.Instance;

        //Check for coins
        if ((board.isWhiteTurn && Coin.WhiteCoins >= Cost && CoinFlip.whitePurchased == false) || 
            (!board.isWhiteTurn && Coin.BlackCoins >= Cost && CoinFlip.blackPurchased == false))
        {
            // Make coin visible
            if (showCoin == true)
                StartCoroutine(ShowAndHide(Quarter, 3.0f)); // 3 seconds

            // Implement coin flip
            int result = Quarter.GetComponent<CoinFlip>().ShowCoin();

            if (this.Cost == 5)
                Quarter.GetComponent<CoinFlip>().OneExtraTurn(result);
            else if (this.Cost == 10)
                Quarter.GetComponent<CoinFlip>().TwoExtraTurns(result);

            PurchaseTurnLogic(board.isWhiteTurn);
        }
    }

    public void PurchaseTurnLogic(bool isWhiteTurn)
    {
        // Deduct coins from purchase
        Coin.RemoveCoins(isWhiteTurn, Cost);

        if (isWhiteTurn)
            CoinFlip.whitePurchased = true;
        else
            CoinFlip.blackPurchased = true;
    }

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
}
