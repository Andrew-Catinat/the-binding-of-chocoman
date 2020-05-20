using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{

    new public string name;

    private void OnTriggerEnter2D(Collider2D collision){

        Interact();

    }

    public void Interact(){

        Debug.Log("Tu es entrain d'interagir avec " + transform.name);

        Pickup();

    }

    public void Pickup(){

        Debug.Log("Tu es entrain de ramasser " + this.name);
        if(Inventory.instance.Add(this)){
           gameObject.SetActive(false);
        }
    }

    public void Drop(){
   //     gameObject.SetActive(true);
    }

}
