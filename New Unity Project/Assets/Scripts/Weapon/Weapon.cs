using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{

    public WeaponType type;
    // public SpriteRenderer sprite;
    // public Collider2D box;

    public override void Pickup(){
        base.Pickup();
        GameManager.GetPlayer().SetWeapon(this);
        // sprite.enabled = false;
        // box.enabled = false;
    }


    public abstract void Attack(string direction);
}

public enum WeaponType {Corps_a_Corps, Distance}