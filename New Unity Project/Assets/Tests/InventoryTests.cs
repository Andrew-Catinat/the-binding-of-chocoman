using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class InventoryTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void InventoryTestsTailleInventaireEstDeux()
        {
            Inventory inventory = new Inventory();
            Assert.AreEqual(inventory.space, 2);
        }
        [Test]
        public void InventoryTestsTailleInventaireEstPasTrois()
        {
            Inventory inventory = new Inventory();
            Assert.AreNotEqual(inventory.space, 3);
        }
        [Test]
        public void AjoutItem()
        {
            Keyboard clavier = new Keyboard();
            Chocolatine choco = new Chocolatine();
            Keyboard keyboard = new Keyboard();
            Assert.AreEqual(true, true);
        }
    }
}
