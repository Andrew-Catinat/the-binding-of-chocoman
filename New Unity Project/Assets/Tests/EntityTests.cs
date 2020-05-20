using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EntityTests
    {

        [Test]
        public void initHpGea()
        {
            GEA ennemi = new GEA();
            Assert.AreEqual(ennemi.GetHealth(), 3);
        }
        [Test]
        public void initIDeadGea()
        {
            GEA ennemi = new GEA();
            Assert.AreEqual(ennemi.isDead(), false);
        }
        [Test]
        public void initStrengthGea()
        {
            GEA ennemi = new GEA();
            Assert.AreEqual(ennemi.GetStrength(), 1);
        }
        [Test]
        public void initDexterityGea()
        {
            GEA ennemi = new GEA();
            Assert.AreEqual(ennemi.GetDexterity(), 1);
        }
        [Test]
        public void initMoveSpeedGea()
        {
            GEA ennemi = new GEA();
            Assert.AreEqual(ennemi.MoveSpeed(), 4f);
        }
        [Test]
        public void recois1Dommages()
        {
            GEA ennemi = new GEA();
            ennemi.TakeDamage(1);
            Assert.AreEqual(ennemi.GetHealth(), 2);
        }
        [Test]
        public void recois2Dommages()
        {
            GEA ennemi = new GEA();
            ennemi.TakeDamage(2);
            Assert.AreEqual(ennemi.GetHealth(), 1);
        }
        [Test]
        public void recois3Dommages()
        {
            GEA ennemi = new GEA();
            ennemi.TakeDamage(3);
            Assert.AreEqual(ennemi.GetHealth(), 0);
            Assert.AreEqual(ennemi.isDead(), true);
        }
        [Test]
        public void recois3DommagesEnPlusieursFois()
        {
            GEA ennemi = new GEA();
            ennemi.TakeDamage(1);
            ennemi.TakeDamage(1);
            ennemi.TakeDamage(1);
            Assert.AreEqual(ennemi.GetHealth(), 0);
            Assert.AreEqual(ennemi.isDead(), true);
        }
        [Test]
        public void geaDie()
        {
            GEA ennemi = new GEA();
            ennemi.Die();
            Assert.AreEqual(ennemi.isDead(), true);
        }
    }
}
