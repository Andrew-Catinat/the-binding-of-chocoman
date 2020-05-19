using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class PlayerTests
    {
        // A Test behaves as an ordinary method

        [Test]
        public void Initialise_Point_De_Vie_Player_Test()
        {
            Player player = new Player();
            Assert.AreEqual(player.getSante(), 2);
        }
        [Test]
        public void Initialise_Force_Player_Test()
        {
            Player player = new Player();
            Assert.AreEqual(player.getForce(), 2);
        }
        [Test]
        public void Initialise_Dexterite_Player_Test()
        {
            Player player = new Player();

            Assert.AreEqual(player.getDexterite(), 2);
        }
        /*
       [Test]
       public void Deplacement_Vers_Le_Haut_Test()
        {
            
            Player player = new Player();
            player.movement.x = 1f;
            player.movement.y = 0f;
            player.rb = new Rigidbody2D();
            Vector2 posX = player.rb.position;
            Assert.True(true);
        } 
        */
    }
}   
