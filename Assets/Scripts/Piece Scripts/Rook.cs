using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override bool ValidMove(int newX, int newZ)
    {
        // If  newX and newZ are off the board
        if (newX < 0 || newX > 7)
            return false;
        if (newZ < 0 || newZ > 7)
            return false;
        
        // If rank stays the same
        if (PositionX == newX)
            return true;
        
        // If file stays the same
        if (PositionZ == newZ)
            return true;

        // Otherwise it's an invalid move
        else
            return false;
    }

    //Fills a double dim array of booleans indicating all possible moves
    public override bool[,] ArrayOfValidMove()
    {
        bool[,] array = new bool[8,8];

        Piece otherPiece;

        int i, j;

        for(i = 0; i < 8; i++)
        {
            for(j = 0; j < 8; j++)
            {
                array[i,j] = false; //Fill the array with false
            }
        }


        //Scan right from current square
        for(i = PositionX + 1; i < 8; i++)
        {
            otherPiece = BoardManager.Instance.Pieces[i, PositionZ]; //Get piece at possible square
            
            if (otherPiece == null  && ValidMove(i, PositionZ)) //If there is no piece and its a valid move
                array[i, PositionZ] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite && ValidMove(i, PositionZ)) //If the piece belongs to the other player and its a valid move
                    array[i, PositionZ] = true;
                break;
            }
        }

        //Scan left from current square
        for(i = PositionX - 1; i >= 0; i--)
        {
            otherPiece = BoardManager.Instance.Pieces[i, PositionZ]; //Get piece at possible square

            if (otherPiece == null && ValidMove(i, PositionZ)) //If there is no piece and its a valid move
                array[i, PositionZ] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite && ValidMove(i, PositionZ)) //If the piece belongs to the other player and its a valid move
                    array[i, PositionZ] = true;
                break;
            }
        }

        //Scan left from current square
        for(i = PositionZ + 1; i < 8; i++)
        {
            otherPiece = BoardManager.Instance.Pieces[PositionX, i]; //Get piece at possible square

            if (otherPiece == null && ValidMove(PositionX, i)) //If there is no piece and its a valid move
                array[PositionX, i] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite && ValidMove(PositionX, i)) //If the piece belongs to the other player and its a valid move
                    array[PositionX, i] = true;
                break;
            }
        }

        //Scan left from current square
        for(i = PositionZ - 1; i >= 0; i--)
        {
            otherPiece = BoardManager.Instance.Pieces[PositionX, i]; //Get piece at possible square

            if (otherPiece == null && ValidMove(PositionX, i)) //If there is no piece and its a valid move
                array[PositionX, i] = true;
            else   
            {
                if(otherPiece.isWhite != isWhite && ValidMove(PositionX, i)) //If the piece belongs to the other player and its a valid move
                    array[PositionX, i] = true;
                break;
            }
        }

        return array;
    }
}

