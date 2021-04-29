using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NSubstitute;

namespace Tests
{
    public class ButtonTests
    {
        [SetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Chess");
        }

        [UnityTest]
        public IEnumerator TestButtonCanSpawnPieceInEmptySpot()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
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
        }

        [UnityTest]
        public IEnumerator TestButtonWillNotSpawnPieceInOccupiedSpot()
        {
            GameObject go = new GameObject();
            PawnButton button = go.AddComponent<PawnButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose e1
            Assert.NotNull(board.Pieces[4, 0]);
            board.emptySelectionX = 4;
            board.emptySelectionZ = 0;
            Piece original = board.Pieces[4, 0];

            // It is white's turn and they have sufficient coins
            board.isWhiteTurn = true;
            Coin.WhiteCoins = 9;

            button.SpawnAPiece();
            // Piece is still original pawn and not a new spawned piece
            Assert.AreEqual(original, board.Pieces[4, 0]);
        }

        [UnityTest]
        public IEnumerator TestButtonWillNotSpawnWithoutEnoughCoins()
        {
            GameObject go = new GameObject();
            RookButton button = go.AddComponent<RookButton>();
            button.button = go.AddComponent<Button>();
            button.Cost = 5;

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose a2
            Assert.Null(board.Pieces[0, 1]);
            board.emptySelectionX = 0;
            board.emptySelectionZ = 1;

            // It is white's turn and they do not have sufficient coins
            board.isWhiteTurn = true;
            Coin.WhiteCoins = 0;

            button.SpawnAPiece();
            Assert.Null(board.Pieces[0, 1]);
        }

        [UnityTest]
        public IEnumerator TestCoinDeductionWithPurchase()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();
            button.Cost = 9;

            BoardManager board = BoardManager.Instance;

            yield return null;

            // It is black's turn and they have sufficient coins
            board.isWhiteTurn = false;
            Coin.BlackCoins = 9;
            Assert.AreEqual(9, Coin.BlackCoins);

            // Choose f8
            Assert.Null(board.Pieces[5, 7]);
            board.emptySelectionX = 5;
            board.emptySelectionZ = 7;

