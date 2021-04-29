using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class TestPieceMoves
    {
        [SetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Chess");
        }

        // Pawn
        [UnityTest]
        public IEnumerator TestWhitePawnArrayOfValidMovesAtStartingPosition()
        {
            GameObject go = new GameObject();
            PawnButton button = go.AddComponent<PawnButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray;

            yield return null;

            board.emptySelectionX = 0;
            board.emptySelectionZ = 1;
            button.SpawnAPiece();

            expectedArray = new bool[8, 8];
            expectedArray[0, 2] = true;
            expectedArray[0, 3] = true;

            Piece whitePawn = board.Pieces[0, 1];
            Assert.AreEqual(expectedArray, whitePawn.ArrayOfValidMove());
        }

        [UnityTest]
        public IEnumerator TestBlackPawnArrayOfValidMovesAtStartingPosition()
        {
            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray;

            yield return null;

            board.SpawnChessPiece(11, 7, 6);

            expectedArray = new bool[8, 8];
            expectedArray[7, 5] = true;
            expectedArray[7, 4] = true;

            Piece blackPawn = board.Pieces[7, 6];
            Assert.AreEqual(expectedArray, blackPawn.ArrayOfValidMove());
        }

        [UnityTest]
        public IEnumerator TestPawnArrayOfValidMovesCapture()
        {
            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray;

            yield return null;

            // Set white pawn at d4
            board.SpawnChessPiece(5, 3, 3);

            // Set black pawn at e5
            board.SpawnChessPiece(11, 4, 4);

            expectedArray = new bool[8, 8];
            expectedArray[3, 4] = true;
            expectedArray[4, 4] = true;
            Assert.AreEqual(expectedArray, board.Pieces[3, 3].ArrayOfValidMove()); // test white pawn

            expectedArray = new bool[8, 8];
            expectedArray[4, 3] = true;
            expectedArray[3, 3] = true;
            Assert.AreEqual(expectedArray, board.Pieces[4, 4].ArrayOfValidMove()); // test black pawn
        }

        // Rook
        [UnityTest]
        public IEnumerator TestRookArrayOfValidMovesCanMove()
        {
            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray = new bool[8, 8];

            yield return null;

            board.SpawnChessPiece(8, 0, 7); // Black rook at a8
            board.SpawnChessPiece(7, 0, 5); // Black queen at a6
            board.SpawnChessPiece(7, 2, 7); // Black queen at c8

            expectedArray[0, 6] = true;
            expectedArray[1, 7] = true;

            Piece blackRook = board.Pieces[0, 7];
            Assert.AreEqual(expectedArray, blackRook.ArrayOfValidMove());
        }

        // Knight
        [UnityTest]
        public IEnumerator TestKnightArrayOfValidMovesCanCapture()
        {
            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray = new bool[8, 8];

            yield return null;

            // Move black queen in path of white knight.
            board.SpawnChessPiece(7, 2, 2); // Black Queen c3
            board.SpawnChessPiece(4, 1, 0); // White Knight b1

            expectedArray[0, 2] = true;
            expectedArray[2, 2] = true;
            // expectedArray[3, 1] = true;

            Piece whiteKnight = board.Pieces[1, 0];
            Assert.AreEqual(expectedArray, whiteKnight.ArrayOfValidMove());
        }

        // Bishop
        [UnityTest]
        public IEnumerator TestBishopArrayOfValidMovesCanMove()
        {
            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray = new bool[8, 8];

            yield return null;

            board.SpawnChessPiece(9, 5, 7); // Black Bishop f8
            board.SpawnChessPiece(11, 4, 6); // Black Pawn e7

            expectedArray[6, 6] = true;
            expectedArray[7, 5] = true;

            Piece blackBishop = board.Pieces[5, 7];
            Assert.AreEqual(expectedArray, blackBishop.ArrayOfValidMove());
        }

        // Queen
        [UnityTest]
        public IEnumerator TestQueenArrayOfValidMovesCanCapture()
        {
            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray = new bool[8, 8];

            yield return null;

            board.SpawnChessPiece(1, 3, 0); // White Queen d1
            board.SpawnChessPiece(5, 3, 1); // White Pawn d2
            board.SpawnChessPiece(5, 4, 1); // White Pawn e2
            board.SpawnChessPiece(3, 2, 0); // White Bishop c1
            board.SpawnChessPiece(7, 1, 2); // Black Queen b3

            expectedArray[2, 1] = true;
            expectedArray[1, 2] = true;

            Piece whiteQueen = board.Pieces[3, 0];
            Assert.AreEqual(expectedArray, whiteQueen.ArrayOfValidMove());
        }

        // King
        [UnityTest]
        public IEnumerator TestKingArrayOfValidMovesCanMove()
        {
            BoardManager board = BoardManager.Instance;
            bool[,] expectedArray = new bool[8, 8];

            yield return null;

            // Move white king up one. King can now move in any direction.
            board.Pieces[4, 0].SetPosition(4, 1);
            board.Pieces[4, 1] = board.Pieces[4, 0];
            board.Pieces[4, 0] = null;

            expectedArray[3, 0] = true;
            expectedArray[4, 0] = true;
            expectedArray[5, 0] = true;
            // expectedArray[3, 1] = true;
            // expectedArray[5, 1] = true;
            expectedArray[3, 2] = true;
            expectedArray[4, 2] = true;
            expectedArray[5, 2] = true;

            Piece whiteKing = board.Pieces[4, 1];
            Assert.AreEqual(expectedArray, whiteKing.ArrayOfValidMove());
        }
    }
}
