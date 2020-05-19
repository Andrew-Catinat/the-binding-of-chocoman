using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    
    protected float moveSpeed;
    protected int health;
    protected int strength;
    protected int dexterity;
    protected bool dead = false;

    public int GetHealth(){
        return this.health;
    }
    public int GetStrength(){
        return this.strength;
    }
    public int GetDexterity(){
        return this.dexterity;
    }

    public float MoveSpeed(){
        return this.moveSpeed;
    }

    public bool isDead(){
        return this.dead;
    }

    public virtual void TakeDamage(int damage){
        this.health -= damage;
        if(this.GetHealth() <= 0){
            Die();
        }
    }

    public abstract void Die();
    public abstract void Move();
}
