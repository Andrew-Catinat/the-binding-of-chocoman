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
        public void CreerClavier()
        {
            Keyboard clavier = new Keyboard();
            
            Assert.IsInstanceOf<Keyboard>(clavier);    
        }

        [Test]
        public void CreerChocolatine()
        {
            Chocolatine choco = new Chocolatine();
            Assert.IsInstanceOf<Chocolatine>(choco);
        }

        [Test]
        public void RamasserClavier()
        {
            Keyboard clavier = new Keyboard();
            Inventory inventory = new Inventory();
            inventory.Add(clavier);
            Assert.AreEqual(inventory.items["Weapon"], clavier);
        }

        [Test]
        public void RamasserChoco()
        {
            Chocolatine choco = new Chocolatine();
            Inventory inventory = new Inventory();
            inventory.Add(choco);
            Assert.AreEqual(inventory.items["Weapon"], choco);
        }

        //les deux cas de test suivant ont pu montrer qu'il y avait un bug.
        [Test]
        public void AddUneSecondeArme()
        {
            Keyboard clavier = new Keyboard();
            Chocolatine choco = new Chocolatine();
            Inventory inventory = new Inventory();
            inventory.Add(clavier);
            inventory.Add(choco);
            Assert.AreEqual(inventory.items["Weapon"], choco);
        }

/*
        [Test]
        public void RamasseClavierPuisChoco()
        {
            Keyboard clavier = new Keyboard();
            Chocolatine choco = new Chocolatine();
            Inventory inventory = new Inventory();
            inventory.Add(clavier);
            inventory.Add(choco);
            Assert.AreNotEqual(inventory.items["Weapon"], clavier);
        }
  */  }
}
    