using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RandomPieceButton : ButtonScript
{
    public Button button;
    public int Cost;
    public int randomWhite;
    public int randomBlack;
    Random rand = new Random();

    void Update()
    {
        BoardManager board = BoardManager.Instance;

        if (board.isWhiteTurn)
        {
            if (Coin.WhiteCoins < Cost)
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
            if (Coin.BlackCoins < Cost)
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
        if ((isWhiteTurn && Coin.WhiteCoins >= this.Cost) || (!isWhiteTurn && Coin.BlackCoins >= this.Cost))
        {
            // generate random white piece and spawn
            if (isWhiteTurn)
            {
                randomWhite = rand.Next(1, 5);
                BoardManager.Instance.SpawnChessPiece(randomWhite, x, z);
            }
            // generate random black piece and spawn
            else
            {
                randomBlack = rand.Next(7, 11);
                BoardManager.Instance.SpawnChessPiece(randomBlack, x, z);
            }

            // deduct coins from purchase
            Coin.RemoveCoins(isWhiteTurn, this.Cost);

            BoardManager.Instance.Pieces[x, z].justPurchased = true;
        }
    }
}
