﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public Boss() : base()
    {
        this.health = 15; //+5 par etage
        this.strength = 3;
        this.dexterity = 0;
        this.moveSpeed = 3.5f;
        this.attackRadius = 2f;
    }
    public void phase2()
    {
        this.moveSpeed = 4.5f;
    }
    // Start is called before the first frame update
    public void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!dead)
            Move();
    }

    public override void Move()
    {
        if (Vector3.Distance(target.position, transform.position) > this.attackRadius)
        {
            if (this.currentState == EnemyState.walk || this.currentState == EnemyState.idle && this.currentState != EnemyState.takeDamage)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, this.moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                this.rb.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
        else
        {
            ChangeState(EnemyState.idle);
            animator.SetFloat("Speed", 0);
        }
    }

    protected void ChangeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    protected void SetAnimFloat(Vector2 setVector)
    {
        animator.SetFloat("MoveX", setVector.x);
        animator.SetFloat("MoveY", setVector.y);
        animator.SetFloat("Speed", this.moveSpeed);
    }

    protected void ChangeState(EnemyState newState)
    {
        if (this.currentState != newState)
        {
            currentState = newState;
        }
    }

    public override void TakeDamage(int damage)
    {
        StartCoroutine(DamageTakenCo());
        Debug.Log(this.health);
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        this.dead = true;
        StartCoroutine(DieCo());
    }

    protected IEnumerator DamageTakenCo()
    {
        animator.SetBool("takingDamage", true);
        yield return null;
        animator.SetBool("takingDamage", false);
        yield return new WaitForSeconds(.1f);
    }

    protected IEnumerator DieCo()
    {
        animator.SetBool("isDead", true);
        //Désactiver hitbox
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
