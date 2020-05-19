using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GEA : Enemy
{

    private float hitTime = 2; //time in seconds between each hit
    private float curTime = 0; //time in seconds since last hit

    public GEA():base(){
        this.health = 4;
        this.strength = 1;
        this.dexterity = 1;
        this.moveSpeed = 4f;
        this.attackRadius = 1f;
    }

    void Start(){
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        if(!dead){
            curTime += Time.deltaTime;
            Move();
            if(Vector3.Distance(target.position, transform.position) < attackRadius){
                if(curTime >= hitTime){
                    Attack();
                }
            }
        }
            
    }

    public override void Move(){
        if(Vector3.Distance(target.position, transform.position) > this.attackRadius){
            if(this.currentState == EnemyState.walk || this.currentState == EnemyState.idle && this.currentState != EnemyState.takeDamage){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, this.moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                this.rb.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        } else {
            ChangeState(EnemyState.idle);
            animator.SetFloat("Speed", 0);
        }
    }
    
    private void ChangeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            } else if (direction.x < 0){
                SetAnimFloat(Vector2.left);
            }
        } else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0){
                SetAnimFloat(Vector2.up);
            } else if (direction.y < 0){
                 SetAnimFloat(Vector2.down);
            }
        }
    }

    private void SetAnimFloat(Vector2 setVector){
        animator.SetFloat("MoveX", setVector.x);
        animator.SetFloat("MoveY", setVector.y);
        animator.SetFloat("Speed", this.moveSpeed);
    }

    private void ChangeState(EnemyState newState){
        if(this.currentState != newState){
            currentState = newState;
        }
    }

    public override void TakeDamage(int damage)
    {
        StartCoroutine(DamageTakenCo());
        base.TakeDamage(damage);
    }

    public override void Die(){
        this.dead = true;
        StartCoroutine(DieCo());
    }

    private void Attack(){
        curTime = 0; //reset the time
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.TakeDamage(this.GetStrength());
        Debug.Log("Attaque");
    }

    private IEnumerator DamageTakenCo(){
        animator.SetBool("takingDamage", true);
        yield return null;
        animator.SetBool("takingDamage", false);
        yield return new WaitForSeconds(.1f);
    }

    private IEnumerator DieCo(){
        animator.SetBool("isDead", true);
        //Désactiver hitbox
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
