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
    private float invulnerabilityTime = 0.5f;
    private bool invulnerable = false;

    
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

    public override void Move()
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
        if(!this.invulnerable){
            base.TakeDamage(damage);
            StartCoroutine(DamageTakenCo());
        }
    }

    public override void Die(){
        this.dead = true;
        StartCoroutine(DieCo());
    }

    private IEnumerator DamageTakenCo(){
        animator.SetBool("takeDamage", true);
        this.invulnerable = true;
        //Attendre la fin de l'animation
        yield return null;
        yield return new WaitForSeconds(this.invulnerabilityTime);
        animator.SetBool("takeDamage", false);
        this.invulnerable = false;
    }

    private IEnumerator DieCo(){
        animator.SetBool("dead", true);
        //Changement de scene : A implementer
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }

}