            button.SpawnAPiece();
            // Piece is spawned in selected empty spot
            Assert.NotNull(board.Pieces[5, 7]);
            Assert.AreEqual(0, Coin.BlackCoins);
        }

        [UnityTest]
        public IEnumerator TestWhitePlayerCannotPlacePowerupPiecePastSecondRow()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose a3
            Assert.Null(board.Pieces[0, 2]);
            board.emptySelectionX = 0;
            board.emptySelectionZ = 2;

            // It is white's turn and they have sufficient coins
            board.isWhiteTurn = true;
            Coin.WhiteCoins = 15;

            button.SpawnAPiece();
            // Piece is spawned in selected empty spot
            Assert.Null(board.Pieces[0, 2]);
        }

        [UnityTest]
        public IEnumerator TestWhitePlayerCanPlacePowerupPieceInFirstTwoRows()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose g2
            Assert.Null(board.Pieces[6, 1]);
            board.emptySelectionX = 6;
            board.emptySelectionZ = 1;

            // It is white's turn and they have sufficient coins
            board.isWhiteTurn = true;
            Coin.WhiteCoins = 15;

            button.SpawnAPiece();
            // Piece is spawned in selected empty spot
            Assert.NotNull(board.Pieces[6, 1]);
        }

        [UnityTest]
        public IEnumerator TestBlackPlayerCannotPlacePowerupPieceBelowLastTwoRows()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose f6
            Assert.Null(board.Pieces[5, 5]);
            board.emptySelectionX = 5;
            board.emptySelectionZ = 5;

            // It is white's turn and they have sufficient coins
            board.isWhiteTurn = false;
            Coin.BlackCoins = 15;

            button.SpawnAPiece();
            // Piece is spawned in selected empty spot
            Assert.Null(board.Pieces[5, 5]);
        }

        [UnityTest]
        public IEnumerator TestBlackPlayerCanPlacePowerupPieceInLastTwoRows()
        {
            GameObject go = new GameObject();
            PawnButton button = go.AddComponent<PawnButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            // Choose c7
            Assert.Null(board.Pieces[2, 6]);
            board.emptySelectionX = 2;
            board.emptySelectionZ = 6;

            // It is black's turn and they have sufficient coins
            board.isWhiteTurn = false;
            Coin.WhiteCoins = 15;

            button.SpawnAPiece();
            // Piece is spawned in selected empty spot
            Assert.NotNull(board.Pieces[2, 6]);
        }

        // Test Piece Buttons Spawn Correct Piece
        // Queen
        [UnityTest]
        public IEnumerator TestQueenButtonSpawnsQueen()
        {
            GameObject go = new GameObject();
            QueenButton button = go.AddComponent<QueenButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.Null(board.Pieces[3, 7]);
            board.emptySelectionX = 3;
            board.emptySelectionZ = 7;

            // It is black's turn and they have sufficient coins
            board.isWhiteTurn = false;
            Coin.BlackCoins = 9;

            button.SpawnAPiece();
            Assert.IsInstanceOf(typeof(Queen), board.Pieces[3, 7]);
        }

        // Rook
        [UnityTest]
        public IEnumerator TestRookButtonSpawnsRook()
        {
            GameObject go = new GameObject();
            RookButton button = go.AddComponent<RookButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.Null(board.Pieces[6, 1]);
            board.emptySelectionX = 6;
            board.emptySelectionZ = 1;

            board.isWhiteTurn = true;
            Coin.WhiteCoins = 5;

            button.SpawnAPiece();
            Assert.IsInstanceOf(typeof(Rook), board.Pieces[6, 1]);
        }

        // Knight
        [UnityTest]
        public IEnumerator TestKnightButtonSpawnsKnight()
        {
            GameObject go = new GameObject();
            KnightButton button = go.AddComponent<KnightButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.Null(board.Pieces[6, 6]);
            board.emptySelectionX = 6;
            board.emptySelectionZ = 6;

            board.isWhiteTurn = false;
            Coin.BlackCoins = 3;

            button.SpawnAPiece();
            Assert.IsInstanceOf(typeof(Knight), board.Pieces[6, 6]);
        }

        // Bishop
        [UnityTest]
        public IEnumerator TestBishopButtonSpawnsBishop()
        {
            GameObject go = new GameObject();
            BishopButton button = go.AddComponent<BishopButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.Null(board.Pieces[6, 0]);
            board.emptySelectionX = 6;
            board.emptySelectionZ = 0;

            board.isWhiteTurn = true;
            Coin.WhiteCoins = 3;

            button.SpawnAPiece();
            Assert.IsInstanceOf(typeof(Bishop), board.Pieces[6, 0]);
        }

        // Pawn
        [UnityTest]
        public IEnumerator TestPawnButtonSpawnsPawn()
        {
            GameObject go = new GameObject();
            PawnButton button = go.AddComponent<PawnButton>();
            button.button = go.AddComponent<Button>();

            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.Null(board.Pieces[7, 7]);
            board.emptySelectionX = 7;
            board.emptySelectionZ = 7;

            board.isWhiteTurn = false;
            Coin.BlackCoins = 1;

            button.SpawnAPiece();
            Assert.IsInstanceOf(typeof(Pawn), board.Pieces[7, 7]);
        }

        [UnityTest]
        public IEnumerator TestEconomyWinButton()
        {
            GameObject go = new GameObject();
            EconomyWinButton button = go.AddComponent<EconomyWinButton>();
            button.button = go.AddComponent<Button>();
            button.Cost = 30;

            BoardManager board = BoardManager.Instance;

            yield return null;

            // It is black's turn and they have sufficient coins
            board.isWhiteTurn = false;
            Coin.BlackCoins = 33;

            button.PurchaseAWin();
            Assert.False(board.isGameActive);
        }

        [UnityTest]
        public IEnumerator TestExtraTurnButton1AddsOneTurnsForHeads()
        {
            CoinFlip quarter = new CoinFlip();
            int result = 0; // heads = 1 extra turn

            BoardManager board = BoardManager.Instance;

            yield return null;

            board.isWhiteTurn = true;

            quarter.OneExtraTurn(result);
            Assert.AreEqual(1, CoinFlip.extraWhiteTurn);
        }

        [UnityTest]
        public IEnumerator TestExtraTurnButton1AddsZeroTurnsForTails()
        {
            CoinFlip quarter = new CoinFlip();
            int result = 1; // tails = 0 extra turns

            BoardManager board = BoardManager.Instance;

            yield return null;

            board.isWhiteTurn = false;

            quarter.OneExtraTurn(result);
            Assert.AreEqual(0, CoinFlip.extraBlackTurn);
        }

        [UnityTest]
        public IEnumerator TestExtraTurnButton2AddsTwoTurnsForHeads()
        {
            CoinFlip quarter = new CoinFlip();
            int result = 0; // heads = 2 extra turns

            BoardManager board = BoardManager.Instance;

            yield return null;

            board.isWhiteTurn = true;

            quarter.TwoExtraTurns(result);
            Assert.AreEqual(2, CoinFlip.extraWhiteTurn);
        }

        [UnityTest]
        public IEnumerator TestExtraTurnButton2AddsOneTurnForTails()
        {
            CoinFlip quarter = new CoinFlip();
            int result = 1; // tails = 1 extra turn

            BoardManager board = BoardManager.Instance;

            yield return null;

            board.isWhiteTurn = false;

            quarter.TwoExtraTurns(result);
            Assert.AreEqual(1, CoinFlip.extraBlackTurn);
        }

        [UnityTest]
        public IEnumerator TestBishopButtonRemoves4CoinsFromPlayer()
        {
            GameObject go = new GameObject();
            BishopButton button = go.AddComponent<BishopButton>();
            button.button = go.AddComponent<Button>();
            button.Cost = 4;

            BoardManager board = BoardManager.Instance;

            yield return null;

            Assert.Null(board.Pieces[2, 0]);
            board.emptySelectionX = 2;
            board.emptySelectionZ = 0;

            board.isWhiteTurn = true;
            Coin.WhiteCoins = 4;

            button.SpawnAPiece();
            Assert.AreEqual(0, Coin.WhiteCoins);
        }
    }
}
