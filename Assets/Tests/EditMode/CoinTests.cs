using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CoinTests
    {
        [Test]
        public void TestAddCoinMethod()
        {
            // Set up
            Coin.WhiteCoins = 0;
            Coin.BlackCoins = 0;

            Coin.AddCoin(true);
            
            // Only white gaines a coin
            Assert.AreEqual(1, Coin.WhiteCoins);
            Assert.AreEqual(0, Coin.BlackCoins);
        }

        [Test]
        public void TestRemoveCoinMethod()
        {
            Coin.WhiteCoins = 12;
            Coin.BlackCoins = 12;

            // isWhiteTurn = false
            Coin.RemoveCoins(false, 6);

            // Only black has 6 coins removed
            Assert.AreEqual(12, Coin.WhiteCoins);
            Assert.AreEqual(6, Coin.BlackCoins);
        }
    }
}
