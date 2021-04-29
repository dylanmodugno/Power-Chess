using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFlip : MonoBehaviour
{
    public Image quarterImage;
    public Sprite[] sides;
    public static int extraWhiteTurn;
    public static int extraBlackTurn;
    public static bool whitePurchased = false;
    public static bool blackPurchased = false;
    System.Random random = new System.Random();

    public int ShowCoin()
    {
        int result = random.Next(0, 2);
        quarterImage.sprite = sides[result];

        return result;
    }

    // Add either two or one extra turns per coin flip
    public void TwoExtraTurns(int result)
    {
        BoardManager board = BoardManager.Instance;

        // Heads = 2 extra turns
        if (result == 0)
        {
            if (board.isWhiteTurn)
            {
                extraWhiteTurn = 2;
            }
            else
                extraBlackTurn = 2;
        }

        // Tails = 1 extra turn
        if (result == 1)
        {
            if (board.isWhiteTurn)
            {
                extraWhiteTurn = 1;
            }
            else
                extraBlackTurn = 1;
        }
    }

    // Add either one or zero extra turns per coin flip
    public void OneExtraTurn(int result)
    {
        BoardManager board = BoardManager.Instance;

        // Heads = 1 extra turn
        if (result == 0)
        {
            if (board.isWhiteTurn)
            {
                extraWhiteTurn = 1;
            }
            else
                extraBlackTurn = 1;
        }

        // Tails = 0 extra turns
        if (result == 1)
        {
            if (board.isWhiteTurn)
            {
                extraWhiteTurn = 0;
            }
            else
                extraBlackTurn = 0;
        }
    }
}
