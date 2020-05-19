using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public void show(){
        this.GetComponent<Renderer>().enabled = true;
    }

    public void hide(){
        this.GetComponent<Renderer>().enabled = false;
    }

  
}
