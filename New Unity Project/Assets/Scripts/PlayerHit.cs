using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    private bool isColliding = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>() ;
            //Penser méthode Singleton avec un manager
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if(!isColliding){
                isColliding = true;
                enemy.TakeDamage(player.GetStrength());
            } else{
                StartCoroutine(Reset());
            }
        }
    }

    //Méthode pour éviter de toucher plusieurs fois un ennemie
    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
 
}
