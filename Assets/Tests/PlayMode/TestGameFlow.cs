using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class TestGameFlow
    {
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Chess");
        }
        
        [UnityTest]
        public IEnumerator TestGetSquareCenter()
        {
            BoardManager board = BoardManager.Instance;

            yield return null;

            Vector3 whiteKingPosition = board.Pieces[4, 0].transform.position;
            Assert.AreEqual(whiteKingPosition, new Vector3(4.5f, 0, 0.5f));
        }

        [UnityTest]
        public IEnumerator TestStartingSelectionPosition()
        {
            BoardManager board = BoardManager.Instance;

            yield return null;

            // (SelectionX, SelectionZ) starts at (-1,-1)
            Assert.AreEqual(-1, board.selectionX);
            Assert.AreEqual(-1, board.selectionZ);
        }

        [UnityTest]
        public IEnumerator TestStartingBoardSpawnsKings()
        {
            BoardManager board = BoardManager.Instance;

            yield return null;

            // White King
            Assert.IsInstanceOf(typeof(King), actual: board.Pieces[4, 0]);
            // Black King
            Assert.IsInstanceOf(typeof(King), actual: board.Pieces[4, 7]);
        }

        [UnityTest]
        public IEnumerator TestStartingBoardSpawns3WhitePawns()
        {
            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.IsInstanceOf(typeof(Pawn), actual: board.Pieces[3, 1]); // d2
            Assert.True(board.Pieces[3, 1].isWhite);

            Assert.IsInstanceOf(typeof(Pawn), actual: board.Pieces[4, 1]); // e2
            Assert.True(board.Pieces[4, 1].isWhite);

            Assert.IsInstanceOf(typeof(Pawn), actual: board.Pieces[5, 1]); // f2
            Assert.True(board.Pieces[5, 1].isWhite);
        }

        [UnityTest]
        public IEnumerator TestStartingBoardSpawns3BlackPawns()
        {
            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.IsInstanceOf(typeof(Pawn), actual: board.Pieces[3, 6]); // d7
            Assert.False(board.Pieces[3, 6].isWhite);

            Assert.IsInstanceOf(typeof(Pawn), actual: board.Pieces[4, 6]); // e7
            Assert.False(board.Pieces[4, 6].isWhite);

            Assert.IsInstanceOf(typeof(Pawn), actual: board.Pieces[5, 6]); // f7
            Assert.False(board.Pieces[5, 6].isWhite);
        }

        [UnityTest]
        public IEnumerator TestPlayersStartWithThreeCoins()
        {
            BoardManager board = BoardManager.Instance;
            board.RestartGame();

            yield return null;

            Assert.AreEqual(3, Coin.WhiteCoins);
            Assert.AreEqual(3, Coin.BlackCoins);
        }

        [UnityTest]
        public IEnumerator TestWhitePlayerCannotPlaceInitialPiecesPastFirstTwoRows()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose a2
            Assert.Null(board.Pieces[0, 2]);
            board.emptySelectionX = 0;
            board.emptySelectionZ = 2;

            button.SpawnAPiece();
            // Piece is NOT spawned in selected empty spot
            Assert.Null(board.Pieces[0, 2]);
        }

        [UnityTest]
        public IEnumerator TestBlackPlayerCannotPlaceInitialPiecesBelowLastTwoRows()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose a2
            Assert.Null(board.Pieces[0, 5]);
            board.emptySelectionX = 0;
            board.emptySelectionZ = 5;

            board.isWhiteTurn = false;

            button.SpawnAPiece();
            // Piece is NOT spawned in selected empty spot
            Assert.Null(board.Pieces[0, 5]);
        }

        [UnityTest]
        public IEnumerator TestBuyMultiplePiecePowerupsInSameTurn()
        {
            GameObject go = new GameObject();
            PawnButton button = go.AddComponent<PawnButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose a2
            Assert.Null(board.Pieces[0, 1]);
            board.emptySelectionX = 0;
            board.emptySelectionZ = 1;

            // It is white's turn and they have sufficient coins
            board.isWhiteTurn = true;
            Coin.WhiteCoins = 9;

            button.SpawnAPiece();
            // Piece is spawned in selected empty spot
            Assert.NotNull(board.Pieces[0, 1]);

            // Choose b2
            Assert.Null(board.Pieces[1, 1]);
            board.emptySelectionX = 1;
            board.emptySelectionZ = 1;

            button.SpawnAPiece();
            // Another piece is spawned in selected empty spot
            Assert.NotNull(board.Pieces[0, 1]);
        }

        [UnityTest]
        public IEnumerator TestPlayerCanPurchaseOnlyOneCoinFlipPerTurn()
        {
            GameObject go = new GameObject();
            ExtraTurnButton button = go.AddComponent<ExtraTurnButton>();
            button.button = go.AddComponent<Button>();
            button.Cost = 10;
            button.Quarter = new GameObject();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // It is black's turn and they have sufficient coins
            board.isWhiteTurn = false;
            Coin.BlackCoins = 11;

            button.PurchaseTurnLogic(board.isWhiteTurn);
            Assert.True(CoinFlip.blackPurchased);
        }

        [UnityTest]
        public IEnumerator TestPlayerCannotMovePieceTheyJustPurchased()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose c1
            Assert.Null(board.Pieces[2, 0]);
            board.emptySelectionX = 2;
            board.emptySelectionZ = 0;

            button.SpawnAPiece();

            Assert.True(board.Pieces[2, 0].justPurchased);
            // (SelectionX, SelectionZ) starts at (-1,-1)
            Assert.AreEqual(-1, board.selectionX);
            Assert.AreEqual(-1, board.selectionZ);

        }

        [UnityTest]
        public IEnumerator TestBlackPawnInfiltrationEndsGame()
        {
            BoardManager board = BoardManager.Instance;

            yield return null;

            board.isWhiteTurn = false;
            board.SpawnChessPiece(11, 0, 0); // black pawn a1

            board.CheckIfInfiltrated();
            Assert.False(board.isGameActive);
        }

        [UnityTest]
        public IEnumerator TestWhitePawnInfiltrationEndsGame()
        {
            BoardManager board = BoardManager.Instance;

            yield return null;

            board.isWhiteTurn = true;
            board.SpawnChessPiece(5, 7, 7); // white pawn h8

            board.CheckIfInfiltrated();
            Assert.False(board.isGameActive);
        }
    }
}
