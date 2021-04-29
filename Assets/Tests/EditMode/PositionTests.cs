using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PositionTests
    {
        // Pawn Tests:
        [Test]
        public void TestPawnWithValidOpeningMove()
        {
            var gameObject = new GameObject();
            var pawn = gameObject.AddComponent<Pawn>();

            pawn.isWhite = true;
            pawn.SetPosition(3, 1);
            Assert.AreEqual(pawn.ValidMove(3, 3), true);
        }

        [Test]
        public void TestPawnWithValidMove()
        {
            var gameObject = new GameObject();
            var pawn = gameObject.AddComponent<Pawn>();

            pawn.isWhite = false;
            pawn.SetPosition(0, 6);
            Assert.AreEqual(pawn.ValidMove(0, 5), true);
        }

        [Test]
        public void TestPawnWithInvalidMove()
        {
            var gameObject = new GameObject();
            var pawn = gameObject.AddComponent<Pawn>();

            pawn.isWhite = true;
            pawn.SetPosition(4, 3);
            Assert.AreEqual(pawn.ValidMove(4, 5), false);
        }

        [Test]
        public void TestPawnWithMoveOffTheBoard()
        {
            var gameObject = new GameObject();
            var pawn = gameObject.AddComponent<Pawn>();

            pawn.isWhite = true;
            pawn.SetPosition(7, 7);
            Assert.AreEqual(pawn.ValidMove(7, 8), false);
        }

        //Rook Tests:
        [Test]
        public void TestRookWithValidMove()
        {
            var gameObject = new GameObject();
            var rook = gameObject.AddComponent<Rook>();

            rook.SetPosition(2, 2);
            Assert.AreEqual(rook.ValidMove(2, 4), true);
            Assert.AreEqual(rook.ValidMove(5, 2), true);
        }

        [Test]
        public void TestRookWithInvalidMove()
        {
            var gameObject = new GameObject();
            var rook = gameObject.AddComponent<Rook>();

            rook.SetPosition(2, 2);
            Assert.AreEqual(rook.ValidMove(3, 3), false);
        }

        [Test]
        public void TestRookWithMoveOffTheBoard()
        {
            var gameObject = new GameObject();
            var rook = gameObject.AddComponent<Rook>();

            rook.SetPosition(2, 2);
            Assert.AreEqual(rook.ValidMove(9, 0), false);
        }

        // Knight Tests:
        [Test]
        public void TestKnightWithValidMove()
        {
            var gameObject = new GameObject();
            var knight = gameObject.AddComponent<Knight>();

            knight.SetPosition(2, 2);
            Assert.AreEqual(knight.ValidMove(3, 4), true);
        }

        [Test]
        public void TestKnightWithInvalidMove()
        {
            var gameObject = new GameObject();
            var knight = gameObject.AddComponent<Knight>();

            knight.SetPosition(1, 0);
            Assert.AreEqual(knight.ValidMove(2, 4), false);
        }

        [Test]
        public void TestKnightWithMoveOffTheBoard()
        {
            var gameObject = new GameObject();
            var knight = gameObject.AddComponent<Knight>();

            knight.SetPosition(1, 0);
            Assert.AreEqual(knight.ValidMove(-1, 0), false);
        }

        // Bishop Tests
        [Test]
        public void TestBishopWithValidMove()
        {
            var gameObject = new GameObject();
            var Bishop = gameObject.AddComponent<Bishop>();

            Bishop.SetPosition(4, 5);
            Assert.AreEqual(Bishop.ValidMove(1, 2), true);
        }

        [Test]
        public void TestBishopWithInvalidMove()
        {
            var gameObject = new GameObject();
            var bishop = gameObject.AddComponent<Bishop>();

            bishop.SetPosition(5, 0);
            Assert.AreEqual(bishop.ValidMove(5, 2), false);
        }

        [Test]
        public void TestBishopWithMoveOffTheBoard()
        {
            var gameObject = new GameObject();
            var bishop = gameObject.AddComponent<Bishop>();

            bishop.SetPosition(5, 7);
            Assert.AreEqual(bishop.ValidMove(4, 8), false);
        }

        // Queen Tests
        [Test]
        public void TestQueenWithValidStraightMove()
        {
            var gameObject = new GameObject();
            var queen = gameObject.AddComponent<Queen>();

            queen.SetPosition(3, 7);
            Assert.AreEqual(queen.ValidMove(7, 7), true);
        }

        public void TestQueenWithValidDiagonalMove()
        {
            var gameObject = new GameObject();
            var queen = gameObject.AddComponent<Queen>();

            queen.SetPosition(5, 3);
            Assert.AreEqual(queen.ValidMove(2, 0), true);
        }

        [Test]
        public void TestQueenWithInvalidMove()
        {
            var gameObject = new GameObject();
            var queen = gameObject.AddComponent<Queen>();

            queen.SetPosition(3, 3);
            Assert.AreEqual(queen.ValidMove(2, 1), false);
        }

        [Test]
        public void TestQueenWithMoveOffTheBoard()
        {
            var gameObject = new GameObject();
            var queen = gameObject.AddComponent<Queen>();

            queen.SetPosition(7, 0);
            Assert.AreEqual(queen.ValidMove(8, 0), false);
        }

        // King Tests
        [Test]
        public void TestKingWithValidMove()
        {
            var gameObject = new GameObject();
            var king = gameObject.AddComponent<King>();

            king.SetPosition(1, 1);
            Assert.AreEqual(king.ValidMove(1, 2), true);
        }

        [Test]
        public void TestKingWithInvalidMove()
        {
            var gameObject = new GameObject();
            var king = gameObject.AddComponent<King>();

            king.SetPosition(1, 1);
            Assert.AreEqual(king.ValidMove(4, 1), false);
        }

        [Test]
        public void TestKingWithMoveOffTheBoard()
        {
            var gameObject = new GameObject();
            var king = gameObject.AddComponent<King>();

            king.SetPosition(1, 0);
            Assert.AreEqual(king.ValidMove(1, -0), false);
        }
    }
}
