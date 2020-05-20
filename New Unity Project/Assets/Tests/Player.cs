using UnityEngine;
using System.Collections;

public enum PlayerState{
    walk,
    attack,
    interact
}

public class Player : MonoBehaviour
{
    PlayerState currentState = PlayerState.walk;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    
    private int sante = 2;
    private int force = 2;
    private int dexterite = 2;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack){
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");    
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    private IEnumerator AttackCo(){
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public int getSante(){
        return this.sante;
    }
    public int getForce(){
        return this.force;
    }
    public int getDexterite(){
        return this.dexterite;
    }

}
