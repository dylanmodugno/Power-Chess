using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override bool ValidMove(int newX, int newZ)
    {
        // Check for diagonal movement
        int CompareX = 0, CompareZ = 0;

        // Return false for out-of-bounds
        if (newX < 0 || newX > 7)
            return false;
        if (newZ < 0 || newZ > 7)
            return false;

        // Find X comparison value
        CompareX = PositionX - newX;

        // Find Z comparison value
        CompareZ = PositionZ - newZ;

        // Check for valid diagonal movement
        if ((CompareX == CompareZ) || (CompareX == -CompareZ))
            return true;

        return false;
    }

    public override bool[,] ArrayOfValidMove()
    {
        bool[,] array = new bool[8,8];

        Piece otherPiece;
        int i;
        int j;

        //Top Left
        i = PositionX;
        j = PositionZ;
        while(true)
        {
            i--;
            j++;
            if(!ValidMove(i,j))
                break;

            otherPiece = BoardManager.Instance.Pieces[i, j];

            if (otherPiece == null)
                array[i, j] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite)
                    array[i, j] = true;
                break;
            }
        }

        //Top Right
        i = PositionX;
        j = PositionZ;
        while(true)
        {
            i++;
            j++;
            if(!ValidMove(i,j))
                break;

            otherPiece = BoardManager.Instance.Pieces[i, j];

            if (otherPiece == null)
                array[i, j] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite)
                    array[i, j] = true;
                break;
            }
        }

        //Bottom Left
        i = PositionX;
        j = PositionZ;
        while(true)
        {
            i--;
            j--;
            if(!ValidMove(i,j))
                break;

            otherPiece = BoardManager.Instance.Pieces[i, j];

            if (otherPiece == null)
                array[i, j] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite)
                    array[i, j] = true;
                break;
            }
        }

        //Bottom Right
        i = PositionX;
        j = PositionZ;
        while(true)
        {
            i++;
            j--;
            if(!ValidMove(i,j))
                break;

            otherPiece = BoardManager.Instance.Pieces[i, j];

            if (otherPiece == null)
                array[i, j] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite)
                    array[i, j] = true;
                break;
            }
        }

        return array;
    }
}
