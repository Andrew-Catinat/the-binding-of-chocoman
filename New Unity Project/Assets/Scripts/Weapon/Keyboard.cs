using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : Weapon
{
 
    public Keyboard(){
        this.name = "Keyboard";
        this.type = WeaponType.Corps_a_Corps;
    }

    public override void Attack(string direction){
        Animator animator = GameManager.GetPlayer().animator;
        if(direction == "up"){
            animator.SetFloat("HorizontalAttack", 0);
            animator.SetFloat("VerticalAttack", 1);
        }
        if(direction == "down"){
            animator.SetFloat("HorizontalAttack", 0);
            animator.SetFloat("VerticalAttack", -1);
        }
        if(direction == "left"){
            animator.SetFloat("HorizontalAttack", -1);
            animator.SetFloat("VerticalAttack", 0);
        }
        if(direction == "right"){
            animator.SetFloat("HorizontalAttack", 1);
            animator.SetFloat("VerticalAttack", 0);
        }
        Debug.Log("Keyboard : to implement...");
    }

}
