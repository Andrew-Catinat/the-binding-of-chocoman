using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{ idle, walk, attack, takeDamage}

public abstract class Enemy : Entity
{
    public EnemyState currentState;
    public Transform target;
    protected float attackRadius;

    public float GetAttackRadius(){
        return this.attackRadius;
    }

}
