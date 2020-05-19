using UnityEngine;
using System.Collections;

public enum PlayerState{
    walk,
    attack,
}

public class Player : Entity
{
    PlayerState currentState = PlayerState.walk;
    Weapon weapon;

    
    public Player():base(){
        this.health = 2;
        this.strength = 2;
        this.dexterity = 2;
        this.moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack){
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk){
            Move();
        }
    }

    public override  void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");    
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private IEnumerator AttackCo(){
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.1f);
        currentState = PlayerState.walk;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public override void TakeDamage(int damage){
        StartCoroutine(DamageTakenCo());
        base.TakeDamage(damage);
    }

    public override void Die(){
        //animator.SetBool("dead", true);
        this.dead = true;
        StartCoroutine(DieCo());
        //this.gameObject.SetActive(false);
    }

    private IEnumerator DamageTakenCo(){
        animator.SetBool("takeDamage", true);
        yield return null;
        animator.SetBool("takeDamage", false);
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator DieCo(){
        animator.SetBool("dead", true);
        //Désactiver hitbox
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }


}
