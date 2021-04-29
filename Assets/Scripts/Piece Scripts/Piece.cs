using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public int PositionX { get; set; }
    public int PositionZ { get; set; }

    public bool isWhite;
    public bool justPurchased = false;

    public void SetPosition(int x, int z)
    {
        PositionX = x;
        PositionZ = z;
    }

    public void DeletePiece(Piece piece)
    {
      piece = null;
    }

    public abstract bool ValidMove(int newX, int newZ);

    public abstract bool[,] ArrayOfValidMove();
}
