using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolatine : Weapon
{
    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointLeft;
    public Transform firePointRight;

    public GameObject chocolatinePrefab;
    
    public float speedBullet = 20f;
    public float bulletFire = 1.5f;

    public Chocolatine(){
        this.name = "Chocolatine";
        this.type = WeaponType.Distance;
    }

    public override void Attack(string direction){
        //Shoot choco
        if(direction == "up"){
            Rigidbody2D rb = InitBullet(firePointUp);
            rb.AddForce(Vector3.up * speedBullet, ForceMode2D.Impulse);
        }
        if(direction == "down"){
            Rigidbody2D rb = InitBullet(firePointDown);
            rb.AddForce(Vector3.down * speedBullet, ForceMode2D.Impulse);
        }
        if(direction == "left"){
            Rigidbody2D rb = InitBullet(firePointLeft);
            rb.AddForce(Vector3.left * speedBullet, ForceMode2D.Impulse);
        }
        if(direction == "right"){
            Rigidbody2D rb = InitBullet(firePointRight);
            rb.AddForce(Vector3.right  * speedBullet, ForceMode2D.Impulse);
        }
    }

    private Rigidbody2D InitBullet(Transform firePoint){
        GameObject bullet = Instantiate(chocolatinePrefab, firePoint.position, Quaternion.identity);
        return bullet.GetComponent<Rigidbody2D>();
    }

}
