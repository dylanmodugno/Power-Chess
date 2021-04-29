using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override bool ValidMove(int newX, int newZ)
    {
      // If  newX and newZ are off the board
      if (newX < 0 || newX > 7)
        return false;
      if (newZ < 0 || newZ > 7)
        return false;

      // left 1, up 2
      if (PositionX - 1 == newX && PositionZ + 2 == newZ)
        return true;

      // right 1, up 2
      if (PositionX + 1 == newX && PositionZ + 2 == newZ)
        return true;

      // right 2, up 1
      if (PositionX + 2 == newX && PositionZ + 1 == newZ)
        return true;

      // right 2, down 1
      if (PositionX + 2 == newX && PositionZ - 1 == newZ)
        return true;

      // right 1, down 2
      if (PositionX + 1 == newX && PositionZ - 2 == newZ)
        return true;

      // left 1, down 2
      if (PositionX - 1 == newX && PositionZ - 2 == newZ)
        return true;

      // left 2, down 1
      if (PositionX - 2 == newX && PositionZ - 1 == newZ)
        return true;

      // left 2, up 1
      if (PositionX - 2 == newX && PositionZ + 1 == newZ)
        return true;

      return false;
    }

    //Fills a double dim array of booleans indicating all possible moves
    public override bool[,] ArrayOfValidMove()
    {
        bool [,] array = new bool[8,8];
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                KnightMove(i, j, ref array);
            }
        }
        return array;
    }

    //Given an x, z, and array of booleans check to if that move is possible
    public void KnightMove(int x, int z, ref bool[,] array)
    {
        Piece otherPiece;
        if (ValidMove(x, z))
        {
            otherPiece = BoardManager.Instance.Pieces[x,z];
            if(otherPiece == null)
            {
                array[x, z] = true;
            }
            else if(isWhite != otherPiece.isWhite)
            {
                array[x, z] = true;
            }
        }
    }
}
