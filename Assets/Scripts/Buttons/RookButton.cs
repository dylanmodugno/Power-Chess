using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RookButton : ButtonScript
{
    public Button button;
    public int Cost;

    void Update()
    {
        BoardManager board = BoardManager.Instance;

        if (board.isWhiteTurn)
        {
            if(Coin.WhiteCoins < Cost)
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
            if(Coin.BlackCoins < Cost)
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

    protected override void PurchasePiece(int x, int z, bool isWhiteTurn)
    {
        // Check for coins
        if ((isWhiteTurn && Coin.WhiteCoins >= Cost && z <= 1) || (!isWhiteTurn && Coin.BlackCoins >= Cost & z >=  6))
        {
            // spawn white rook
            if (isWhiteTurn)
                BoardManager.Instance.SpawnChessPiece(2, x, z);
            // spawn black rook
            else
                BoardManager.Instance.SpawnChessPiece(8, x, z);

            // deduct coins from purchase
            Coin.RemoveCoins(isWhiteTurn, Cost);

            BoardManager.Instance.Pieces[x, z].justPurchased = true;
        }
    }
}
