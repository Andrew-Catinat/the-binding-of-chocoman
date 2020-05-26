using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolatineBullet : MonoBehaviour
{

    public Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D hitInfo){
        if(hitInfo.gameObject.CompareTag("Enemy")){
            Enemy enemy = hitInfo.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(GameManager.GetPlayer().GetDexterity());
        }
        Destroy(gameObject);
    }
}
