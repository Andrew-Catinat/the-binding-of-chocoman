using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{

    public WeaponType type;

}

public enum WeaponType {Corps_a_Corps, Distance}