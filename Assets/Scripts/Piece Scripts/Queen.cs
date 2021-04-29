using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
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

        int compareX = PositionX - newX;
        int compareZ = PositionZ - newZ;

        // Check for diagonal movement
        if ((compareX == compareZ) || (compareX == -compareZ))
            return true;

        return false;
    }

    public override bool[,] ArrayOfValidMove()
    {
      bool[,] array = new bool[8,8];

      Piece otherPiece;
      int i;
      int j;

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

      //Scan up from current square
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

      //Scan Down from current square
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

      //Top Left
      i = PositionX;
      j = PositionZ;
      while(true)
      {
          i--;
          j++;
          if(!ValidMove(i,j)) //checks to make sure it doesnt go off the board
              break;


          otherPiece = BoardManager.Instance.Pieces[i, j];

          if (otherPiece == null) //If there is no piece and its a valid move
              array[i, j] = true;
          else
          {
              if(otherPiece.isWhite != isWhite) //If the piece belongs to the other player and its a valid move
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
          if(!ValidMove(i,j)) //checks to make sure it doesnt go off the board
              break;


          otherPiece = BoardManager.Instance.Pieces[i, j];

          if (otherPiece == null) //If there is no piece and its a valid move
              array[i, j] = true;
          else
          {
              if(otherPiece.isWhite != isWhite) //If the piece belongs to the other player and its a valid move
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
          if(!ValidMove(i,j)) //checks to make sure it doesnt go off the board
              break;


          otherPiece = BoardManager.Instance.Pieces[i, j];

          if (otherPiece == null) //If there is no piece and its a valid move
              array[i, j] = true;
          else
          {
              if(otherPiece.isWhite != isWhite) //If the piece belongs to the other player and its a valid move
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
          if(!ValidMove(i,j)) //checks to make sure it doesnt go off the board
              break;


          otherPiece = BoardManager.Instance.Pieces[i, j];

          if (otherPiece == null) //If there is no piece and its a valid move
              array[i, j] = true;
          else
          {
              if(otherPiece.isWhite != isWhite) //If the piece belongs to the other player and its a valid move
                  array[i, j] = true;
              break;
          }
      }

      return array;
    }

}
