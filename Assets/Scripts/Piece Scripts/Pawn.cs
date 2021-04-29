using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override bool ValidMove(int newX, int newZ)
    {
        // If  newX and newZ are off the board
        if (newX < 0 || newX > 7)
            return false;
        if (newZ < 0 || newZ > 7)
            return false;

        if (isWhite)
        {
            // Starting position: Move up 2
            if (PositionZ == 1)
                if (PositionX == newX && PositionZ + 2 == newZ)
                    return true;

            // Move up 1
            if (PositionX == newX && PositionZ + 1 == newZ)
                return true;
        }
        else
        {
            // Starting position: Move down 2
            if (PositionZ == 6)
                if (PositionX == newX && PositionZ - 2 == newZ)
                    return true;

            // Move down 1
            if (PositionX == newX && PositionZ - 1 == newZ)
                return true;
        }

        return false;
    }

    public override bool[,] ArrayOfValidMove()
    {
        bool[,] array = new bool[8,8];
        Piece otherPiece;
        int i;
        int j;

        // Initialize array
        for(i = 0; i < 8; i++)
        {
            for(j = 0; j < 8; j++)
            {
                array[i, j] = false;
            }
        }

        if(isWhite)
        {
            // Scan in rows above
            for(j = PositionZ + 1; j < 8; j++)
            {
                otherPiece = BoardManager.Instance.Pieces[PositionX, j];

                if (otherPiece == null && ValidMove(PositionX, j))
                    array[PositionX, j] = true;
            }

            // Scan for diagonal opposing pieces to capture
            // Top right
            i = PositionX + 1;
            j = PositionZ + 1;
            // Check bounds
            if (i >= 0 && i < 8 && j >= 0 && j < 8)
            {
                otherPiece = BoardManager.Instance.Pieces[i, j];

                // Check if the other piece belongs to opposing player
                if (otherPiece != null && otherPiece.isWhite != isWhite)
                    array[i, j] = true;
            }

            // Top left
            i = PositionX - 1;
            j = PositionZ + 1;
            if (i >= 0 && i < 8 && j >= 0 && j < 8)
            {
                otherPiece = BoardManager.Instance.Pieces[i, j];

                if (otherPiece != null && otherPiece.isWhite != isWhite)
                    array[i, j] = true;
            }
        }

        else
        {
            // Scan in rows above
            for(j = PositionZ - 1; j >= 0; j--)
            {
                otherPiece = BoardManager.Instance.Pieces[PositionX, j];

                if (otherPiece == null && ValidMove(PositionX, j))
                    array[PositionX, j] = true;
            }

            // Scan for diagonal opposing pieces to capture
            // Top right
            i = PositionX + 1;
            j = PositionZ - 1;
            // Check bounds
            if (i >= 0 && i < 8 && j >= 0 && j < 8)
            {
                otherPiece = BoardManager.Instance.Pieces[i, j];

                // Check if the other piece belongs to opposing player
                if (otherPiece != null && otherPiece.isWhite != isWhite)
                    array[i, j] = true;
            }

            // Top left
            i = PositionX - 1;
            j = PositionZ - 1;
            if (i >= 0 && i < 8 && j >= 0 && j < 8)
            {
                otherPiece = BoardManager.Instance.Pieces[i, j];

                if (otherPiece != null && otherPiece.isWhite != isWhite)
                    array[i, j] = true;
            }
        }
        return array;
    }


}
